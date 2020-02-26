import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { RoleManagementService } from 'app/administrative/services/role-management.service';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, Sorting } from 'shared/models/filter-sorting-model';
import { Risorse } from 'shared/models/risorse';
import { UserRoleAuths } from 'shared/models/UserRoleAuths';
import { Utenti } from 'shared/models/utenti';
import { FilterService } from 'shared/services/filters.service';

import { UtentiService } from '../../services/user-create.service';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'user-create',
	templateUrl: './user-create.component.html',
	styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('usercreateForm', { static: false }) formValues;
	@ViewChild('emailModal', { static: false }) emailModal: ModalDirective;
	@ViewChild('emailForm', { static: false }) emailForm: HTMLFormElement;

	columnName: string = "utenti";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;
	clearText: string;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "ute_id",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "ute_nome",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "ute_ruolo",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		}
	];
	sorting: Sorting = {
		columnName: "ute_mod_timestamp DESC",
		type: ""
	};
	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "ute_cli_id"
	};

	attivo: any;
	allAuths: UserRoleAuths[] = [];
	is_edit: boolean = false;
	user: Utenti = new Utenti();
	clients: any;
	ruolos: any;
	titoli: any;
	filiali: any;
	checked: string;
	searchNome: string = "";
	searchCogNome: string = "";
	allRisorse: Risorse[] = [];
	selectedRisId: number = 0;
	public show: boolean = false;
	public text: string = 'save';
	public params: any;
	emailModalOpened: string;

	ID: string = (this.loggedInUser.language === 'ENG') ? 'ID' : ((this.loggedInUser.language === 'ITA') ? 'ID' : 'ID');;
	Password: string = (this.loggedInUser.language === 'ENG') ? 'Password' : ((this.loggedInUser.language === 'ITA') ? 'Parola dordine' : 'Contraseña');;
	Ruolo: string = (this.loggedInUser.language === 'ENG') ? 'Role' : ((this.loggedInUser.language === 'ITA') ? 'Ruolo' : 'Papel');;
	Nome: string = (this.loggedInUser.language === 'ENG') ? 'First name' : ((this.loggedInUser.language === 'ITA') ? 'Nome' : 'Nombre');;
	Profilo: string = (this.loggedInUser.language === 'ENG') ? 'Profile' : ((this.loggedInUser.language === 'ITA') ? 'Profilo' : 'Perfil');;
	Email: string = (this.loggedInUser.language === 'ENG') ? 'Email' : ((this.loggedInUser.language === 'ITA') ? 'Email' : 'Email');;
	Telefono: string = (this.loggedInUser.language === 'ENG') ? 'User Create' : ((this.loggedInUser.language === 'ITA') ? 'Telefono' : 'Teléfono');;
	Altririferimenti: string = (this.loggedInUser.language === 'ENG') ? 'Other references' : ((this.loggedInUser.language === 'ITA') ? 'Altri riferimenti' : 'Otras Referencias');;
	IdRisorsaprotetta: string = (this.loggedInUser.language === 'ENG') ? 'Id Protected resource' : ((this.loggedInUser.language === 'ITA') ? 'Id Risorsa protetta' : 'ID de recurso protegido');;
	//
	Attivo: string = (this.loggedInUser.language === 'ENG') ? 'Active' : ((this.loggedInUser.language === 'ITA') ? 'Attivo' : 'Activo');;
	Titolo: string = (this.loggedInUser.language === 'ENG') ? 'Title' : ((this.loggedInUser.language === 'ITA') ? 'Titolo' : 'Título');;
	Sede: string = (this.loggedInUser.language === 'ENG') ? 'Seat' : ((this.loggedInUser.language === 'ITA') ? 'Sede' : 'Asiento');;
	AltriRiferimenti: string = (this.loggedInUser.language === 'ENG') ? 'First name' : ((this.loggedInUser.language === 'ITA') ? 'Altri Riferimenti' : 'Nombre');;
	EmailInvio: string = (this.loggedInUser.language === 'ENG') ? 'Profile' : ((this.loggedInUser.language === 'ITA') ? 'Email Invio' : 'Perfil');;
	UtentigestitiRapportini: string = (this.loggedInUser.language === 'ENG') ? 'Email' : ((this.loggedInUser.language === 'ITA') ? 'Utenti gestiti Rapportini' : 'Email');;
	VPN: string = (this.loggedInUser.language === 'ENG') ? 'User Create' : ((this.loggedInUser.language === 'ITA') ? 'VPN' : 'Teléfono');;
	selectedRisorseLabel: string = (this.loggedInUser.language === 'ENG') ? 'Candidate' : ((this.loggedInUser.language === 'ITA') ? 'Risorsa' : 'Risorsa');;
	authorizatiopnLabel: string = (this.loggedInUser.language === 'ENG') ? 'Authorizations' : ((this.loggedInUser.language === 'ITA') ? 'Autorizzazioni' : 'Autorización ');
	buttonName: string = (this.loggedInUser.language === 'ENG') ? 'Add new' : ((this.loggedInUser.language === 'ITA') ? 'Aggiungi nuovo' : 'Añadir nuevo');
	saveButtonText: string = (this.loggedInUser.language === 'ENG') ? 'Save' : ((this.loggedInUser.language === 'ITA') ? 'Salvare' : 'Salvar');
	cancelButtonText: string = (this.loggedInUser.language === 'ENG') ? 'Cancel' : ((this.loggedInUser.language === 'ITA') ? 'Annulla' : 'Cancelar');


	columnDefs = [

		{ headerName: "ID", field: "uteId", sortable: true, filter: true, resizable: true },


		// { headerName: "Password", field: "utePassword", sortable: true, filter: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Parola dordine' :
				((this.loggedInUser.language === 'ENG') ? 'Password' : 'Contraseña'),
			field: "utePassword", sortable: true, filter: true, resizable: true
		},
		// { headerName: "Nome", field: "uteNome", sortable: true, filter: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Nome' :
				((this.loggedInUser.language === 'ENG') ? 'Name' : 'Nombre'),
			field: "uteNome", sortable: true, filter: true, resizable: true
		},
		//{ headerName: "Ruolo", field: "uteRuolo", sortable: true, filter: true, resizable: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Ruolo' :
				((this.loggedInUser.language === 'ENG') ? 'Role' : 'Papel'),
			field: "uteRuolo", sortable: true, filter: true, resizable: true
		},
		//{ headerName: "Attivo", field: "uteAttivo", sortable: true, filter: true, resizable: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Attivo' :
				((this.loggedInUser.language === 'ENG') ? 'Active' : 'Activo'),
			field: "uteAttivo", sortable: true, filter: true, resizable: true
		},
		//{ headerName: "Titolo", field: "uteTitolo", sortable: true, filter: true, resizable: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Titolo' :
				((this.loggedInUser.language === 'ENG') ? 'Title' : 'Título'),
			field: "uteTitolo", sortable: true, filter: true, resizable: true
		},
		// { headerName: "Email ", field: "uteMail", sortable: true, filter: true, resizable: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Email' :
				((this.loggedInUser.language === 'ENG') ? 'Email' : 'Email'),
			field: "uteMail",
			sortable: true,
			filter: true,
			resizable: true,
			cellRenderer: param => {
				if (param.value)
					return `<a href="mailto:${param.value}">${param.value}</a>`;
			}
		},

		//{ headerName: "Altri riferimenti", field: "uteAltriRiferimenti", sortable: true, filter: true },
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Altri riferimenti' :
				((this.loggedInUser.language === 'ENG') ? 'Other References' : 'Otras Referencias'),
			field: "uteAltriRiferimenti", sortable: true, filter: true, resizable: true
		}
	];


	constructor(
		private utentiService: UtentiService,
		private roleManagementService: RoleManagementService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "utenti");
	}

	// Initiating fomm values
	ngOnInit() {
		this.logPageOpenTask();
		this.loadLanguageSpecificData();

		this.utentiService.getAllAuthHavingUtenti(this.user.uteId, this.user.uteCliId)
			.subscribe(
				response => {
					this.allAuths = response;
				},
				error => {
					console.log(error);
				}
			);

		// this.text = 'save';
		this.is_edit = false;
		this.getRoleList();
		this.getClientList();
		this.getTitoliList();
		this.getFilialiList();
		this.getAttivoList();
		this.user.uteRuolo = null;
	}

	caption: string;
	totalRowCount: string;
	pageSizeText: string;
	addMainText: string;
	deleteMainText: string;

	uteIdFilterText: string;
	uteNomeFilterText: string;
	uteRuoloFilterText: string;
	applyFilter: string;

	cancelMainText: string;
	auth: string;
	edit: string;
	loadLanguageSpecificData() {

		this.caption = (this.loggedInUser.language === 'ENG') ? 'User Create' :
			((this.loggedInUser.language === 'ITA') ? 'Crea Utente' : 'Crear Usuario');

		this.totalRowCount = (this.loggedInUser.language === 'ENG') ? 'Total rows count' :
			((this.loggedInUser.language === 'ITA') ? 'Righe Totali' : 'Recuento total de filas');

		this.pageSizeText = (this.loggedInUser.language === 'ENG') ? 'Page Size' :
			((this.loggedInUser.language === 'ITA') ? 'Righe per Pagina' : 'Tamaño de página');

		this.emailModalOpened = (this.loggedInUser.language === 'ENG') ? 'Hide candidate' :
			((this.loggedInUser.language === 'ITA') ? 'Nascondi Risorsa' : 'Añadir recurso protegido');

		this.auth = (this.loggedInUser.language === 'ENG') ? 'Authentic' :
			((this.loggedInUser.language === 'ITA') ? 'Autentico' : 'Auténtico');

		this.cancelMainText = (this.loggedInUser.language === 'ENG') ? 'cancel' :
			((this.loggedInUser.language === 'ITA') ? 'Annulla' : 'cancelar');

		this.edit = (this.loggedInUser.language === 'ENG') ? 'Edit' :
			((this.loggedInUser.language === 'ITA') ? 'Modifica' : 'Editar');

		this.uteIdFilterText = (this.loggedInUser.language === 'ENG') ? 'User Id' :
			((this.loggedInUser.language === 'ITA') ? 'Utente Id' : 'Usuario Id');

		this.uteNomeFilterText = (this.loggedInUser.language === 'ENG') ? 'User Name' :
			((this.loggedInUser.language === 'ITA') ? 'Utente Nome' : 'Usuario Nombre');

		this.uteRuoloFilterText = (this.loggedInUser.language === 'ENG') ? 'Role' :
			((this.loggedInUser.language === 'ITA') ? 'Ruolo' : 'Papel');

		this.applyFilter = (this.loggedInUser.language === 'ENG') ? 'Apply' :
			((this.loggedInUser.language === 'ITA') ? 'Cerca' : 'Aplicar');

		this.clearText = (this.loggedInUser.language === 'ENG') ? 'clear' :
			((this.loggedInUser.language === 'ITA') ? 'Rimuovi filtri' : 'clara');

	}



	filterClear() {
		this.clearAllFilters();
		this.isFilterCleared = true;
	}


	// Dropdown selected index change load role specific auth. 
	filterUteRuolo(filterVal: any) {
		this.clearAllAuth();
		if (filterVal) {
			this.roleManagementService.getAllAuthentications(filterVal)
				.subscribe(
					response => {
						this.allAuths = response;
					},
					error => {
						console.log(error);
					}
				);
		}
	}

	// Role list for dropdown list.
	getRoleList() {
		this.utentiService.getRoleList().subscribe(data => {
			this.ruolos = data;
		});
	}

	getAttivoList() {
		//this.attivo = [{ "Name": "S" }, { "Name": "N" }];
		//this.user.uteAttivo = this.attivo ? this.attivo[1].Name : null;
	}

	getFilialiList() {
		this.utentiService.getGetAllFilialiList().subscribe(data => {
			this.filiali = data;
			this.user.uteSede = this.filiali ? this.filiali[0].filialeCodice : null;
		});
	}


	getTitoliList() {
		this.utentiService.getTitoliList().subscribe(data => {
			this.titoli = data;
			this.user.uteTitolo = this.titoli ? this.titoli[0].titolo : null;
		});
	}
	// Client list for dropdown list.
	getClientList() {
		this.utentiService.getClientList().subscribe(data => {
			this.clients = data;
			//this.initializeDropdownList();
		});
	}

	// To store or modify the data
	save() {

		var authCount = 0;
		this.allAuths.forEach(auth => {
			auth.uteabinsuteid = this.loggedInUser.uteId;
			if (auth.uteabUteId == null) {
				auth.uteabAbilitato = 'N';
			}
			else {
				auth.uteabAbilitato = 'S';
				authCount++;
			}
		});

		if ((this.user.uteRuolo == null || this.user.uteRuolo == "") && authCount == 0) {
			this.toastrService.warning("Please select a role/auth");
			return;
		}


		this.user.utentiAbilitazioniDto = this.allAuths;
		this.user.uteModTimestamp = new Date(Date.now());
		this.user.uteInsTimestamp = new Date(Date.now());
		this.user.uteCliId = this.loggedInUser.uteCliId;

		if (!this.is_edit) {
			if (this.user.uteId == '') {
				this.toastrService.error("uteId is requird");
				return true;
			}
			this.utentiService.createUser(this.user)
				.subscribe(
					data => {
						let newUser = Object.assign({}, this.user);
						this.cancel();
						this.show = false;
						this.setAddNewButtonText();
						this.setSaveUpdateButtonText();
						this.toastrService.success("Successfully created new user");
						this.onApplyFilter();
					},
					err => {
						this.toastrService.error(err.error.message, err.error.error);
					}
				);
		}
		else {
			this.utentiService.updateUser(this.user)
				.subscribe(
					data => {
						this.cancel();
						this.show = false;
						this.setAddNewButtonText();
						this.setSaveUpdateButtonText();
						this.toastrService.success("Successfully updated user");
						this.onApplyFilter();
					},
					err => {
						this.toastrService.error(err.error.message, err.error.error);
					}
				);
		}
	}

	// To visiable and invisiable the list and entry form
	toggle() {

		this.getTitoliList();
		this.getFilialiList();
		this.getRoleList();
		this.user = null;
		this.user = new Utenti();
		this.user.uteRuolo = null;
		this.user.uteAttivo = 'S';
		this.user.uteUsaVpn = 'N';
		// this.getAttivoList();
		this.show = !this.show;

		// CHANGE THE NAME OF THE BUTTON.
		if (this.show) {
			this.setUserListButtonText();
		}
		else {
			this.setAddNewButtonText();
		}
		this.is_edit = false;
		this.setSaveUpdateButtonText();
		this.clearAllAuth();
		// this.showGrid();
	}

	clearAllAuth() {
		this.allAuths.forEach(auth => {
			auth.uteabUteId = null;
		})
	}
	//To eidt the selected user
	toggleEdit() {
		this.show = !this.show;
		// CHANGE THE NAME OF THE BUTTON.
		if (this.show) {
			this.setUserListButtonText();
		}
		else {
			this.setAddNewButtonText();
		}
	}

	// reset the form control
	cancel() {
		//var allRecordsObservable = this.utentiService.getUsersList(this.pageIndex);
		// this.onGridReadyCommonTasks(allRecordsObservable, params, true, false);
		this.user.uteId = null;
		this.toggleEdit();
	}

	// For saveing and updateing the user
	onSubmit(form) {
		if (form.valid) {
			this.save();
		}
		else {
			this.toastrService.error("Invalid form data");
		}
	}


	// disable ute id when update record
	isDisabled(): boolean {
		return this.is_edit;
	}

	// Calling the grid
	onGridReady(params) {
		this.setfilterSortingModelData();
		this.onGridReadyCommonTasks(this.filterSortingModel, params, true, false);
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
		this.user = null;
		this.user = new Utenti();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	// Upload data from ag grid to forms controle to
	// update or delete record
	onRowClicked(event: any) {

		this.colunmsWidthBasedContent();

		this.user = event.data;
		this.is_edit = true;
		this.setSaveUpdateButtonText();
		this.pullSelectedRowData();
		this.searchNome = "";
		this.searchCogNome = "";
		if (this.user.uteRisId) {
			this.utentiService.getRisorseFromRisId(this.user.uteRisId)
				.subscribe(
					(response: Risorse) => {
						this.searchNome = response.risNome;
						this.searchCogNome = response.risCognome;
					}
				);
		}
	}
	colunmsWidthBasedContent() {
		var allColumnIds = [];
		this.gridColumnApi.getAllColumns().forEach(function (column) {
			allColumnIds.push(column.colId);
		});
		this.gridColumnApi.autoSizeColumns(allColumnIds);
	}
	// On checkbox state change, change state of allAuths object.
	onChange(index: number) {
		this.allAuths[index].uteabUteId = this.allAuths[index].uteabUteId
			? null
			: this.user.uteId;

		this.allAuths[index].uteabAbilitato = this.allAuths[index].uteabUteId
			? null
			: this.user.uteId;
	}

	insertRowIntoGrid(newUser: Utenti) {
		this.gridApi.updateRowData({ add: [newUser], addIndex: 0 });
	}

	deleteRowFromGrid() {
		this.gridApi.updateRowData({ remove: [this.user] });
	}

	// Initiating ag grid
	agInit(params: any): void {
		this.params = params;
	}

	// Open send email form modal when send email button is clicked.
	onEmailModalOpened() {
		if (!this.is_edit) {
			this.searchNome = "";
			this.searchCogNome = "";
		}
		this.allRisorse = [];
		this.emailModal.show();
		this.emailForm.submitted = false;
	}

	onRisorseSearch() {
		if (this.searchNome || this.searchCogNome) {
			var searchNome = this.searchNome;
			var searchCogNome = this.searchCogNome;
			if (!this.searchNome) {
				searchNome = "0";
			}
			if (!this.searchCogNome) {
				searchCogNome = "0";
			}
			this.utentiService.getRisorse(searchNome, searchCogNome)
				.subscribe(
					response => {
						console.log(response);
						this.allRisorse = response;
						if (this.allRisorse.length == 0) {
							this.toastrService.warning("Nothing found. Search again!");
						}
					},
					error => {
						console.log(error);
						this.toastrService.error("Unexpected error occured!");
					}
				);
		}
		else {
			this.toastrService.warning("Provide either name or cognome!");
		}
	}

	setRisorseId(val) {
		this.selectedRisId = Number(val);
	}

	onAddRisorseToUtente() {
		if (this.selectedRisId <= 0) {
			this.toastrService.error("Select risorse!");
		}
		else {
			this.user.uteRisId = this.selectedRisId;
			var selectedRisorse = this.allRisorse.find(a => a.risId == this.selectedRisId);
			this.searchNome = selectedRisorse.risNome;
			this.searchCogNome = selectedRisorse.risCognome;
			this.emailModal.hide();
			this.selectedRisId = 0;
			this.allRisorse = [];
		}

	}
	// Ag grid recomanded method 
	refresh(): boolean {
		return false;
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
						// this.rowNode = rowNode;
						this.user = rowNode.data;
					}
				});
			}
			else if (keyCode == KEY_DOWN) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index == rowIndex + 1) {
						// this.rowNode = rowNode;
						this.user = rowNode.data;
					}
				});
			}
		}
		this.pullSelectedRowData();
	}

	// Pull selected row object detail.
	pullSelectedRowData() {
		if (this.user.uteId) {
			this.utentiService.getAllAuthHavingUtenti(this.user.uteId, this.user.uteCliId).subscribe(
				response => {
					this.allAuths = response;
				},
				error => {
					console.log(error);
				}
			);
		}
	}

	// Set add new user button text for different languages.
	setAddNewButtonText() {
		if (this.loggedInUser.language === "ITA") {
			this.buttonName = 'Aggiungi nuovo';
		}
		else if (this.loggedInUser.language === "ENG") {
			this.buttonName = 'Add New';
		}
		else {
			this.buttonName = 'Añadir nuevo';
		}
	}

	// Set User list button text for different languages.
	setUserListButtonText() {
		if (this.loggedInUser.language === "ITA") {
			this.buttonName = 'Lista degli utenti';
		}
		else if (this.loggedInUser.language === "ENG") {
			this.buttonName = 'User List';
		}
		else {
			this.buttonName = 'Lista de usuarios';
		}
	}

	setSaveUpdateButtonText() {
		if (this.is_edit) {
			if (this.loggedInUser.language === "ITA") {
				this.saveButtonText = 'Aggiorna';
			}
			else if (this.loggedInUser.language === "ENG") {
				this.saveButtonText = 'Update';
			}
			else {
				this.saveButtonText = 'Actualizar';
			}
		}
		else {
			if (this.loggedInUser.language === "ITA") {
				this.saveButtonText = 'Salvare';
			}
			else if (this.loggedInUser.language === "ENG") {
				this.saveButtonText = 'Save';
			}
			else {
				this.saveButtonText = 'Salvar';
			}
		}
	}


	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}

}
