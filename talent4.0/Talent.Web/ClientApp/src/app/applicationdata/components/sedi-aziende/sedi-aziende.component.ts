import { Component, OnInit, OnDestroy } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, Sorting, JoinTable } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { SediAzienda } from 'shared/models/sedi-aziende';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'app-sedi-aziende',
	templateUrl: './sedi-aziende.component.html',
	styleUrls: ['./sedi-aziende.component.css']
})
export class SediAziendeComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	columnName: string = "sedi_aziende";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;

	selectedObject: SediAzienda = new SediAzienda();

	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;
	rowNode: any;

	// If true, Add/Edit modal child component will be opened.
	showAddEditModal: boolean = false;
	currentAzId: number = 0;
	currentSedeAzId: number = 0;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "aziende.az_rag_sociale",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "azsede_descr",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "azsede_citta",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		}
	];
	defaultSorting: Sorting = {
		columnName: "azsede_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();

	joinTables: JoinTable[] = [
		{
			joinTableName: "aziende",
			joinFields: [
				{ baseTableJoinFieldName: "azsede_az_id", joinTableJoinFieldName: "az_id" },
				{ baseTableJoinFieldName: "azsede_cli_id", joinTableJoinFieldName: "az_cli_id" }
			]
		}
	];

	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "azsede_cli_id",
		joinTableQueryDto: {
			joinTable: this.joinTables,
			joinTableRetreivedFields: ["az_rag_sociale"]
		}
	};

	sortableColumns: KeyValuePair[] = [];



	// Initiating the grid columns along with attributes
	columnDefs = [];

	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "sedi_aziende");
	}
	sediAzendiLable: any;
	ngOnInit() {
		this.getMultiLanguageCommonLables();
		this.sediAzendiLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.sediAzendiLable = response.multiLanguage.sediAziende
					[this.loggedInUser.language.toLowerCase()];

					this.columnDefs = [
						{ headerName: this.sediAzendiLable.azsede_az_id, field: "azRagSociale", minWidth: 200 },
						{ headerName: this.sediAzendiLable.azsede_attiva, field: "azsedeAttiva", minWidth: 200 },
						{ headerName: this.sediAzendiLable.azsede_descr, field: "azsedeDescr", minWidth: 150 },
						{ headerName: this.sediAzendiLable.azsede_indirizzo, field: "azsedeIndirizzo", minWidth: 100 },
						{ headerName: this.sediAzendiLable.azsede_citta, field: "azsedeCitta", minWidth: 180 },
						{ headerName: this.sediAzendiLable.azsede_cap, field: "azsedeCap" }];
				},
				error => {
					console.log(error);
				}
			);


		this.logPageOpenTask();


		this.resetSortingObject();
	}

	caption: string;
	pageSizeText: string;
	totalRowCount: string;
	addButtonText: string;
	editButtonText: string;

	companyLabel: string;
	descriptionLabel: string;
	indicLabel: string;
	indicColloquioLabel: string;

	activeLabel: string;
	addressLabel: string;
	cityLabel: string;
	postcodeLabel: string;


	filterClear() {
		this.clearAllFilters();
		this.isFilterCleared = true;
	}

	// Calling the grid
	onGridReady(params) {
		this.setfilterSortingModelData();
		this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
	}

	// Set filter array of FilterSortingModel to allFilter array
	// and sorting model to sorting object.
	setfilterSortingModelData() {
		this.filterSortingModel.filters = this.allFilters;
		this.filterSortingModel.sorting = this.sorting;
	}

	// On page size dropdown value change, reload the grid.
	// Set pageindex=1 so that grid data starts from begining.
	onPageSizeChanged(newPageSize) {
		var value = (<HTMLInputElement>document.getElementById("page-size")).value;
		this.pageSize = Number(value);
		this.pageIndex = 1;
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	// On common-grid child component allFilter dropdown value change 
	// set the filterSortingModel object to selected filter's gridFilmaFilterString data.
	// As gridFilmaSortingString is a string type, to assign it's value to filterSortingModel object
	// first parse this string to a json object.
	filterChange($event) {
		this.gridColumnApi.resetColumnState();
		let filterJson = JSON.parse($event.gridfilmaFilterString);
		this.filterSortingModel = filterJson;
		this.allFilters = this.filterSortingModel.filters;
		this.sorting = this.filterSortingModel.sorting;
		let colOrder = JSON.parse($event.gridfilmaSortingString);
		this.gridColumnApi.setColumnState(colOrder);
		this.isFilterCleared = false;
		this.onApplyFilter();
	}

	// On common-grid child component clear button click
	// clear option1 and option2 property of all filter in allFilter array.
	// Reinitialize grid. 
	clearAllFilters() {
		this.allFilters.forEach(filter => {
			filter.option1 = "";
			filter.option2 = "";
		});
		this.resetSortingObject();
		this.filterSortingModel.filters = this.allFilters;
		if (this.gridColumnApi) {
			this.gridColumnApi.resetColumnState();
		}
		this.pageIndex = 1;
		this.isFilterCleared = true;
		this.onApplyFilter();
	}

	// On common-grid child component save filter button click
	// send the applied filter data from parent component to child component.
	onChangeFilterText($event) {
		let sortingData = this.gridColumnApi.getColumnState();
		this.appliedFilterInGrid = JSON.stringify(this.filterSortingModel);
		this.appliedSortingInGrid = JSON.stringify(sortingData);
	}

	// on grid-pagination child component pagination change
	// reinitialize the grid according to selected page number of child component.
	onPaginationPageChanged(page) {
		this.pageIndex = page;
		this.onApplyFilter();
	}

	// Initialize the grid according to applied filter data.
	onApplyFilter() {
		this.selectedObject = null;
		this.selectedObject = new SediAzienda();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}

	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();

		this.selectedObject = event.data;
		this.rowNode = event.node;
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
						this.rowNode = rowNode;
						this.selectedObject = rowNode.data;
					}
				});
			}
			else if (keyCode == KEY_DOWN) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index == rowIndex + 1) {
						this.rowNode = rowNode;
						this.selectedObject = rowNode.data;
					}
				});
			}
		}
	}

	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAddNew() {
		this.isNewRowAdding = true;
		this.currentAzId = this.selectedObject !== null ? this.selectedObject.azsedeAzId : 0;
		this.showAddEditModal = true;
	}

	// Click event of the Edit button
	onEditClick() {
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;
		if (this.selectedObject !== null) {
			this.currentAzId = this.selectedObject.azsedeAzId;
			this.currentSedeAzId = this.selectedObject.azsedeId;
			this.showAddEditModal = true;
		}
		else {
			this.toastrService.warning("Please select one before edit!!");
		}
	}

	onAddEditComplete(event: SediAzienda) {
		this.showAddEditModal = false;
		if (event !== null) {
			this.onApplyFilter();
		}
	}



	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
