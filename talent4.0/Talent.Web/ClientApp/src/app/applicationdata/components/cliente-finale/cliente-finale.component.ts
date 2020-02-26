import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { Aziende } from 'shared/models/aziende';
import { AziendeClientiFinale } from 'shared/models/aziende-clienti-finale';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, JoinTable, Sorting } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'app-cliente-finale',
	templateUrl: './cliente-finale.component.html',
	styleUrls: ['./cliente-finale.component.css']
})
export class ClienteFinaleComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	caption = (this.loggedInUser.language === 'ENG') ? 'Finale Client' :
		((this.loggedInUser.language === 'ITA') ? 'Cliente Finale' : 'Cliente final');

	totalRowCount = (this.loggedInUser.language === 'ENG') ? 'Total rows count' :
		((this.loggedInUser.language === 'ITA') ? 'Righe Totali' : 'Recuento total de filas');

	pageSizeText = (this.loggedInUser.language === 'ENG') ? 'Page Size' :
		((this.loggedInUser.language === 'ITA') ? 'Righe per Pagina' : 'Tamaño de página');

	columnName: string = "aziende_clienti_finali";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;


	selectedObject: AziendeClientiFinale = new AziendeClientiFinale();
	allAziende: Aziende[] = [];

	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;
	rowNode: any;

	// If true, Add/Edit modal child component will be opened.
	showAddEditModal: boolean = false;
	currentAzId: number = 0;
	currentClienteFinaleId: number = 0;

	// Initiating the grid columns along with attributes
	columnDefs = [
		{ headerName: "Azienda", field: "azRagSociale" },
		{ headerName: "Cliente Finale", field: "clifinNomeClienteFinale" },
		{ headerName: "Indirizzo", field: "clifinIndirizzo" }
	];

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
			columnName: "clifin_nome_cliente_finale",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "clifin_luogo_lavoro",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		}
	];
	defaultSorting: Sorting = {
		columnName: "clifin_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();


	joinTables: JoinTable[] = [
		{
			joinTableName: "aziende",
			joinFields: [
				{ baseTableJoinFieldName: "clifin_az_id", joinTableJoinFieldName: "az_id" },
				{ baseTableJoinFieldName: "clifin_cli_id", joinTableJoinFieldName: "az_cli_id" }
			]
		}
	];

	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "clifin_cli_id",
		joinTableQueryDto: {
			joinTable: this.joinTables,
			joinTableRetreivedFields: ["az_rag_sociale"]
		}
	};

	sortableColumns: KeyValuePair[] = [];

	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "aziende_clienti_finali");
	}

	ngOnInit() {
		this.logPageOpenTask();
		this.resetSortingObject();
	}

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
		this.onApplyFilter();
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
		this.selectedObject = new AziendeClientiFinale();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
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

	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();

		this.selectedObject = event.data;
		this.rowNode = event.node;
	}

	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAddNew() {
		this.isNewRowAdding = true;
		this.currentAzId = this.selectedObject !== null ? this.selectedObject.clifinAzId : 0;
		this.showAddEditModal = true;
	}

	// Click event of the Edit button
	onEditClick() {
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;
		if (this.selectedObject !== null) {
			this.currentAzId = this.selectedObject.clifinAzId;
			this.currentClienteFinaleId = this.selectedObject.clifinId;
			this.showAddEditModal = true;
		}
		else {
			this.toastrService.warning("Please select one before edit!!");
		}
	}

	onAddEditComplete(event: AziendeClientiFinale) {
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
