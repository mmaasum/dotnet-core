import { UtentiService } from './../../services/user-create.service';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { Filter, FilterSortingModel, JoinTable, Sorting } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { Richieste } from 'shared/models/richieste';
import { Risorse } from 'shared/models/risorse';
import { FilterService } from 'shared/services/filters.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RichiesteService } from '../../services/richieste.service';
import { Aziende } from 'shared/models/aziende';
import { forkJoin } from 'rxjs';
import { SediAzienda } from 'shared/models/sedi-aziende';
import { UtentiOptimized } from 'shared/models/utenti-optimized';
import { AziendeClientiFinale } from 'shared/models/aziende-clienti-finale';
import { Contatti } from 'shared/models/contatti';
import { Email } from 'shared/models/email';
import { RichiesteListaRisorse } from 'shared/models/richiesteListaRisorse';
import { TranslateService } from 'shared/services/translate.service';
const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	selector: 'richieste',
	templateUrl: './richieste.component.html',
})
export class RichiesteComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}
	aziende: Aziende[] = [];
	cittas: any;
	sedeForEmail: any;
	contattiForEmail: any;
	aziendeClientiFinale: AziendeClientiFinale[] = [];
	contatti: Contatti[] = [];
	allSedeAziende: SediAzienda[] = [];
	columnName: string = 'richieste';
	isFilterSaveable: true;
	isFilterCleared: boolean = true;
	showJobOffer: boolean = false;
	newObject: Richieste = new Richieste();
	selectedObject: Richieste = new Richieste();
	relatedRisorse: Risorse[] = [];
	richiesteListaRisorse: RichiesteListaRisorse = new RichiesteListaRisorse;
	allRecruiters: UtentiOptimized[] = [];
	private richIdForMatchingRecord: string;
	buttonDisabled: boolean;
	private rowNode: any;
	showCloseConfirmDialog: boolean = false;
	showCloseassigncandidateDialog: boolean = false;
	showCloseinvitaCVDialog: boolean = false;
	selectedContId;
	emailBody: string = 'TBD - JUST INSERT DUMMY  TEXT';
	attachment = null;
	fileToUpload: File = null;
	showFinalClient: boolean = true;
	settimane: string = '';
	cloneMessage: string = '';
	cloneButtonHide: boolean = true;
	risidForEmail;
	rowspanCount: number;
	selectedNumber: number;
	candidateStatus;
	allCompetenza: any;
	statiRichList: any;

	@ViewChild('richiesteForm', { static: false }) formValues;
	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newRichiesteAddModal', { static: false }) newRichiesteAddModal: ModalDirective;
	@ViewChild('editModal', { static: false }) editModal: ModalDirective;
	@ViewChild('cloneModal', { static: false }) cloneModal: ModalDirective;
	@ViewChild('assigncandidateModal', { static: false }) assigncandidateModal: ModalDirective;
	@ViewChild('invitaCVModal', { static: false }) invitaCVModal: ModalDirective;
	@ViewChild('emailRichiesteModal', { static: false }) emailRichiesteModal: ModalDirective;

	richieste: Richieste = new Richieste();

	richProtetteVisibility = false;
	richContinueaVisibility = false;

	richiesteMultiLanguageLable: any;
	richiesteMultiLanguageCommonLable: any;
	// Initiating the grid columns along with attributes
	columnDefs = [];

	registerForm: FormGroup;
	// Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: 'rich_citta',
			dataType: 'text',
			filterType: 'like',
			option1: '',
			option2: ''
		},
		{
			columnName: 'rich_comp_principale',
			dataType: 'text',
			filterType: 'like',
			option1: '',
			option2: ''
		},
		{
			columnName: 'aziende.az_rag_sociale',
			dataType: 'text',
			filterType: 'like',
			option1: '',
			option2: ''
		},
		{
			columnName: 'rich_data',
			dataType: 'datetime',
			filterType: 'equal',
			option1: '',
			option2: ''
		},
		{
			columnName: 'rich_assegnato_ute_id',
			dataType: 'text',
			filterType: 'like',
			option1: '',
			option2: ''
		}
	];

	defaultSorting: Sorting = {
		columnName: 'rich_mod_timestamp DESC',
		type: ''
	};
	sorting: Sorting = new Sorting();

	joinTables: JoinTable[] = [
		{
			joinTableName: 'aziende',
			joinFields: [
				{ baseTableJoinFieldName: 'rich_az_id', joinTableJoinFieldName: 'az_id' },
				{ baseTableJoinFieldName: 'rich_cli_id', joinTableJoinFieldName: 'az_cli_id' }
			]
		}
	];

	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: 'rich_cli_id',
		joinTableQueryDto: {
			joinTable: this.joinTables,
			joinTableRetreivedFields: ['az_rag_sociale']
		}
	};

	sortableColumns: KeyValuePair[] = [];

	constructor(
		private formBuilder: FormBuilder,
		private route: ActivatedRoute,
		private router: Router,
		private richiesteService: RichiesteService,
		private utentiService: UtentiService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, 'richieste');
	}

	emailRichieste() {
		this.invitaCVModal.hide();
		this.emailRichiesteModal.show();
	}



	onCloseAddEditModal() {
		this.showCloseConfirmDialog = true;
	}

	searchRichieste(nome, citt, comp) {
		window.open('/risorse?nome=' + nome.value +
			'&citta=' + citt.value +
			'&comp=' + comp.value +
			'&risId=' + this.selectedObject.richId, '_blank');
	}
	onCloseAssigncandidateModal() {
		this.showCloseassigncandidateDialog = true;
	}

	onCloseinvitaCVModal() {
		this.showCloseinvitaCVDialog = true;
	}

	onassigncandidateDialogConfirm(choice: boolean) {
		if (choice) {
			this.assigncandidateModal.hide();
		}
		this.showCloseassigncandidateDialog = false;
	}

	// Pop up close confirmation modal click event.
	onDialogConfirm(choice: boolean) {
		if (choice) {
			this.blankForm();
			this.newRichiesteAddModal.hide();
		}
		this.showCloseConfirmDialog = false;
	}

	onEditRichiesteData() {
		this.newRichiesteAddModal.hide();
	}


	blankForm() {
		this.registerForm = this.formBuilder.group({
			richCompPrincipale: [''],
			richNumPosizioni: [''],
			richDurata: [''],
			settimane: [''],
			richPriorita: [''],
			richAzId: [''],
			rich_finale: [''],
			rich_cliente_finale: [''],
			rich_azsede_id: [''],
			richContId: [''],
			richCitta: [''],
			richRicercaContinua: [''],
			richCategorieProtette: [''],
			rich_tipo: [''],
			richDescrizione: ['']
		});
	}
	formIniLoad() {
		this.registerForm = this.formBuilder.group({
			richCompPrincipale: ['', Validators.required],
			richNumPosizioni: ['', Validators.required],
			richDurata: [''],
			settimane: [''],
			richPriorita: ['', Validators.required],

			richAzId: [''],
			rich_finale: [''],
			rich_cliente_finale: [''],
			rich_azsede_id: [''],
			richContId: ['', Validators.required],

			richCitta: ['', Validators.required],
			richRicercaContinua: [''],
			richCategorieProtette: ['', Validators.required],
			richTipo: [''],

			richDescrizione: ['', Validators.required]
		});
	}

	ngOnInit() {
		this.formIniLoad();
		this.logPageOpenTask();
		this.richiesteMultiLanguageCommonLable = this.richiesteService.getMultiLanguegeData()
			.subscribe(
				response => {
					this.richiesteMultiLanguageCommonLable = response.multiLanguage.common
					[this.loggedInUser.language.toLowerCase()];
				});
		this.richiesteMultiLanguageLable = this.richiesteService.getMultiLanguegeData()
			.subscribe(
				response => {
					this.richiesteMultiLanguageLable = response.multiLanguage.richieste
					[this.loggedInUser.language.toLowerCase()];
					this.columnDefs = [
						{ headerName: this.richiesteMultiLanguageLable.rich_id, field: 'richId', minWidth: 200 },
						{ headerName: this.richiesteMultiLanguageLable.rich_az_id, field: 'azRagSociale', minWidth: 200 },
						{ headerName: this.richiesteMultiLanguageLable.rich_comp_principale, field: 'richCompPrincipale', minWidth: 150 },
						{ headerName: this.richiesteMultiLanguageLable.rich_citta, field: 'richCitta', minWidth: 100 },
						{
							headerName: this.richiesteMultiLanguageLable.rich_data,
							valueGetter: (param => {
								return this.formatDateTimeString(param.data.richData);
							}),
							minWidth: 180
						},
						{ headerName: this.richiesteMultiLanguageLable.rich_tariffa, field: 'richTariffa' },
						{ headerName: this.richiesteMultiLanguageLable.rich_priorita, field: 'richPriorita' },
						{ headerName: this.richiesteMultiLanguageLable.rich_durata, field: 'richDurata' },
						{ headerName: this.richiesteMultiLanguageLable.rich_num_posizioni, field: 'richNumPosizioni' }];
				},
				error => {
					console.log(error);
				}
			);
		// Perform the tasks that will execute on page load.
		this.buttonDisabled = false;
		this.resetSortingObject();
		this.loadAllRecruiterList();
		// Get users,titles,aziende,company types for contatti add/edit form dropdown list.
		forkJoin(
			this.richiesteService.getAllAziende(),
			this.richiesteService.getFindByAllContattiByContAzSedeId(0),
			this.richiesteService.getCitta(),
			this.richiesteService.getAllCompetenzaByCliId(),
		)
			.subscribe(
				response => {

					this.aziende = response[0];
					this.contatti = response[1];
					this.cittas = response[2];
					this.allCompetenza = response[3];
				},
				error => {
					console.log(error);
				}
			);
		this.newObject.richAzsedeId = 0;
		this.setOrUnsetAssignedToFilterText();
	}




	// If user is redirected from login page, set 5th filter of allFilter text = user name
	// When user is redirected from lofin page url is like 'http://localhost:8789/richieste?type=self'
	// If type = self, then load only the job moffers that are assigned to the logged in user.
	// Otherwise load all the job offers.
	private setOrUnsetAssignedToFilterText() {
		this.route.queryParams
			.subscribe(
				params => {
					if (params.type && params.type === 'self') {
						this.allFilters[4].option1 = this.loggedInUser.uteId;
					}
				},
				error => {
					console.log(error);
				}
			);
	}

	sendEmail() {
		// this.attachment = this.fileToUpload;
		// ~~~~~~~~~~~~~~~~~~~~
		const email = new Email();
		email.body = this.emailBody;
		email.attachment = this.fileToUpload;
		this.richiesteService.sendEmail(this.selectedContId, this.risidForEmail, email)
			.subscribe(
				response => {
					this.toastrService.success('Email Sent Successfully');
					this.newRichiesteAddModal.hide();
					this.onApplyFilter();
				},
				error => {
					console.log(error);
				}
			);

	}
	handleFileInput(files: FileList) {
		this.fileToUpload = files.item(0);
	}
	attachFile() {
	}
	onsettimaneChange(val) {
		this.settimane = val;
		this.settimane = this.registerForm.value['rich_durata'] + ' ' + this.registerForm.value['settimane'];
	}
	saveRichieste() {
		if (this.registerForm.valid) {
			if (this.registerForm.value.richId) {
				this.richiesteService.editRichieste(this.registerForm.value)
					.subscribe(
						response => {
							this.toastrService.success('Successfully updated richieste');
							this.newRichiesteAddModal.hide();
							this.onApplyFilter();
						},
						error => {
							console.log(error);
						}
					);
			} else {
				this.richiesteService.insertRichieste(this.registerForm.value)
					.subscribe(
						response => {
							// this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
							this.toastrService.success('Successfully created new richieste');
							this.newRichiesteAddModal.hide();
							this.onApplyFilter();
						},
						error => {
							console.log(error);
						}
					);
			}
			this.selectedObject = this.registerForm.value;
			this.blankForm();
		}
	}
	onCloneRichieste(formVal) {
		if (formVal.richId == null) {
			this.cloneButtonHide = false;
			this.cloneMessage = 'Please select a richieste to clone.';
			this.cloneModal.show();
		} else {
			this.cloneButtonHide = true;
			this.cloneMessage = 'Are you sure to clone this richieste.';
			this.cloneModal.show();
		}
	}
	assignCandidate() {
		this.assigncandidateModal.show();
	}

	invitaCV(risid) {
		this.risidForEmail = risid;
		forkJoin(
			this.richiesteService.getSedeForEmail(this.selectedObject.richAzId),
			this.richiesteService.getContattiForEmail(this.selectedObject.richAzId),
		)
			.subscribe(
				response => {
					this.sedeForEmail = response[0];
					this.contattiForEmail = response[1];
				},
				error => {
					console.log(error);
				}
			);

		this.invitaCVModal.show();
	}
	cloneRichieste() {

		this.richiesteService.cloneRichieste(this.selectedObject.richId)
			.subscribe(
				response => {
					this.toastrService.success('Successfully cloned richieste');
					this.onApplyFilter();
					this.cloneModal.hide();
				},
				error => {
					this.toastrService.success('Error occured.');
					this.cloneModal.hide();
					this.onApplyFilter();
				}
			);
		this.blankForm();
	}

	onEditRichieste(formVal) {

		if (formVal.richId == null) {
			// alert('Please select a richieste to edit.')
			this.editModal.show();
		} else {
			this.newRichiesteAddModal.show();
			this.registerForm = this.formBuilder.group({
				richId: [formVal.richId, Validators.required],
				richCompPrincipale: [formVal.richCompPrincipale, Validators.required],
				richNumPosizioni: [formVal.richNumPosizioni, Validators.required],
				richDurata: [formVal.richDurata],
				settimane: [formVal.settimane],
				richPriorita: [formVal.richPriorita, Validators.required],

				richAzId: [formVal.richAzId],
				rich_finale: [formVal.rich_finale],
				rich_cliente_finale: [6],
				rich_azsede_id: [''],
				richContId: [formVal.richContId, Validators.required],

				richCitta: [formVal.richCitta, Validators.required],
				richRicercaContinua: [formVal.richRicercaContinua],
				richCategorieProtette: [formVal.richCategorieProtette, Validators.required],
				richTipo: [formVal.richTipo],
				richCliId: [formVal.richCliId, Validators.required],
				richDescrizione: [formVal.richDescrizione, Validators.required]
			});
		}
	}
	onFinalClientChange(val, azid) {
		this.showFinalClient = (val === 'S') ? true : false;

		if (val === 'S') {
			this.richiesteService.getOptimizedAziendeClientiFinaleByAzId(azid)
				.subscribe(
					response => {
						this.aziendeClientiFinale = response;
					},
					error => {
						console.log(error);
					}
				);
		} else {
			this.richiesteService.getAllSediAziendeByAzSedeAzId(azid)
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

	onAziendeChange() {
		this.allSedeAziende = [];
		const azId = this.newObject.richAzId;
		if (azId) {
			this.richiesteService.getSedeAziende(azId)
				.subscribe(
					response => {
						this.newObject.richAzsedeId = this.newObject.richAzsedeId ? this.newObject.richAzsedeId : 0;
						this.allSedeAziende = response;
					},
					error => {
						console.log(error);
					}
				);
		}
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
		const value = (<HTMLInputElement>document.getElementById('page-size')).value;
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
		const filterJson = JSON.parse($event.gridfilmaFilterString);
		this.filterSortingModel = filterJson;
		this.allFilters = this.filterSortingModel.filters;
		this.sorting = this.filterSortingModel.sorting;
		const colOrder = JSON.parse($event.gridfilmaSortingString);
		this.gridColumnApi.setColumnState(colOrder);
		this.isFilterCleared = false;
		this.onApplyFilter();
	}

	// On common-grid child component clear button click
	// clear option1 and option2 property of all filter in allFilter array.
	// Reinitialize grid.
	clearAllFilters() {
		this.allFilters.forEach(filter => {
			filter.option1 = '';
			filter.option2 = '';
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
		const sortingData = this.gridColumnApi.getColumnState();
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
		if (this.allFilters.length > 4) {
			this.allFilters[4].option1 = '';
		}
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}
	// Keyboard key event for grid behaviour.
	onCellKeyDown(event: any) {
		const ctrlPressed = event.event.ctrlKey;
		const keyCode = event.event.keyCode;
		const rowIndex = event.rowIndex;
		if (ctrlPressed === false && (keyCode === KEY_UP || keyCode === KEY_DOWN)) {
			if (keyCode === KEY_UP) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index === rowIndex - 1) {
						// this.rowNode = rowNode;
						this.onRowClicked(rowNode);
					}
				});
			} else if (keyCode === KEY_DOWN) {
				this.gridApi.forEachNode((rowNode, index) => {
					if (index === rowIndex + 1) {
						// this.rowNode = rowNode;
						this.onRowClicked(rowNode);
					}
				});
			}
		}
		// this.pullSelectedRowData();
	}
	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();
		const element = document.getElementById('idGrid');
		element.classList.remove('col-md-12');
		element.classList.add('col-md-8');
		this.relatedRisorse = [];
		this.buttonDisabled = true;
		this.selectedObject = event.data;
		this.newObject = Object.assign({}, this.selectedObject);
		if (this.newObject.richAssegnatoUteId) {
			const assignedTo = this.newObject.richAssegnatoUteId;
			this.newObject.richAssegnatoUteId = assignedTo.trim();
		}
		this.rowNode = event.node;
		this.richIdForMatchingRecord = event.data.richId;
		this.richProtetteVisibility = this.selectedObject.richCategorieProtette === 'S';
		this.richContinueaVisibility = this.selectedObject.richRicercaContinua === 'S';
		this.pullRelatedRisorse();
	}
	// Show all the related risorse/candidate in the detail pane.
	pullRelatedRisorse() {
		forkJoin(
			this.richiesteService.getRisInfoByRichId(this.selectedObject.richId),
			this.richiesteService.getStatiRichListRisDescr(),
			this.richiesteService.getCandidateStatusData()
		).subscribe(
			response => {
				this.relatedRisorse = response[0];
				this.statiRichList = response[1];
				this.candidateStatus = response[2].candidateStatus.INVIATO_CV;
				this.rowspanCount = response.length;
			},
			error => {
				console.log(error);
			}
		);
	}

	onStatusChange(richId, risId, statusValue) {
		this.richiesteListaRisorse.richlistRichId = richId;
		this.richiesteListaRisorse.richlistRisId = risId;
		this.richiesteListaRisorse.richlistStato = statusValue.value;

		this.richiesteService.manageTalentRichlistRisorse(this.richiesteListaRisorse)
			.subscribe(
				response => {
					this.toastrService.success('Successfully status updated');
				},
				error => {
					console.log(error);
				}
			);
	}
	/**
   * When found the meching records
   * then redirect to a new window with
   * rechi id
   * @param pageName
   */
	goToPage(pageName: string) {
		const resourceData = this.richiesteService.getMatchingRichieste(this.richIdForMatchingRecord, -1)
			.subscribe(
				(data: any) => {
					if (data.length > 0) {
						window.open(pageName + '?id=' + this.richIdForMatchingRecord + '&option=matching', '_blank');
					} else {
						this.newObjectAddModal.show();
					}
				},
				error => {
					console.log(error);
					this.toastrService.error('Unexpected error occured');
				});
	}
	onNewRichieste() {
		this.newRichiesteAddModal.show();
		this.formIniLoad();
	}
	/**Call this methodt
	 * when click on execute Store Procedure
	 * button, if data is stored using this
	 * store procedure then redirect to
	 * new page otherwise display a popup
	 * message.
	 * */
	executeStoreProcedure() {
		const resourceData = this.richiesteService.launchRisorseSP(this.selectedObject.richId,
			'N', this.loggedInUser.uteCliId)
			.subscribe(
				response => {
					this.newObjectAddModal.hide();
					this.toastrService.info('The store procedure executed please check after 10 min.');
				},
				error => {
					this.newObjectAddModal.hide();
					console.log(`Web service connection error: ${error.error.message}`);
					this.toastrService.error(`Web service connection error: ${error.error.message} \n\n Please communicate with vendor`);

				}
			);
	}

	/**Call this method
	 * when click on execute Machine Learning
	 * button if the data is found
	 * using machine learning the
	 * redirect to the new page otherwise
	 * display a popup message
	 * */
	executeMachineLearning() {
		this.richiesteService.launchLaunchMachineLearning(this.selectedObject.richId)
			.subscribe(
				(data: any) => {
					if (data.length > 0) {
						window.open('matchingrecord?id=' + this.richIdForMatchingRecord + '&hideButton=ya&option=machine',
							'_blank');
					} else {
						this.newObjectAddModal.hide();
						this.toastrService.info('The machine learning procedure did not return any matching profile.');
					}
				},
				error => {
					this.newObjectAddModal.hide();
					console.log(`Web service connection error: ${error.error.message}`);
					this.toastrService.error(`Web service connection error: ${error.error.message} \n\n Please communicate with vendor`);
				});
	}
	// Open the job offer modal of job-offer child component.
	openJobOfferModal() {
		this.showJobOffer = true;
	}

	// Close job offer modal of job-offer child component.
	onJobOfferModalClose(event) {
		this.showJobOffer = false;
	}


	private loadAllRecruiterList() {
		this.utentiService.getAllUtentiByRole('recruiter')
			.subscribe(
				response => {
					this.allRecruiters = response;
				},
				error => {
					console.log(error);
					this.toastrService.error(this.richiesteMultiLanguageCommonLable.unexpectedErrorMsg);
				}
			);
	}

	onRecruiterListChange() {

		this.richiesteService.updateRichieste(this.newObject)
			.subscribe(
				response => {
					this.toastrService.success('Successfully changed assignee');
					this.rowNode.setData(this.newObject);
				},
				error => {
					console.log(error);
					this.toastrService.error(this.richiesteMultiLanguageCommonLable.unexpectedErrorMsg);
				}
			);
	}

	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
