import { Component } from '@angular/core';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { FilterService } from 'shared/services/filters.service';
import { RichiesteService } from 'app/administrative/services/richieste.service';
import { ActivatedRoute } from '@angular/router';
import { saveAs } from 'file-saver';
import { Risorse } from 'shared/models/risorse';
import { RichiesteListaRisorse } from 'shared/models/richiesteListaRisorse';
import { map } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { Filter, Sorting, JoinTable, FilterSortingModel } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { CustomLoadingOverlay } from 'shared/components/custom-loading-overlay/custom-loading-overlay.component';
import { MachineLearningMatchingButtonComponent } from 'app/administrative/components/machine-learning-matching-button/machine-learning-matching-button.component';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'matching-record',
	templateUrl: './matching-record.component.html',
})
export class MatchingRecordComponent extends CommonGridBehaviour {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	private richId: string;
	columnName: string = "matching";
	isFilterSaveable: boolean = false;
	isFilterCleared: boolean = true;

	richiesteListaRisorse: RichiesteListaRisorse = new RichiesteListaRisorse();
	selectedObject: Risorse = new Risorse();
	addButtonText: string;
	grade: number = null;
	gradeAdd: number;
	actionTakenStatus: number;
	message: any;
	multiLanguageCommonLabels: any;

	showMatchingRecord: boolean = false;
	fromMachineLearningPopup: boolean = true;

	private context: any;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "actionTaken",
			dataType: "number",
			filterType: "equal",
			option1: "",
			option2: ""
		}
	];
	defaultSorting: Sorting = {
		columnName: "rich_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();

	joinTables: JoinTable[] = [];

	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "rich_cli_id",
		joinTableQueryDto: {
			joinTable: this.joinTables,
			joinTableRetreivedFields: []
		}
	};

	sortableColumns: KeyValuePair[] = [];

	option: string = '';

	constructor(
		private activatedRoute: ActivatedRoute,
		private richiesteService: RichiesteService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "matching");
		this.context = { componentParent: this };
		this.frameworkComponents = {
			customLoadingOverlay: CustomLoadingOverlay,
			matchingButtonRenderer: MachineLearningMatchingButtonComponent
		};
	}


	columnDefsRich = [];
	rowDataRich: any;

	columnDefsMatchingRecord = [];
	rowMatchingRecord: any;

	/* Initialize the master
	* lists collum header
	*/
	columnDefs = [
		{ headerName: "Candidates", field: "candidates", minWidth: 200 },
		{ headerName: "Skills", field: "skills", minWidth: 200 },
		{ headerName: "Status", field: "status", minWidth: 150 },
		{ headerName: "Grade", field: "grade", minWidth: 50 },
		{ headerName: "ststuas", field: "actionTaken", minWidth: 50 }
	];

	/**
	 * This method is
	 * build in method to
	 * display the initial
	 * values
	 * */
	ngOnInit() {
		this.addButtonText = 'Add';
		this.multiLanguageCommonLabels = this.richiesteService.getMultiLanguegeData()
			.subscribe(
				response => {
					const userLanguage = this.loggedInUser.language.toLowerCase();
					this.multiLanguageCommonLabels = response.multiLanguage.common[userLanguage];

					this.columnDefsRich = [
						{ headerName: this.multiLanguageCommonLabels.rich_id, field: "richId" },
						{ headerName: this.multiLanguageCommonLabels.rich_az_id, field: "azRagSociale" },
						{ headerName: this.multiLanguageCommonLabels.rich_comp_principale, field: "richCompPrincipale" },
						{ headerName: this.multiLanguageCommonLabels.rich_citta, field: "richCitta" },
						{ headerName: "richNumPosizioni", field: "richNumPosizioni" },
						{
							headerName: "",
							cellRenderer: "matchingButtonRenderer"
						}
					];
				});

		this.activatedRoute.queryParams
			.subscribe(
				params => {
					if (params['hideButton']) {
						this.fromMachineLearningPopup = false;
					}
					else {
						this.fromMachineLearningPopup = true;
					}
					this.richId = params['id'];
					this.option = params['option'];
				}
			);
	}


	filterClear() {
		this.clearAllFilters();
		this.isFilterCleared = true;
	}

	// On common-grid child component clear button click
	// clear option1 and option2 property of all filter in allFilter array.
	// Reinitialize grid. 
	clearAllFilters() {
		this.allFilters.forEach(filter => {
			filter.option1 = "";
			filter.option2 = "";
		});
		// this.resetSortingObject();
		this.filterSortingModel.filters = this.allFilters;
		if (this.gridColumnApi) {
			this.gridColumnApi.resetColumnState();
		}
		this.pageIndex = 1;
		this.isFilterCleared = true;
		this.onApplyFilter();
	}



	onApplyFilter() {
		var selectedState = +this.allFilters[0].option1;
		this.pullGridDate(selectedState);
	}

	private setrichiesteListaRisorseObjectData() {
		this.richiesteListaRisorse.richlistRichId = this.richId;
		this.richiesteListaRisorse.richlistRisId = this.selectedObject.risId;
		this.richiesteListaRisorse.richlistCliId = this.loggedInUser.uteCliId;
		this.richiesteListaRisorse.richlistVoto = this.gradeAdd;
	}

	onReject() {
		this.richiesteListaRisorse.richlistStato = 2;
		this.rejectOrAssignTask("Rejected");
	}

	onAssign() {
		this.richiesteListaRisorse.richlistStato = 1;
		this.rejectOrAssignTask("Assigned");
	}

	private rejectOrAssignTask(type: string) {
		this.setrichiesteListaRisorseObjectData();
		this.richiesteService.insertTalentRichlistRisorse(this.richiesteListaRisorse)
			.subscribe(
				data => {
					this.toastrService.success(type + " successfully!!");
					this.pullGridDate(0);
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpeced error occured!");
				}
			);
	}

	// Set master grid width to full if detail is updated/deleted.
	private setFullMasterGridWidth() {
		this.showMatchingRecord = false;
		var element = document.getElementById("idGrid");
		element.classList.remove("col-md-8");
		element.classList.remove("col-md-4");
		element.classList.add("col-md-12");
	}


	/**
	 * Load the master list
	 * initially and list should
	 * be populate according
	 * to client id
	 * @param params
	 */


	onGridReady(params) {
		this.gridApi = params.api;
		this.gridColumnApi = params.columnApi;

		//console.log()
		this.pullGridDate(0);
	}


	pullGridDate(status: number) {
		var allRecordsObservable: any;
		if (this.option == 'matching') {
			allRecordsObservable = this.richiesteService.getMatchingRichieste(this.richId, status);
		}
		else {
			allRecordsObservable = this.richiesteService.launchMachineLearning(this.richId);
		}

		this.rowData = allRecordsObservable.pipe(
			map(
				(response: any) => {
					this.totalGridRecords = response.length;
					this.selectedObject = new Risorse();
					this.setFullMasterGridWidth();
					console.log(response);
					return response;

				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			)
		);
	}


	onRichGridReady(params) {
		this.richiesteService.getRichiesteById(this.richId)
			.subscribe(
				data => {
					this.rowDataRich = of(Array(data));
				}
			);
	}

	onFirstDataRendered(params) {
		params.api.sizeColumnsToFit();
	}

	colunmsWidthBasedContent() {
		var allColumnIds = [];
		this.gridColumnApi.getAllColumns().forEach(function (column) {
			allColumnIds.push(column.colId);
		});
		this.gridColumnApi.autoSizeColumns(allColumnIds);
	}

	// Keyboard key event for grid behaviour.
	onCellKeyDown(event: any) {
		var ctrlPressed = event.event.ctrlKey;
		var keyCode = event.event.keyCode;
		var rowIndex = event.rowIndex;
		if (ctrlPressed == false && (keyCode == KEY_UP || keyCode == KEY_DOWN)) {
			if (keyCode == KEY_UP) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index == rowIndex - 1) {
						this.getRisorseDetail(rowNode.data);
					}
				});
			}
			else if (keyCode == KEY_DOWN) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index == rowIndex + 1) {
						this.getRisorseDetail(rowNode.data);
					}
				});
			}
		}
	}

	/**
	 * Clicking on the master
	 * list display the detail
	 * and keep grade on
	 * add/update mood.
	 * 
	 * @param event
	 */
	onRowClicked(event: any) {
		this.showMatchingRecord = false;
		this.colunmsWidthBasedContent();
		var element = document.getElementById("idGrid");
		element.classList.remove("col-md-12");
		element.classList.add("col-md-8");

		this.addButtonText = event.data.grade != '' ? 'Update' : 'Add';
		this.getRisorseDetail(event.data);
	}

	private getRisorseDetail(eventData: any) {
		this.richiesteService.getRisorseDetails(eventData.risId)
			.subscribe(
				response => {
					this.selectedObject = response;
					this.gradeAdd = eventData.grade;
					this.actionTakenStatus = +eventData.actionTaken;
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);
	}

	/**
	 * Storing the grad point
	 * for the specifice
	 * match
	 * */
	onSaveGrade() {
		this.setrichiesteListaRisorseObjectData();
		this.richiesteService.getExistingRowCount(this.selectedObject.risId, this.richId)
			.subscribe(
				response => {
					this.insertOrUpdateByGrade(response.count);
				},
				error => {
					console.log(error);
				}
			);

	}


	private insertOrUpdateByGrade(rowCount: number) {

		var insertUpdateObservable$: Observable<any>;
		if (rowCount > 0) {
			insertUpdateObservable$ = this.richiesteService.updateRichListRisorse(this.richiesteListaRisorse);
		}
		else {
			insertUpdateObservable$ = this.richiesteService.insertRichListRisorse(this.richiesteListaRisorse);
		}

		insertUpdateObservable$.subscribe(
			response => {
				this.toastrService.success("Successfully added grade");
				this.pullGridDate(0);
			},
			error => {
				console.log(error);
				this.toastrService.error("Unexpected error occured!");
			}
		);

	}



	/**
	 * On curriculum button click download CV document.
	 * */
	onGetCV() {
		saveAs('/api/Risorse/GetRisorseCV/' + this.selectedObject.risId);
	}


	loadMatchingRecord() {
		var element = document.getElementById("idGrid");
		if (element.classList.contains("col-md-12")) {
			element.classList.remove("col-md-12");
			element.classList.add("col-md-8");
		}
		else {
			element.classList.remove("col-md-8");
			element.classList.add("col-md-4");
		}

		this.showMatchingRecord = true;
		this.richiesteService.getMatchingRecord(this.richId)
			.subscribe(
				data => {
					this.columnDefsMatchingRecord = [
						{ headerName: "Candidates", field: "candidates", minWidth: 200 },
						{ headerName: "Skills", field: "skills", minWidth: 200 },
						{ headerName: "Status", field: "status", minWidth: 150 },
						{ headerName: "Grade", field: "grade", minWidth: 50 }
					];
					this.rowMatchingRecord = data;
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);

	}
}
