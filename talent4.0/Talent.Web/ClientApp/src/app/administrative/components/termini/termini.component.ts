import { TerminiReviewInfo } from 'shared/models/termini';
import { TerminiService } from './../../services/termini.service';
import { Component, OnInit } from '@angular/core';
import { CommonGridBehaviourNew } from 'shared/models/common-grid-behaviour-new';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';
import { GridManagementService } from 'shared/services/grid-management.service';
import { MasterFilterTemplate } from 'shared/models/master-filter-temp';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { Termini } from 'shared/models/termini';
import { saveAs } from 'file-saver';

@Component({
	selector: 'app-termini',
	styleUrls: ['./termini.component.css'],
	templateUrl: './termini.component.html',
	providers: [GridManagementService, TerminiService, FilterService]
})
export class TerminiComponent extends CommonGridBehaviourNew implements OnInit {

	//#region Declaration
	private freeSearchFieldExtraColumns = "ter_tipo_termine;ter_sinonimo_1;ter_sinonimo_2;ter_sinonimo_3;ter_note;ter_descrizione";

	columnName: string = 'termini';
	isAddEditModalVisible: boolean = false;
	isNewRowAdding: boolean = true;

	isAllStatsModalVisible: boolean = false;


	lastReviewInfo: TerminiReviewInfo = new TerminiReviewInfo();

	allTerminiStates: KeyValuePair[] = [];
	allTerminiLanguage: KeyValuePair[] = [];
	allTerminiTypes: KeyValuePair[] = [];

	selectedTermini: Termini = new Termini();

	//allowedUSers : string[] = ["itpita.admin", "agosto9", "alessio.ciardini"];
	showExcelConfirmationDialog: boolean = false;
	confirmationMessage: string;
	printData: any;
	//#endregion


	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public filterService: FilterService,
		public translate: TranslateService,
		public gridManagementService: GridManagementService,
		private terminiService: TerminiService
	) {
		super(filterService, authService, toastrService, translate, gridManagementService, 'termini');
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'filter', 'termini']);
		this.setPageFilterVariableDatas();
	}

	ngOnInit() {
		this.loadGridSettingsInformation();
		this.loadInternalFilterDropdownLists();
		this.loadLastReviewInformation();
	}


	

	private loadLastReviewInformation() {
		this.terminiService.getLastKeywordRunInfo()
			.subscribe(
				response => {
					this.lastReviewInfo = response;
					console.log(response);
				},
				error => {
					console.log(error);
				}
			)
	}

	private loadInternalFilterDropdownLists() {
		this.filterService.getTerminiListTypeFilterData()
			.subscribe(
				response => {
					this.allTerminiStates = response[0];
					this.allTerminiLanguage = response[1];
					this.allTerminiTypes = response[2];
				},
				error => {
					console.log(error);
				}
			)
	}
	// Implement abstract method...
	setColumnDefinations() {

		this.columnDefs = [];
		this.addRemoveRowIndexToGrid();

		this.gridSettings.talentGridFieldsUserList
			.forEach(element => {
				var colDef: any = {
					headerName: element.tntgcuFieldLabelDescription
				};
				//colDef.headerName = element.tntgcuFieldLabelDescription;
				switch (element.tntgcuFieldName) {
					case "termine":
						colDef.field = 'termine';
						break;
					case "ter_cli_id":
						colDef.field = 'terCliId';
						break;
					case "ter_stato":
						colDef.field = 'terminiStatoDescr';
						break;
					case "ter_tipo_termine":
						colDef.field = 'terminiTipoDescr';
						break;
					case "ter_descrizione":
						colDef.field = 'terDescrizione';
						break;
					case "ter_frequenza":
						colDef.field = 'terFrequenza';
						break;
					case "ter_ins_timestamp":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.terInsTimestamp);
						});
						break;
					case "ter_mod_timestamp":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.terModTimestamp);
						});
						break;
					case "ter_ins_ute_id":
						colDef.field = 'terInsUteId';
						break;
					case "ter_mod_ute_id":
						colDef.field = 'terModUteId';
						break;

					case "ter_lingua":
						colDef.field = 'terLingua';
						break;
					case "ter_link":
						colDef.field = 'terLink';
						colDef.cellRenderer = param => {
							if (param.value)
								return `<a href="${param.value}" target="_blank">${param.value}</a>`;
						}
						break;
					case "ter_note":
						colDef.field = 'terNote';
						break;
					case "ter_sinonimo_1":
						colDef.field = 'terSinonimo1';
						break;
					case "ter_sinonimo_2":
						colDef.field = 'terSinonimo2';
						break;
					case "ter_sinonimo_3":
						colDef.field = 'terSinonimo3';
						break;
					case "ter_sinonimo_4":
						colDef.field = 'terSinonimo4';
						break;
					case "ter_sinonimo_5":
						colDef.field = 'terSinonimo5';
						break;
					case "ter_sinonimo_6":
						colDef.field = 'terSinonimo6';
						break;
					case "ter_sinonimo_7":
						colDef.field = 'terSinonimo7';
						break;
					case "ter_sinonimo_8":
						colDef.field = 'terSinonimo8';
						break;


					default:
						break;
				}

				//colDef.width = 250;
				if (element.tntgcuMinSize) {
					colDef.minWidth = element.tntgcuMinSize;
				}
				if (element.tntgcuMaxSize) {
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

		this.addRemoveRowIndexToGrid();
		this.gridOptions.api.setColumnDefs(this.columnDefs);

	}

	//#region External Filter

	// all the Declaration(variable/method) will appeare here.

	//#endregion

	//#region Internal Filter

	setPageFilterVariableDatas() {
		// Filters and sorting data variables
		this.allFilters = [
			{
				columnName: "ter_stato",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "ter_lingua",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "ter_tipo_termine",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "termine",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: this.freeSearchFieldExtraColumns
			}
			// ,
			// {
			// 	columnName: "sterdescr_lingua",
			// 	dataType: "text",
			// 	filterType: "equal",
			// 	option1: this.loggedInUser.language,
			// 	option2: ""
			// },
			// {
			// 	columnName: "tipterdescr_lingua",
			// 	dataType: "text",
			// 	filterType: "equal",
			// 	option1: this.loggedInUser.language,
			// 	option2: ""
			// }
		];

		this.sorting = {
			columnName: 'ter_mod_timestamp DESC',
			type: ''
		};

		this.joinTables = [
			{
				joinTableName: "stati_termine",
				joinFields: [
					{ baseTableJoinFieldName: "ter_stato", joinTableJoinFieldName: "ster_stato" }
				]
			},
			{
				joinTableName: "stati_termine_descr",
				joinFields: [
					{ baseTableJoinFieldName: "ster_stato", joinTableJoinFieldName: "sterdescr_ster_stato" },
					{ baseTableJoinFieldName: "sterdescr_lingua", joinTableJoinFieldName: "'" + this.loggedInUser.language + "'" }
				]
			},
			{
				joinTableName: "tipi_termine",
				joinFields: [
					{ baseTableJoinFieldName: "ter_tipo_termine", joinTableJoinFieldName: "tipo_termine" },
					{ baseTableJoinFieldName: "ter_cli_id", joinTableJoinFieldName: "tipter_cli_id" }
				]
			},
			{
				joinTableName: "tipi_termine_descr",
				joinFields: [
					{ baseTableJoinFieldName: "tipo_termine", joinTableJoinFieldName: "tipterdescr_tipo_termine" },
					{ baseTableJoinFieldName: "tipter_cli_id", joinTableJoinFieldName: "tipterdescr_tipter_cli_id" },
					{ baseTableJoinFieldName: "tipterdescr_lingua", joinTableJoinFieldName: "'" + this.loggedInUser.language + "'" },
				]
			}
		];
		this.filterSortingModel = {
			filters: [],
			clientColumn: 'ter_cli_id',
			joinTableQueryDto: {
				joinTable: this.joinTables,
				joinTableRetreivedFields: [
					"sterdescr_descrizione", "tipterdescr_descrizione"
				]
			}
		};
	}

	

	public pageSpecificFilterClearTask(): void {

	}
	public pageSpecificPreApplyFilterTasks(): void {

	}
  	public resetPageSpecificFilterDefaultValues(): void {
		this.allFilters[0].filterType = "like";
		this.allFilters[1].filterType = "like";
		this.allFilters[2].filterType = "like";
		this.allFilters[3].option2 = this.freeSearchFieldExtraColumns;

		// this.allFilters[4].option1 = this.loggedInUser.language;
		// this.allFilters[5].option1 = this.loggedInUser.language;
	}
	//#endregion

	//#region Termini Form

	
	// Pop up close confirmation of excel modal click event.
	onExcelDialogConfirm(choice: boolean) {
		if (choice) {
			this.onActionRadioChange('XLS');
		}
		this.showExcelConfirmationDialog = false;
	}

	onExcelClick() {
		this.confirmationMessage = this.translate.instant('common.usrmsg_info.L7022_gridExportConfirmation', { type: 'XLS' })
		this.showExcelConfirmationDialog = true;
	}

	// Common event of PDF/Print/XLS button click.
	onActionRadioChange(option) {

		switch (option) {

			case "PDF":
				//this.generatePdf();
				break;
			case "XLS":
				this.filterService.saveFileForTermini(this.getCurrentRowData())
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

	

	// Click event of print button.
	onPrintClick() {
		this.onActionRadioChange('print');
	}
	//#endregion

	//#region Common Grid

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
	onGridReady(params) {
		this.setfilterSortingModelData();
		this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
	}

	onRowClicked(event) {
		console.log(event);
		this.selectedTermini = event.data;
		this.isNewRowAdding = false;
		this.isAddEditModalVisible = true;
	}

	public afterGridDataLoadExecutePageSpecificTasks(response): void {

	}

	//#endregion



	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION BEGIN
	//========================================================================


	// Implement abstract method..
	// Set page filters from external filter object.
	setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) {

		// Mapping first filter from filterTemplate to pageFilter
		var f1 = filter.tntfilFiltropagSelect1FiltropagcampoCodice;
		if (f1 == "ter_stato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if (f1 == "ter_lingua") {
			this.resolveLanguageFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if (f1 == "ter_tipo_termine") {
			this.resolveCategoryFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if (f1 == "termine" || f1 == "ter_sinonimo_1" || f1 == "ter_sinonimo_2" || f1 == "ter_sinonimo_3" || f1 == "ter_note" || f1 == "ter_descrizione") {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}



		// Mapping second filter from filterTemplate to pageFilter
		var f2 = filter.tntfilFiltropagSelect2FiltropagcampoCodice;
		if (f2 == "ter_stato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if (f2 == "ter_lingua") {
			this.resolveLanguageFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if (f2 == "ter_tipo_termine") {
			this.resolveCategoryFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if (f2 == "termine" || f2 == "ter_sinonimo_1" || f2 == "ter_sinonimo_2" || f2 == "ter_sinonimo_3" || f2 == "ter_note" || f2 == "ter_descrizione") {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}

		// Mapping third filter from filterTemplate to pageFilter
		var f3 = filter.tntfilFiltropagSelect3FiltropagcampoCodice;
		if (f3 == "ter_stato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if (f3 == "ter_lingua") {
			this.resolveLanguageFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if (f3 == "ter_tipo_termine") {
			this.resolveCategoryFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if (f3 == "termine" || f3 == "ter_sinonimo_1" || f3 == "ter_sinonimo_2" || f3 == "ter_sinonimo_3" || f3 == "ter_note" || f3 == "ter_descrizione") {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}

	}


	

	// Need to implement this function based on 
	// action_type_id filter type and condition.
	private resolveLanguageFilter(condition: string, value: string) {
		if (condition == "equal") {
			this.allFilters[1].option1 = value;
		}
	}
	private resolveStateFilter(condition: string, value: string) {
		if (condition == "equal") {
			this.allFilters[0].option1 = value;
		}
	}
	
	private resolveFreeSearchFilter(condition: string, value: string) {

		if ((condition == "contains" || condition == "begins") && value) {
			this.allFilters[3].option1 = value;
		}
		else {
			this.allFilters[3].option1 = "";
		}

	}



	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION END
	//========================================================================





	//======================================================================
	//					TERMINI ADD/EDIT LOGIC BEGIN
	//======================================================================

	onAddNew() {
		this.isNewRowAdding = true;
		this.isAddEditModalVisible = true;
	}

	onTerminiAddEditModalClose(isChanged) {
		this.isAddEditModalVisible = false;
		this.isNewRowAdding = false;
		if (isChanged) {
			this.clearAllFilters();
			this.onApplyFilter();
		}

	}

	//======================================================================
	//					TERMINI ADD/EDIT LOGIC END
	//======================================================================





	//======================================================================
	//					ALL STATS LOGIC BEGIN
	//======================================================================

	// Need to implement this function based on 
	// action_type_id filter type and condition.
	private resolveCategoryFilter(condition: string, value: string) {
		if (condition == "equal") {
			this.allFilters[2].option1 = value;
		}
	}

	onAllStatsClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
		// this.isAllStatsModalVisible = true;
	}

	onAllStatsModalClose(event) {
		this.isAllStatsModalVisible = false;
	}

	//======================================================================
	//					ALL STATS LOGIC END
	//======================================================================


	// onExcelClick() {
	// 	this.confirmationMessage = this.translate.instant('common.usrmsg_info.L7022_gridExportConfirmation', { type: 'XLS' })
	// 	this.showExcelConfirmationDialog = true;

	// 	// this.toastrService.warning(
	// 	// 	this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
	// 	// );
	// }

	onPdfClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

	onFilterStateChange() {
		if (this.allFilters[0].option1) {
			this.allFilters[0].filterType = "equal";
		}
		else {
			this.allFilters[0].filterType = "like";
		}

		this.onApplyFilter();
	}

	onTerminiLanguageChange() {
		if (this.allFilters[1].option1) {
			this.allFilters[1].filterType = "equal";
		}
		else {
			this.allFilters[1].filterType = "like";
		}

		this.onApplyFilter();
	}

	onTerminiTypeChange() {
		if (this.allFilters[2].option1) {
			this.allFilters[2].filterType = "equal";
		}
		else {
			this.allFilters[2].filterType = "like";
		}

		this.onApplyFilter();
	}

	onStartAnalysis() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}



}
