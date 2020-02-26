import { JoinTable } from './../../../shared/models/filter-sorting-model';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { Aziende } from 'shared/models/aziende';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Contatti } from 'shared/models/contatti';
import { Email } from 'shared/models/email';
import { Filter, FilterSortingModel, Sorting } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { Titoli } from 'shared/models/titoli';
import { Utenti } from 'shared/models/utenti';
import { FilterService } from 'shared/services/filters.service';

import { ContattiService } from '../../services/contatti.service';
import { SediAzienda } from 'shared/models/sedi-aziende';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'app-contatti',
	templateUrl: './contatti.component.html',
	styleUrls: ['./contatti.component.css']
})
export class ContattiComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;
	@ViewChild('emailModal', { static: false }) emailModal: ModalDirective;
	@ViewChild('emailForm', { static: false }) emailForm: HTMLFormElement;

	columnName: string = "contatti";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;
	showCloseConfirmDialog: boolean = false;

	newObject: Contatti = new Contatti();
	selectedObject: Contatti = new Contatti();
	emailObject: Email = new Email();
	aziende: Aziende[] = [];
	allSedeAziende: SediAzienda[] = [];
	allTipoContatto: any[] = [];
	allTitoli: Titoli[] = [];
	allUtenti: Utenti[] = [];
	sortableColumns: KeyValuePair[] = [];
	multiLanguageLable: any;

	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,citta
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;
	rowNode: any;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "cont_nome",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: "cont_cognome"
		},
		{
			columnName: "aziende.az_rag_sociale",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		}
	];
	defaultSorting: Sorting = {
		columnName: "cont_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();

	joinTables: JoinTable[] = [
		{
			joinTableName: "aziende",
			joinFields: [
				{ baseTableJoinFieldName: "cont_az_id", joinTableJoinFieldName: "az_id" },
				{ baseTableJoinFieldName: "cont_cli_id", joinTableJoinFieldName: "az_cli_id" }
			]
		},
		{
			joinTableName: "sedi_aziende",
			joinFields: [
				{ baseTableJoinFieldName: "cont_azsede_id", joinTableJoinFieldName: "azsede_id" }
			]
		},
		{
			joinTableName: "utenti",
			joinFields: [
				{ baseTableJoinFieldName: "cont_rif_ute_id", joinTableJoinFieldName: "ute_id" },
				{ baseTableJoinFieldName: "cont_cli_id", joinTableJoinFieldName: "ute_cli_id" }
			]
		},
	];

	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "cont_cli_id",
		joinTableQueryDto: {
			joinTable: this.joinTables,
			joinTableRetreivedFields: ["azsede_descr", "ute_nome", "az_rag_sociale"]
		}
	};




	// Initiating the grid columns along with attributes

	constructor(
		private contattiService: ContattiService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "contatti");
	}
	//multiLanguageLable:any;
	//contattiMultiLanguageCommonLable:any;
	columnDefs = [];


	ngOnInit() {
		this.logPageOpenTask();
		this.getMultiLanguageCommonLables();

		this.multiLanguageLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.multiLanguageLable = response.multiLanguage.contatti
					[this.loggedInUser.language.toLowerCase()];

					this.columnDefs = [
						{ headerName: this.multiLanguageLable.cont_nome, field: "contNome", minWidth: 200 },
						{ headerName: this.multiLanguageLable.cont_cognome, field: "contCognome", minWidth: 200 },
						{ headerName: this.multiLanguageLable.cont_az_id, field: "azRagSociale", minWidth: 150 },
						{ headerName: this.multiLanguageLable.cont_telefono_1, field: "contTelefono1", minWidth: 100 },
						{ headerName: this.multiLanguageLable.cont_email_1, field: "contEmail1", minWidth: 180 },
						{ headerName: this.multiLanguageLable.cont_tipo_contatto, field: "contTipoContatto" }];
				},
				error => {
					console.log(error);
				}
			);



		this.resetSortingObject();

		// Get users,titles,aziende,company types for contatti add/edit form dropdown list.
		forkJoin(
			this.contattiService.getAllAziende(),
			this.contattiService.getAllTipoContatto(),
			this.contattiService.getAllTitoli(),
			this.contattiService.getAllTheUsers())
			.subscribe(
				response => {
					this.aziende = response[0];
					this.allTipoContatto = response[1];
					this.allTitoli = response[2];
					this.allUtenti = response[3];
				},
				error => {
					console.log(error);
				}
			);
	}

	// insertDefaultHeadquarterInSedeArray() {
	//   var count = this.allSedeAziende.length;
	//   this.allSedeAziende.splice(0, count);
	//   console.log(this.allSedeAziende);
	//   var sede = new SediAzienda();
	//   sede.azsedeId = 0;
	//   switch (this.loggedInUser.language) {
	//     case "ENG" : 
	//       sede.azsedeDescr = "Headquarter";
	//       break;
	//     case "ESP" : 
	//       sede.azsedeDescr = "Sede";
	//       break;
	//     case "ITA" : 
	//       sede.azsedeDescr = "Principale";
	//       break;
	//     default : 
	//       break;  
	//   }
	//   console.log(this.allSedeAziende);
	// }

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
		this.selectedObject = new Contatti();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}

	// Set dropdown default value.
	setDefaultDropdownValue() {
		// this.newObject.contTitolo = this.allTitoli.length > 0 ? this.allTitoli[0].titolo : null;
		this.newObject.contAzId = null;
		// this.newObject.contRifUteId = this.allUtenti.length > 0 ? this.allUtenti[0].uteId : null;
		this.newObject.contTipoContatto = this.allTipoContatto.length > 0 ? this.allTipoContatto[0].tipoContatto : null;
		this.newObject.contAttivo = "S";
		this.newObject.contCvIniziali = "S";
		this.newObject.contAzsedeId = 0;
	}

	// Set modified by user id fro update and add.
	// For add also set inserted by user id and client id.
	onAddEditModalOpenSetUteCliId() {
		if (this.isNewRowAdding) {
			this.newObject.contCliId = this.loggedInUser.uteCliId;
			this.newObject.contInsUteId = this.loggedInUser.uteId;
		}
		this.newObject.contModUteId = this.loggedInUser.uteId;
	}



	// Open the modal with input form .
	onAddNew() {
		// Set isNewRowAdding value to true as we are adding a new row.
		this.isNewRowAdding = true;
		// Reinitiate newObject.        
		this.newObject = null;
		this.newObject = new Contatti();
		this.newObjectAddModal.show();
		this.setDefaultDropdownValue();
		this.onAddEditModalOpenSetUteCliId();
		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;
	}

	// Click event of the Edit button
	onEditClick() {
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;
		// Set new object value as selected row of the grid.
		this.newObject = this.selectedObject;
		this.newObject.contAzsedeId = this.newObject.contAzsedeId ? this.newObject.contAzsedeId : 0;
		this.newObjectAddModal.show();
		this.onAziendeChange();
		this.onAddEditModalOpenSetUteCliId();
	}

	// Post the form data to server.
	onNewObjectAddFormSubmit(form) {
		if (form.valid) {
			// Adding a new contatti.
			if (this.isNewRowAdding) {
				console.log(this.newObject);
				this.contattiService.createContatti(this.newObject)
					.subscribe(
						response => {
							this.toastrService.success("Successfully created");
							this.onApplyFilter();
							this.newObjectAddModal.hide();
							this.clearForm();
						},
						error => {
							this.toastrService.error("Unexpected error");
							console.log(error);
						}
					);
			}
			else {
				// Updating an exxisting contatti.
				this.contattiService.updateContatti(this.newObject)
					.subscribe(
						response => {
							this.toastrService.success("Successfully updated");
							this.onApplyFilter();
							this.newObjectAddModal.hide();
							this.newObjectAddForm.submitted = false;
						},
						error => {
							this.toastrService.error("Unexpected error");
							console.log(error);
						}
					);
			}

		}
		else {
			this.toastrService.error("Invalid form data");
		}
	}

	onAziendeChange() {
		this.allSedeAziende = [];
		var azId = this.newObject.contAzId;
		if (azId) {
			this.contattiService.getSedeAziende(azId)
				.subscribe(
					response => {
						this.allSedeAziende = response;
					},
					error => {
						console.log(error);
					}
				);
		}
	}

	// Clear contatti add form data.
	clearForm() {
		this.newObject = null;
		this.newObject = new Contatti();
		this.newObjectAddForm.submitted = false;
		this.setDefaultDropdownValue();
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
		//this.pullSelectedRowData();
	}

	// Show selected row detail in the modal and
	// save current row node.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();

		this.selectedObject = event.data;
		this.rowNode = event.node;
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

	// Open send email form modal when send email button is clicked.
	onEmailModalOpened() {
		this.clearEmailSendForm();
		this.emailObject.to = this.selectedObject.contEmail1;
		this.emailModal.show();
		this.emailForm.submitted = false;
	}

	// Send email.
	onSendMail(emailForm) {
		if (emailForm.valid) {
			this.contattiService.sendEmail(this.emailObject).subscribe(
				response => {
					this.toastrService.success("Mail Sent");
					this.emailModal.hide();
				},
				error => {
					this.toastrService.error("Unexpected Error Occured");
					console.log(error);
				});
		}
		else {
			this.toastrService.error("Invalid form data");
		}
	}


	// Clear email send form data.
	clearEmailSendForm() {
		this.emailObject = new Email();
	}



	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
