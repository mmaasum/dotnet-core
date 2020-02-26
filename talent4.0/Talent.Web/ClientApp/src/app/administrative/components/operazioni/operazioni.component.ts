import { CommonGridBehaviourNew } from 'shared/models/common-grid-behaviour-new';
import 'shared/_extensions/date-time-extension';

import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { UtentiService } from 'app/administrative/services/user-create.service';
import { saveAs } from 'file-saver';
import * as jspdf from 'jspdf';
import { ModalDirective } from 'ngx-bootstrap';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { deLocale } from 'ngx-bootstrap/locale';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { MasterFilterTemplate } from 'shared/models/master-filter-temp';
import { UtentiOptimized } from 'shared/models/utenti-optimized';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

import { logoBase64 } from '../../../../assets/settings.json';
import { GridManagementService } from 'shared/services/grid-management.service';

defineLocale('en-gb', deLocale);
const toastrConfig = {
	positionClass: 'toast-top-center'
};

@Component({
	selector: 'operazioni',
	templateUrl: './operazioni.component.html',
	styleUrls: ['./operazioni.component.css'],
	providers: [GridManagementService, FilterService]
})
export class OperazioniComponent extends CommonGridBehaviourNew implements OnInit, OnDestroy {

	@ViewChild('globalErrorModal', { static: false }) globalErrorModal: ModalDirective;
	
	columnName : string = 'log_operazioni';
	
	today : number = Date.now();
	staticOptionChoser : string;

	showPrintConfirmationDialog : boolean = false;
	showPdfConfirmationDialog : boolean = false;
	showExcelConfirmationDialog : boolean = false;

	confirmationMessage : string;
	
	showCloseErrorDialog : boolean = false;
	allUsers : UtentiOptimized[] = [];
	printData : any;
	fromDate : Date;
	toDate : Date;
	selectedAction : string = '';



	// Initiating the grid columns along with attributes.
	

	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public filterService: FilterService,
		public translate: TranslateService,		
		public gridService: GridManagementService,
		private utenteService: UtentiService,
	) {
		super(filterService, authService, toastrService, translate, gridService, 'log_operazioni');
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'operazioni', 'filter']);
		this.setPageFilterVariableDatas();
	}

	// On component initialization tasks.
	ngOnInit() {

		this.logPageOpenTask();
		this.loadUsersList();

		this.setLastWeekyDate();
		this.allFilters[0].option1 = "";
		this.loadGridSettingsInformation();
	}


	
	// Set and initialize all the page filters and sorting. 
	setPageFilterVariableDatas() {
		// Filters and sorting data variables
		this.allFilters = [
			{
				columnName: "log_ute_id",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "log_timestamp",
				dataType: "datetime",
				filterType: "range",
				option1: "",
				option2: ""
			},
			{
				columnName: "log_descr",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: "log_dettaglio"
			}
		];
		this.sorting = {
			columnName: 'log_timestamp DESC',
			type: ''
		};
		this.filterSortingModel = {
			filters: [],
			clientColumn: 'log_cli_id'
		};
	}

	


	// Implement abstract method...
	// Set the grid column defination i.e visible columns, font size, font name, text decoration.
	setColumnDefinations() {
		this.columnDefs = [];
		this.addRemoveRowIndexToGrid();

		this.gridSettings.talentGridFieldsUserList
			.forEach(element => {
				var colDef: any = {
					headerName : element.tntgcuFieldLabelDescription
				};
				switch (element.tntgcuFieldName) {
					case "logoperazioni_id":
						colDef.field = 'logId';
						break;
					case "logoperazioni_descr":
						colDef.field = 'logDescr';
						break;
					case "logoperazioni_dett":
						colDef.field = 'logDettaglio';
						break;
					case "logoperazioni_timestamp":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.logTimestamp);
						});
						break;
					case "logoperazioni_user":
						colDef.field = 'logUteId';
						break;
					default:
						break;
				}

				//colDef.width = 250;
				if(element.tntgcuMinSize) {
					colDef.minWidth = element.tntgcuMinSize;
				}
				if(element.tntgcuMaxSize) {
					colDef.maxWidth = element.tntgcuMaxSize;
				}
				
				var style: any = {};
				if (element.tntgcuFieldTextAlign) {
					style['text-align'] = element.tntgcuFieldTextAlign.toLowerCase();
				}
				if (element.tntgcuFieldFontName) {
					style['font-family'] = element.tntgcuFieldFontName.toLowerCase();
				}
				if (element.tntgcuFieldFontSize) {
					style['font-size'] = element.tntgcuFieldFontSize.toString() + "px!important";
				}
				colDef.cellStyle = style;

				this.columnDefs.push(colDef);
			});


		this.gridOptions.api.setColumnDefs(this.columnDefs);
	}


	// Load all the user list.
	loadUsersList() {
		this.utenteService.getOptimizedUsersList("A")
			.subscribe(
				response => {
					this.allUsers = response;
				}
			)
	}


	// Initializing the grid.
	// Set filter sorting model properties.
	// Set grid data.
	// Set total records count.
	// Set column width according to column data.
	onGridReady(params) {
		this.setfilterSortingModelData();
		this.fromDate = null;
		this.toDate = null;
		this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
	}

	

	public afterGridDataLoadExecutePageSpecificTasks(): void {
		// do nothing...
	}

	


	

	// Implement abstract method..
	// Set Page specific default filter value..
	resetPageSpecificFilterDefaultValues() {
		this.allFilters[2].option2 = 'log_dettaglio';
	}

	// Implement abstract method..
	pageSpecificFilterClearTask() {
		this.staticOptionChoser = '';
		this.clearFilterDates();
	}

	// Set page filter date values from fromDate and toDate variable.
	private setFilterDates() {
		this.allFilters[1].option1 = this.fromDate == null ? '' : this.fromDate.getDatePortion();
		this.allFilters[1].option2 = this.toDate == null ? '' : this.toDate.getDatePortion();
	}

	// Clear fromDate and toDate variable to clear the calendar values.
	private clearFilterDates() {
		this.fromDate = null;
		this.toDate = null;
	}
	
	// Implement abstract method..
	pageSpecificPreApplyFilterTasks() {
		this.setFilterDates();
	}
	

	// On grid row clicked, executes the following..
	onRowClicked($event) {
		// console.log($event);
	}




	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION BEGIN
	//========================================================================


	// Implement abstract method..
	// Set page filters from external filter object.
	setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) {

		// Mapping first filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect1FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.resolveUserFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
				break;
			case "logoperazioni_descr_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
				break;
			case "logoperazioni_timestamp":
				this.resolveDateFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
				break;
			case "logoperazioni_descr":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
				break;
			case "logoperazioni_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
				break;
			default:
				break;
		}

		// Mapping second filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect2FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.resolveUserFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
				break;
			case "logoperazioni_descr_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
				break;
			case "logoperazioni_timestamp":
				this.resolveDateFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
				break;
			case "logoperazioni_descr":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
				break;
			case "logoperazioni_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
				break;
			default:
				break;
		}

		// Mapping third filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect3FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.resolveUserFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
				break;
			case "logoperazioni_descr_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
				break;
			case "logoperazioni_timestamp":
				this.resolveDateFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
				break;
			case "logoperazioni_descr":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
				break;
			case "logoperazioni_dett":
				this.resolveDescriptionDetailFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
				break;
			default:
				break;
		}
	}

	private resolveDescriptionDetailFilter(condition : string, value : string) {

		if((condition == "contains" || condition == "begins") && value) {
			this.allFilters[2].option1 = value;
		}
		else {
			this.allFilters[2].option1 = "";
		}

	}

	private resolveUserFilter(condition : string, value : string) {

		if(condition == "me") {
			this.allFilters[0].option1 = this.loggedInUser.uteId;
		}
		else if(condition == "equal") {
			this.allFilters[0].option1 = value;
		}
		else {
			this.allFilters[0].option1 = "";
		}

	}

	// Set page filters date.
	// If external filter type is date and the condition is range, set both from date and to date.
	// If otherwise, set only from date.
	private resolveDateFilter(condition : string, value : string) {

		if((condition == "before" ||condition == "sameorbefore")
			&& value
			&& value.length == 10
		) {
			this.toDate = value.toCustomDate();
		}
		else if((condition == "after" || condition == "sameorafter")
			&& value
			&& value.length == 10
		) {
			this.fromDate = value.toCustomDate();
		}
		else if(condition == "range" && value && value.length == 23) {
			this.setDateRange(value);
		}
		else {
			this.fromDate = null;
			this.toDate = null;
		}
		
	}

	// Set both from date and to date.
	private setDateRange(dateStringRange : string) {
		var dates = this.stringToDateRange(dateStringRange);
		if(dates.length == 2) {
			this.fromDate = dates[0];
			this.toDate = dates[1];
		}

	}

	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION END
	//========================================================================











	// Print dialog open.
	onPrint() {

		this.printData = this.getCurrentRowDataForTermini();

		return new Promise(resolve => {
			setTimeout(
				() => {
					let printContents, popupWin;
					printContents = document.getElementById('prin').innerHTML;
					popupWin = window.open('', 'left=0,top=0,width=1200,height=900,toolbar=0,scrollbars=0,status=0');
					popupWin.document.open();
					popupWin.document.write(`
            <html>
              <head>
                <title>Print Operazioni</title>
                <style></style>
                <meta charset="utf-8">
                  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
              </head>
              <body onload="window.print();">${printContents}</body>
            </html>`
					);
					popupWin.document.close();
				},
				15000
			);
		});
	}


	// Execute appropriate function depending on quick filter buttons.
	onStaticOptionChange() {
		switch (this.staticOptionChoser) {
			case 'me':
				this.getOwnLog();
				break;
			case 'yesterday':
				this.getYesterdayLog();
				break;
			case 'today':
				this.getTodayLog();
				break;
			case 'lastWeek':
				this.getLastWeekLog();
				break;
			default:
				break;
		}
	}

	// Event of clicking 'Me' button.
	getOwnLog() {
		this.allFilters[0].option1 = this.loggedInUser.uteId;
		this.onApplyFilter();
	}

	// Event of clicking yesterday button
	getYesterdayLog() {
		this.setYesterdayDate();
		this.onApplyFilter();
	}

	// Event of clicking today button
	getTodayLog() {
		this.setTodayDate();
		this.onApplyFilter();
	}

	// Event of clicking last week button
	getLastWeekLog() {
		this.setLastWeekyDate();
		this.onApplyFilter();
	}

	// For 'today' button, set both from date and to date to today date.
	private setTodayDate() {
		this.toDate = new Date();
		this.fromDate = new Date();
	}

	// For 'yesterday' button, set both from date and to date to yesterday date.
	private setYesterdayDate() {
		var refDate = new Date();
		var dt = refDate.addDays(-1);
		this.toDate = dt;
		this.fromDate = dt;
	}

	// For 'last week' button, 
	// set from date = 7 days ago date 
	// and to date = today date.
	private setLastWeekyDate() {
		var refDate = new Date();
		var dt = refDate.addDays(-7);
		this.toDate = refDate;
		this.fromDate = dt;
	}

	// Click event of print button.
	onPrintClick() {
		this.onActionRadioChange('print');
	}
	
	// Click event of PDF button.
	onPdfClick() {
		this.confirmationMessage = this.translate.instant('common.usrmsg_info.L7022_gridExportConfirmation', { type: 'Pdf' })
		this.showPdfConfirmationDialog = true;
	}

	// Click event of excel button.
	onExcelClick() {
		this.confirmationMessage = this.translate.instant('common.usrmsg_info.L7022_gridExportConfirmation', { type: 'XLS' })
		this.showExcelConfirmationDialog = true;
	}

	// Pop up close confirmation of print modal click event.
	onPrintDialogConfirm(choice: boolean) {
		if (choice) {
			this.onActionRadioChange('print');
		}
		this.showPrintConfirmationDialog = false;
	}

	// Pop up close confirmation of pdf modal click event.
	onPdfDialogConfirm(choice: boolean) {
		if (choice) {
			this.onActionRadioChange('PDF');
		}
		this.showPdfConfirmationDialog = false;
	}

	// Pop up close confirmation of excel modal click event.
	onExcelDialogConfirm(choice: boolean) {
		if (choice) {
			this.onActionRadioChange('XLS');
		}
		this.showExcelConfirmationDialog = false;
	}

	// Open not implemented modal.
	notImplemented() {
		this.showCloseErrorDialog = true;
	}

	// Open error dialog modal.
	onErrorDialogConfirm(choice: boolean) {
		this.showCloseErrorDialog = false;
	}

	// Common event of PDF/Print/XLS button click.
	onActionRadioChange(option) {

		switch (option) {

			case "PDF":
				this.generatePdf();
				break;
			case "XLS":
				this.filterService.saveFile(this.getCurrentRowData())
					.subscribe(
						res => {
							console.log(res.body);
							var fileName = (new Date()).getTime() + ".xlsx";
							saveAs(res.body, fileName);
						}
					);
				break;
			case "print":
				this.onPrint();
				break;
			default:
				break;
		}
	}


	// Generate pdf for current grid data set.
	private generatePdf() {
		
		var today= new Date();
		var data = this.getCurrentRowData();
		console.log(data);
		var headerRow = {
			'logId': "Log Id",
			'logTimestamp': "Time",
			'logUteId': "User",
			'logDescr': "Description",
			'logDettaglio': "Detail"
		};

		data.splice(0, 0, headerRow);

		var cellWidth = 40,
			rowCount = 0,
			cellContents,
			leftMargin = 2,
			topMargin = 28,
			topMarginTable = 55,
			headerRowHeight = 13,
			rowHeight = 15;

		var l = {
			orientation: 'l',
			unit: 'mm',
			format: 'a4',
			compress: false,
			fontSize: 8,
			lineHeight: 1.15,
			lineHeightProportion:1.15,
			autoSize: false,
			printHeaders: true
		};
		var visibleColumns = ['logId', 'logTimestamp', 'logUteId', 'logDescr', 'logDettaglio']

		var doc = new jspdf(l, '', '', '');
		doc.lineHeightProportion = 3;
		doc.lineHeight=2;
		var logo = logoBase64;
		doc.addImage(logo, 'png', 2, 2, 60, 20);

		doc.setFontSize(16);
		doc.text('Log operazioni', 294, 10, 'right');


		doc.setFontSize(12);
		doc.text('Talent © - Version 1.0.0', 294, 17, 'right');
		doc.setFontSize(10);
		doc.text('The Industry 4.0 Smart ATS', 294, 22, 'right');

		var c1width = 15, c2width = 45, c3width = 35, c4width = 50, c5width = 147;
		doc.cellInitialize();

		// console.log(data);
		data.forEach(function (row, i) {
			rowCount++;

			for (let cell in row) {
				if(cell == visibleColumns[4])
				{
					var textDetail = row[cell] == null ? ' ' : row[cell].toString().replace(/(.{85})/g, "$1\n");
					// console.log(textDetail);
					// console.log((textDetail.match(/\n/g) || '').length + 1);

					if((textDetail.match(/\n/g) || '').length> 1)
					{
						l.lineHeight=1.15;
						rowHeight = 20;
					}
					else{
						l.lineHeight=.7;
						rowHeight = 1;
					}
					console.log((textDetail.match(/\n/g) || '').length);
					// console.log(rowHeight*(textDetail.match(/\n/g) || '').length + 1);
					// rowHeight = rowHeight;
				}
				


				// .replace(/(.{40})/g, "$1<br>")
				var text = row[cell] == null ? ' ' : row[cell].toString();

				//console.log(text.length)
				doc.setFont("helvetica");

				// if (rowCount == 1) {
				//   // doc.margins = 1;
				//   doc.setFontType("bold");
				//   doc.setFontSize(8);

				//   if(cell == visibleColumns[0]) {
				//     doc.cell(2, topMargin, c1width, headerRowHeight, text, i);           
				//   }
				//   else if(cell == visibleColumns[1]) {
				//     doc.cell(0, topMargin, c2width, headerRowHeight, text, i);  
				//   }
				//   else if(cell == visibleColumns[2]) {
				//     doc.cell(0, topMargin, c3width, headerRowHeight, text, i);  
				//   }
				//   else if(cell == visibleColumns[3]) {
				//     doc.cell(0, topMargin, c4width, headerRowHeight, text, i);  
				//   }
				//   else if(cell == visibleColumns[4]) {
				//     doc.cell(0, topMargin, c5width, headerRowHeight, text, i);  
				//   }
				// }
				// else {


				doc.setFontType("normal");
				doc.setFontSize(10);
				if (cell == visibleColumns[0]) {
					doc.cell(2, topMargin, c1width, rowHeight, text, i);
				}
				else if (cell == visibleColumns[1]) {
					
    				//this.setDob = datePipe.transform(text, 'dd/MM/yyyy');
					doc.cell(0, topMargin, c2width, rowHeight, text, i);
				}
				else if (cell == visibleColumns[2]) {
					doc.cell(0, topMargin, c3width, rowHeight, text, i);
				}
				else if (cell == visibleColumns[3]) {
					var textDesc = row[cell] == null ? ' ' : row[cell].toString().replace(/(.{24})/g, "$1\n");
					doc.cell(0, topMargin, c4width, rowHeight, textDesc, i);
				}
				else if (cell == visibleColumns[4]) {
					// var textDetail = row[cell] == null ? ' ' : row[cell].toString().replace(/(.{85})/g, "$1\n");
					// console.log(textDetail);
					// console.log((textDetail.match(/\n/g) || '').length + 1)
					doc.cell(0, topMargin, c5width, rowHeight, textDetail, i);
				}
				// }





			}

		})

		var fileName = (new Date()).getTime() + ".pdf";
		doc.save(fileName);
	}


	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
