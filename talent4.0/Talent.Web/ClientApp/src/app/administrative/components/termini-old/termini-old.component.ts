import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { TerminiService } from 'app/administrative/services/termini.service';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, Sorting, JoinTable } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { Termini } from 'shared/models/termini';
import { TipiTermine } from 'shared/models/tipi-termine';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-termini-old',
	styleUrls: ['./termini-old.component.css'],
	templateUrl: './termini-old.component.html'
})
export class TerminiOldComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	private freeSearchFieldExtraColumns = "ter_tipo_termine;ter_sinonimo_1;ter_sinonimo_2;ter_sinonimo_3;ter_note;ter_descrizione";


	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;

	@ViewChild('existingRecordShowModal', { static: false }) existingRecordShowModal: ModalDirective;

	columnName: string = "termini";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;

	newObject: Termini = new Termini();
	selectedObject: Termini = new Termini();
	allTipiTermine: TipiTermine[];
	isSaveAndNextclicked = false;
	showCloseConfirmDialog: boolean = false;

	termini: Termini = new Termini();
	existingTermini: Termini[] = [];
	matchedSinonimi: string[] = [];
	matchedKeywords: string;
	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;

	rowNode: any;

	// Initiating the grid columns along with attributes
	columnDefs = [
		{ headerName: "Termine", field: "termine", width: 100 },
		{ headerName: "Tipo Termine", field: "terTipoTermine", width: 120 },
		{ headerName: "Sinonimo 1", field: "terSinonimo1", width: 100 },
		{ headerName: "Sinonimo 2", field: "terSinonimo2", width: 105 },
		{ headerName: "Sinonimo 3", field: "terSinonimo3", width: 105 },
		{ headerName: "Sinonimo 4", field: "terSinonimo4", width: 105 },
		{ headerName: "Sinonimo 5", field: "terSinonimo5", width: 105 },
		{ headerName: "Sinonimo 6", field: "terSinonimo6", width: 105 },
		{ headerName: "Sinonimo 7", field: "terSinonimo7", width: 105 },
		{ headerName: "Sinonimo 8", field: "terSinonimo8", width: 105 },
		{ headerName: "Note", field: "terNote", width: 100 },
		{ headerName: "Descrizione", field: "terDescrizione", width: 150 },
		{ headerName: "Link", field: "terLink", minWidth: 175 },
		{ headerName: "Stato", field: "terStato", width: 70 },
		{ headerName: "Frequenza", field: "terFrequenza", width: 100 }
	];

	//Filters and sorting data variables
	// allFilters: Filter[] = [
	// 	{
	// 		columnName: "ter_stato",
	// 		dataType: "text",
	// 		filterType: "like",
	// 		option1: "",
	// 		option2: ""
	// 	}
	// ];
	defaultSorting: Sorting = {
		columnName: "ter_mod_timestamp DESC",
		type: ""
	};
	// sorting: Sorting = new Sorting();
	// filterSortingModel: FilterSortingModel = {
	// 	filters: [],
	// 	clientColumn: "ter_cli_id"
	// };

	joinTables : JoinTable[] = [];

	sortableColumns: KeyValuePair[] = [];

	constructor(
		private terminiService: TerminiService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "termini");
	}

	ngOnInit() {
		this.logPageOpenTask();

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
					{ baseTableJoinFieldName: "sterdescr_lingua", joinTableJoinFieldName: "'" + this.loggedInUser.language +"'" }
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
					{ baseTableJoinFieldName: "tipterdescr_lingua", joinTableJoinFieldName: "'" +this.loggedInUser.language+"'" },
				]
			}
		];
		this.filterSortingModel = {
			filters: [],
			clientColumn: 'ter_cli_id',
			joinTableQueryDto: {
				joinTable: this.joinTables,
				joinTableRetreivedFields: [
					"sterdescr_descrizione" , "tipterdescr_descrizione"
				]
			}
		};





		this.resetSortingObject();

		// Pull all tipi termini and total db records.
		this.terminiService.getAllTipiTermine()
			.subscribe(
				response => {
					this.allTipiTermine = response;
				},
				error => {
					console.log(error)
				}
			);

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
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}

	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		// As we are editing a row, this flag is selected to false.
		this.isNewRowAdding = false;
		// Set selected object properties with event data.
		this.selectedObject = event.data;
		this.selectedObject.terModUteId = this.loggedInUser.uteId;
		this.newObjectAddModal.show();
		this.rowNode = event.node;
	}

	// Open the modal with input form when user clicks on ADD NEW KEYWORD button.
	onAddNew() {
		// As we are adding a row, this flag is selected to true    
		this.isNewRowAdding = true;
		this.resetSelectedObjectProperty();
		this.newObjectAddModal.show(); // Show the new termini add form in a modal.
	}

	// Post the form data to server.
	onNewObjectAddFormSubmit(form) {
		if (form.valid) {

			if (this.isNewRowAdding) {
				// Check if any termini with this name exists or not
				// If exists, show exist message.
				// If not exists, check the inserted synonyms already exists in the database or not.
				// If keyword match with any existing termini, Show it in the modal.
				// Otherwise post new termini to be inserted.
				this.terminiService.getTerminiDetails(this.selectedObject.termine)
					.subscribe(
						response => {
							this.toastrService.error("There is a termine named " + this.selectedObject.termine + " exists!!");
						},
						error => {
							if (error.status == 400) {
								// Synonyms search to find if synonym already exists or not
								var synonimoArray: string[] = this.generateSynonimoArray();
								if (!this.hasDuplicateSynonym(synonimoArray)) {
									this.terminiService.getTerminBySynonym(synonimoArray, this.selectedObject.termine)
										.subscribe(
											response => {
												var matchedTerminis: Termini[] = response;
												//if any keyword match with existinh terminis, show the in the modal
												if (matchedTerminis.length > 0) {
													this.showMatchedKeywords(synonimoArray, matchedTerminis);
												}
												else {
													// Adding new record begin.
													this.terminiService.saveTermineRecord(this.selectedObject)
														.subscribe(
															response => {
																this.toastrService.success("Successfully added");
																this.onApplyFilter();
																this.newObjectAddModal.hide();
																this.resetSelectedObjectProperty();
																this.newObjectAddForm.submitted = false;
															},
															err => {
																this.toastrService.error("Unexpected error");
																console.log(err);
															}
														);
													// Adding new record end.
												}
											},
											error => {
												console.log(error);
											}
										);
								}

							}
							else {
								console.log(error);
							}
						}
					);
			}

			else {
				// Updating a record begin.
				// Show confirmation messahe. 
				// If OK, then check if any inserted keyword match with any existing termine.
				// If keyword match with any existing termini, Show it in the modal.
				// Otherwise post new termini to be updated.
				if (confirm("Would you like to save the changes made on page?")) {
					var synonimoArray: string[] = this.generateSynonimoArray();
					if (!this.hasDuplicateSynonym(synonimoArray)) {
						this.terminiService.getTerminBySynonym(synonimoArray, this.selectedObject.termine)
							.subscribe(
								response => {
									var matchedTerminis: Termini[] = response;
									//if any keyword match with existinh terminis, show the in the modal
									if (matchedTerminis.length > 0) {
										this.showMatchedKeywords(synonimoArray, matchedTerminis);
									}
									else {
										this.terminiService.updateTermineRecord(this.selectedObject)
											.subscribe(
												response => {
													this.toastrService.success("Successfully updated");
													this.onApplyFilter();
													if (this.isSaveAndNextclicked) {
														this.pullNextRow();
													}
													else {
														this.newObjectAddModal.hide();
														this.newObjectAddForm.submitted = false;
													}
												},
												error => {
													this.toastrService.error("Unexpected error");
													console.log(error);
												}
											);
									}
								},
								error => {
									console.log(error);
								}
							);
					}
				}
				// Updating a record end.
			}

		}
		else {
			this.toastrService.error("Invalid form data");
		}
	}

	// Show Matched keywords in a modal.
	showMatchedKeywords(synonymArray: string[], existingTermini: Termini[]) {
		var matchedKeywords: string = "";
		var matchedSynonym: string[] = [];
		var showableTermini: Termini[] = [];

		// Loop through all synonym array.
		synonymArray.forEach(function (synonym) {
			// Loop through all keyword matched termini array.
			existingTermini.forEach(function (termini) {
				var thisTermini = new Termini()

				// Check if synonym match with any synonym of current termini.
				if (termini.terSinonimo1 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo2 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo3 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo4 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo5 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo6 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo7 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo8 == synonym) {
					thisTermini.terSinonimo1 = synonym;
				}

				// if this synonym matched with any termini of Matched Termini list,
				// then push the termini into showable termini array
				// and push the synonym into matched synonym array.
				// append the synonym with matched keyword variable seperated by comma.
				if (thisTermini.terSinonimo1 != null && !showableTermini.some(a => a.termine == termini.termine)) {
					thisTermini.termine = termini.termine;
					thisTermini.terTipoTermine = termini.terTipoTermine;
					matchedSynonym.push(synonym);
					showableTermini.push(thisTermini);
					matchedKeywords += synonym + ", ";
				}
			});
		});

		// Remove the last comma from matched keyword string.
		this.matchedKeywords = matchedKeywords.substring(0, (matchedKeywords.length - 2));
		this.matchedSinonimi = matchedSynonym;
		this.existingTermini = showableTermini;
		// Open the matched keywords showing modal.
		this.existingRecordShowModal.show();
	}

	// Generate an array with all the synonym inserted in the add/edit termini form.
	generateSynonimoArray() {
		var sinonimoArray = [];
		if (this.selectedObject.terSinonimo1 != null) sinonimoArray.push(this.selectedObject.terSinonimo1);
		if (this.selectedObject.terSinonimo2 != null) sinonimoArray.push(this.selectedObject.terSinonimo2);
		if (this.selectedObject.terSinonimo3 != null) sinonimoArray.push(this.selectedObject.terSinonimo3);
		if (this.selectedObject.terSinonimo4 != null) sinonimoArray.push(this.selectedObject.terSinonimo4);
		if (this.selectedObject.terSinonimo5 != null) sinonimoArray.push(this.selectedObject.terSinonimo5);
		if (this.selectedObject.terSinonimo6 != null) sinonimoArray.push(this.selectedObject.terSinonimo6);
		if (this.selectedObject.terSinonimo7 != null) sinonimoArray.push(this.selectedObject.terSinonimo7);
		if (this.selectedObject.terSinonimo8 != null) sinonimoArray.push(this.selectedObject.terSinonimo8);
		return sinonimoArray;
	}

	// Check if there are anym duplicate synonym.
	// If found, show an warning message and return true.
	// Else return false.
	hasDuplicateSynonym(sinonimoArray: string[]) {
		var length = sinonimoArray.length;
		if (length < 2) return false;
		var matchFound = false;
		var errorMsg = "";

		for (let i = 0; i < (length - 1); i++) {
			for (let j = (i + 1); j < length; j++) {
				if (sinonimoArray[i].toLowerCase() == sinonimoArray[j].toLowerCase()) {
					errorMsg += "Synonym " + (i + 1) + " and synonym " + (j + 1) + " are same <br />";
					matchFound = true
				}
			}
		}
		if (matchFound) {
			this.toastrService.warning(errorMsg);
		}
		return matchFound;
	}

	onCloseAddEditModal() {
		this.showCloseConfirmDialog = true;
	}

	// Pop up close confirmation modal click event.
	onDialogConfirm(choice: boolean) {
		if (choice) {
			this.newObjectAddModal.hide();
		}
		this.showCloseConfirmDialog = false;
	}

	// Add new row to the existing grid.
	addNewRowToGrid(newRow: Termini) {
		this.gridApi.updateRowData({ add: [newRow], addIndex: 0 });
	}

	// Pull the next row to show in the edit form on submit and next button click.
	pullNextRow() {
		var id = (+this.rowNode.id) + 1;
		this.rowNode = this.gridApi.getRowNode(String(id));
		this.selectedObject = this.rowNode.data;
		this.isSaveAndNextclicked = false;
	}

	// Reset the property of the selected object.
	resetSelectedObjectProperty() {
		this.selectedObject = null;
		this.selectedObject = new Termini();
		this.selectedObject.terTipoTermine = this.allTipiTermine.length > 0 ? this.allTipiTermine[0].tipoTermine : null;
		this.selectedObject.terStato = null;
		this.selectedObject.terInsUteId = this.loggedInUser.uteId;
		this.selectedObject.terModUteId = this.loggedInUser.uteId;
		this.selectedObject.terCliId = this.loggedInUser.uteCliId;
	}

	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
