import { CandidateService } from './../../services/candidate.service';
import { Component, OnDestroy, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { saveAs } from 'file-saver';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, Sorting } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { Risorse } from 'shared/models/risorse';
import { FilterService } from 'shared/services/filters.service';
import { ActivatedRoute } from '@angular/router';
import { RichiesteService } from 'app/administrative/services/richieste.service';
import { RoleManagementService } from 'app/administrative/services/role-management.service';
import { UtentiService } from 'app/administrative/services/user-create.service';
import { forkJoin } from 'rxjs';
import { ModalDirective } from 'ngx-bootstrap';
import { RichiesteListaRisorse } from 'shared/models/richiesteListaRisorse';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'app-candidates',
	templateUrl: './candidates.component.html',
	styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('cvDoc', { static: false }) cvDoc;
	@ViewChild('cvContentModal', { static: false }) cvContentModal: ModalDirective;

	columnName: string = "risorse";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;

	selectedObject: Risorse = new Risorse();

	richiesteListaRisorse: RichiesteListaRisorse = new RichiesteListaRisorse();
	relatedRisorse: Risorse[] = [];
	myPdf: any;
	fileUrl: any;
	showHardSkill: boolean = false;
	showSoftSkill: boolean = false;

	cvContent: string = "";


	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;

	// If true, Add/Edit modal child component will be opened.
	showAddEditModal: boolean = false;
	currentRisId: number = 0;

	userRisId: number = 0;
	userInGestRisProtette: boolean = false;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "ris_citta_possibili",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "ris_competenza_1",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "ris_nome",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: "ris_cognome;ris_email"
		},
		{
			columnName: "ris_protetto",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "ris_id",
			dataType: "number",
			filterType: "not_equal",
			option1: "",
			option2: ""
		}

	];
	defaultSorting: Sorting = {
		columnName: "ris_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();
	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "ris_cli_id"
	};

	sortableColumns: KeyValuePair[] = [];

	// Initiating the grid columns along with attributes
	columnDefs = [
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Nome' :
				((this.loggedInUser.language === 'ENG') ? 'Name' : 'Nombre'),
			valueGetter: function fullName(params) {
				return params.data.risNome + ", " + params.data.risCognome;
			}
		},
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Città Possibili' :
				((this.loggedInUser.language === 'ENG') ? 'Convenient City' : 'Ciudad conveniente'),
			field: "risCittaPossibili"
		},
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Età' :
				((this.loggedInUser.language === 'ENG') ? 'Age' : 'Edad'),
			valueGetter: function fullName(params) {
				return params.data.age > 0 ? params.data.age : "";
			}
		},
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Data/Ora Colloquio' :
				((this.loggedInUser.language === 'ENG') ? 'Interview Date/Hour' : 'Entrevista Fecha/Hora'),
			valueGetter: (param => {
				return this.formatDateTimeString(param.data.risDataColloquio);
			}),
		},
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Competenza Principale' :
				((this.loggedInUser.language === 'ENG') ? 'Main Skill' : 'Habilidad principal'),
			field: "risCompetenza1"
		}
	];

	constructor(
		private richiesteService: RichiesteService,
		private activatedRoute: ActivatedRoute,
		private candidateService: CandidateService,
		private userService: UtentiService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService,
		public sanitizer: DomSanitizer
	) {
		super(filterService, authService, toastrService, translate, "v_risorse_no_allegati");
	}

	onAssignCandidate() {
		this.richiesteListaRisorse.richlistCliId = this.loggedInUser.uteCliId;
		this.richiesteListaRisorse.richlistRichId = this.richId;
		this.richiesteListaRisorse.richlistRisId = this.selectedObject.risId;
		this.richiesteListaRisorse.richlistStato = 2;

		this.candidateService.assignCandidate(this.richiesteListaRisorse)
			.subscribe(
				response => {
					this.toastrService.success("Successfully Assigned candidate");
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);
	}

	nome: string;
	cognome: string;
	citta: string;
	comp: string;
	richId: string;

	ngOnInit() {
		this.logPageOpenTask();

		this.loadLanguageSpecificData();
		this.resetSortingObject();

		this.activatedRoute.queryParams.subscribe(params => {
			this.nome = params.nome;
			this.citta = params.citta;
			this.comp = params.comp;
			this.richId = params.risId;

			this.allFilters[0].option1 = params.citta;
			this.allFilters[1].option1 = params.comp;
			this.allFilters[2].option1 = params.nome;
		});

	}

	// Show all the related risorse/candidate in the detail pane.
	pullRelatedRisorse() {
		this.richiesteService.getRisInfoByRichId(this.richId)
			.subscribe(
				response => {
					this.relatedRisorse = response;
				},
				error => {
					console.log(error);
				}
			);
	}

	caption: string;
	pageSizeText: string;
	totalRowCount: string;
	applyFilter: string;
	clearText: string;
	addButtonText: string;
	editButtonText: string;

	titleLabel: string;
	nameLabel: string;
	surnameLabel: string;
	birthDateLabel: string;
	phoneLabel: string;
	cityLabel: string;
	emailLabel: string;
	competenzeLabel: string;

	hardSkillButtonText: string;
	softSkillButtonText: string;
	curriculumButttonText: string;

	loadLanguageSpecificData() {

		this.caption = (this.loggedInUser.language === 'ENG') ? 'Candidates' :
			((this.loggedInUser.language === 'ITA') ? 'Risorse' : 'candidatos');

		this.pageSizeText = (this.loggedInUser.language === 'ENG') ? 'Page Size' :
			((this.loggedInUser.language === 'ITA') ? 'Righe per Pagina' : 'Tamaño de página');

		this.totalRowCount = (this.loggedInUser.language === 'ENG') ? 'Total rows count' :
			((this.loggedInUser.language === 'ITA') ? 'Righe Totali' : 'Recuento total de filas');

		this.applyFilter = (this.loggedInUser.language === 'ENG') ? 'Apply' :
			((this.loggedInUser.language === 'ITA') ? 'Cerca' : 'Aplicar');

		this.clearText = (this.loggedInUser.language === 'ENG') ? 'clear' :
			((this.loggedInUser.language === 'ITA') ? 'Rimuovi filtri' : 'clara');

		this.addButtonText = (this.loggedInUser.language === 'ENG') ? 'Add' :
			((this.loggedInUser.language === 'ITA') ? 'Aggiungi' : 'Añadir');

		this.editButtonText = (this.loggedInUser.language === 'ENG') ? 'Edit' :
			((this.loggedInUser.language === 'ITA') ? 'Modifica' : 'Editar');



		this.titleLabel = (this.loggedInUser.language === 'ENG') ? 'Title' :
			((this.loggedInUser.language === 'ITA') ? 'Titolo' : 'Título');

		this.nameLabel = (this.loggedInUser.language === 'ENG') ? 'Name' :
			((this.loggedInUser.language === 'ITA') ? 'Nome' : 'Nombre');

		this.surnameLabel = (this.loggedInUser.language === 'ENG') ? 'Surname' :
			((this.loggedInUser.language === 'ITA') ? 'Cognome' : 'Apellido');

		this.birthDateLabel = (this.loggedInUser.language === 'ENG') ? 'Date of birth' :
			((this.loggedInUser.language === 'ITA') ? 'Data di Nascita' : 'Fecha de nacimiento');

		this.phoneLabel = (this.loggedInUser.language === 'ENG') ? 'Mobile phone' :
			((this.loggedInUser.language === 'ITA') ? 'Cellulare' : 'Teléfono móvil');

		this.cityLabel = (this.loggedInUser.language === 'ENG') ? 'Convenient city' :
			((this.loggedInUser.language === 'ITA') ? 'Città Possibili' : 'Ciudad conveniente');

		this.emailLabel = (this.loggedInUser.language === 'ENG') ? 'Email' :
			((this.loggedInUser.language === 'ITA') ? 'Email' : 'Email');

		this.competenzeLabel = (this.loggedInUser.language === 'ENG') ? 'Skills' :
			((this.loggedInUser.language === 'ITA') ? 'Competenze' : 'Habilidades');


		this.softSkillButtonText = (this.loggedInUser.language === 'ENG') ? 'Soft Skill' :
			((this.loggedInUser.language === 'ITA') ? 'Soft Skill' : 'Soft Skill');

		this.hardSkillButtonText = (this.loggedInUser.language === 'ENG') ? 'Hard Skill' :
			((this.loggedInUser.language === 'ITA') ? 'Hard Skill' : 'Hard Skill');

		this.curriculumButttonText = (this.loggedInUser.language === 'ENG') ? 'Curriculum' :
			((this.loggedInUser.language === 'ITA') ? 'Curriculum' : 'Curriculum');



	}

	filterClear() {
		this.clearAllFilters();
		this.isFilterCleared = true;
	}

	// Calling the grid
	onGridReady(params) {
		forkJoin(
			this.userService.getUserIsInAuth(this.loggedInUser.uteId, "GestRisProtette"),
			this.userService.getUser(this.loggedInUser.uteId)
		).subscribe(
			response => {
				this.userInGestRisProtette = response[0].status;
				this.userRisId = +response[1].uteRisId;
				this.resetFilterDefaultValues();
				this.setfilterSortingModelData();
				this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
			}
		);
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
		this.resetFilterDefaultValues();
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
		this.selectedObject = new Risorse();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}

	resetFilterDefaultValues() {
		this.allFilters[3].option1 = this.userInGestRisProtette ? '' : 'N';
		this.allFilters[4].option1 = this.userRisId.toString();
	}

	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();
		this.selectedObject = event.data;
		this.clearCvFileInput();
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
						this.selectedObject = rowNode.data;
					}
				});
			}
			else if (keyCode == KEY_DOWN) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index == rowIndex + 1) {
						// this.rowNode = rowNode;
						this.selectedObject = rowNode.data;
					}
				});
			}
			this.clearCvFileInput();
		}
		// this.pullSelectedRowData();
	}

	private clearCvFileInput() {
		if (this.cvDoc) {
			this.cvDoc.nativeElement.value = null;
		}
	}



	// On curriculum button click download CV document.
	onGetCV() {
		saveAs('/api/Risorse/GetRisorseCV/' + this.selectedObject.risId);
	}

	// Open the job offer modal of job-offer child component.
	onGetHardSkill() {
		this.showHardSkill = true;
	}

	// Close job offer modal of job-offer child component.
	onHardSkillModalClose(event) {
		this.showHardSkill = false;
	}

	// Open the job offer modal of job-offer child component.
	onGetSoftSkill() {
		this.showSoftSkill = true;
	}

	// Close job offer modal of job-offer child component.
	onSoftSkillModalClose(event) {
		this.showSoftSkill = false;
	}



	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAddNew() {
		// this.toastrService.warning("Not implemented yet");
		// return;
		this.isNewRowAdding = true;
		this.currentRisId = this.selectedObject !== null ? this.selectedObject.risId : 0;
		this.showAddEditModal = true;
	}

	// Click event of the Edit button
	onEditClick() {
		// this.toastrService.warning("Not implemented yet");
		// return;
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;
		if (this.selectedObject !== null) {
			this.currentRisId = this.selectedObject.risId;
			this.showAddEditModal = true;
		}
		else {
			this.toastrService.warning("Please select one before edit!!");
		}
	}

	onAddEditComplete(event: Risorse) {
		this.showAddEditModal = false;
		if (event !== null) {
			this.onApplyFilter();
		}
	}


	// Upload the CV document.
	upload(files) {
		if (files.length === 0)
			return;

		if (files[0].size > 5 * 1024 * 1024) {
			this.toastrService.warning("Max acceptable file size 5 MB");
			return;
		}
		this.candidateService.upload(this.selectedObject.risId, files[0])
			.subscribe(
				response => {
					this.toastrService.success("Upload successful");
					this.clearCvFileInput();
				},
				error => {
					this.toastrService.error(error.error);
					this.clearCvFileInput();
				}
			);
	}

	scanCv() {
		this.cvContent = "";
		this.candidateService.scanCv(this.selectedObject.risId)
			.subscribe(
				response => {
					if (response.cvContent.length > 0) {
						this.cvContent = response.cvContent;
						this.cvContentModal.show();
					}
					else {
						this.toastrService.error("CV not uploaded yet!");
					}
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);
	}


	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
