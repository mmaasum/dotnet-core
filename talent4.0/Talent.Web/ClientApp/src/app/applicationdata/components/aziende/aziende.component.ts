import { ClienteFinaleService } from '../../services/cliente-finale.service';
import { SediAziendeService } from '../../services/sedi-aziende.service';
import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin, Subject } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { Aziende } from 'shared/models/aziende';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { SediAzienda } from 'shared/models/sedi-aziende';
import { TipiAziende } from 'shared/models/tipi-aziende';
import { Utenti } from 'shared/models/utenti';
import { FilterService } from 'shared/services/filters.service';

import { AziendeService } from '../../services/aziende.service';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { FilterSortingModel, Sorting, Filter } from 'shared/models/filter-sorting-model';
import { AziendeClientiFinale } from 'shared/models/aziende-clienti-finale';
import { SearchService } from 'shared/services/search.service';
import { TranslateService } from 'shared/services/translate.service';
import { MasterFilterTemplate, DifferentFilterTypeWrapper } from 'shared/models/master-filter-temp';

const KEY_UP = 38;
const KEY_DOWN = 40;

@Component({
	templateUrl: './aziende.component.html',
	styleUrls: ['./aziende.component.css']
})
export class AziendeComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;

	columnName: string = "aziende";
	isFilterSaveable: boolean = true;
	isFilterCleared: boolean = true;

	rowSelection = "multiple";
	newObject: Aziende = new Aziende();
	selectedObject: Aziende = new Aziende();
	allSediAziendeOfAziende: SediAzienda[] = [];

	isSecondEmailVisible: boolean = false;
	isSecondPhoneVisible: boolean = false;
	isSedeSelectListVisible: boolean = false;
	isClienteSelectListVisible: boolean = false;
	showCloseConfirmDialog: boolean = false;

	allTipoAziende: TipiAziende[] = [];
	allUtenti: Utenti[] = [];
	allSediAziende: SediAzienda[] = [];
	allClientiFinale: AziendeClientiFinale[] = [];

	// isNewRowAdding -> Add or edit check flag.
	// If Add new is selected, then this variable is set true,
	// Otherwise if Edit is selected, this variable is set to false.
	isNewRowAdding: boolean;
	rowNode: any;
	azId: number = 0;

	// If true, Sede Aziedne Add/Edit modal child component will be opened.
	isSedeAdding: boolean = false;
	showSedeAddEdit: boolean = false;
	currentAzId: number = 0;
	currentSedeAzId: number = 0;
	selectedSedeId: number = 0;



	// If true, Sede Aziedne Add/Edit modal child component will be opened.
	isClienteFinaleAdding: boolean = false;
	showClienteFinaleAddEdit: boolean = false;
	currentClienteFinaleId: number = 0;
	selectedClienteFinaleId: number = 0;


	isNewSedeAdding: boolean = false;
	isNewClienteFinaleAdding: boolean = false;
	isSedeFormVisible: boolean = false;
	isClienteFormVisible: boolean = false;

	newSede: SediAzienda = new SediAzienda();
	newClienteFinale: AziendeClientiFinale = new AziendeClientiFinale();

	// Initiating the grid columns along with attributes
	columnDefs = [];

	// Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "az_rag_sociale",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "az_descrizione",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "az_citta",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "az_tipo_azienda",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		},
		{
			columnName: "az_rag_sociale",
			dataType: "text",
			filterType: "range",
			option1: "A-Z",
			option2: ""
		},
	];
	defaultSorting: Sorting = {
		columnName: "az_rag_sociale ASC",
		type: ""
	};
	sorting: Sorting = new Sorting();
	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "az_cli_id"
	};

	sortableColumns: KeyValuePair[] = [];

	constructor(
		private aziendeService: AziendeService,
		private sediAziendeService: SediAziendeService,
		private clienteFinaleService: ClienteFinaleService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "aziende");
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'aziende', 'filter']);
	}
	multiLanguageLable: any;
	finalClientLable: any;
	sediAziendeLable: any;
	// contattiMultiLanguageCommonLable:any;
	ngOnInit() {
		this.pageSize = 5000;
		this.paginationPageSize = 5000;

		this.logPageOpenTask();

		this.getMultiLanguageCommonLables();

		this.translate.get('aziende.usrmsg_info')
		.subscribe(
			response => {
				this.columnDefs = [
					{
						headerName: response.L7401_companyName,
						field: "azRagSociale",
						headerCheckboxSelection: true,
						checkboxSelection: true,
						minWidth: 200,
						comparator: customComparator
					},
					{ headerName: response.L7403_city, field: "azCitta", minWidth: 200, comparator: customComparator },
					{ 
						headerName: response.L7405_defaultEmail, 
						field: "azEmail1", 
						minWidth: 150, 
						comparator: customComparator,
						cellRenderer : param => {
							if(param.value)
								return `<a href="mailto:${param.value}">${param.value}</a>`;
						}
					},
					{ 
						headerName: response.L7406_defaultPhone, 
						field: "azTelefono1", 
						minWidth: 100,
						cellRenderer : param => {
							if(param.value)
								return `<a href="tel:${param.value}">${param.value}</a>`;
						}
					},
					{ headerName: response.L7407_zipCode, field: "azCap", minWidth: 180 },
					{ headerName: response.L7402_description, field: "azDescrizione", comparator: customComparator }
				];
			}
		)

		// this.multiLanguageLable = this.getMultiLanguegeData()
		// 	.subscribe(
		// 		response => {
		// 			this.multiLanguageLable = response.multiLanguage.aziende
		// 			[this.loggedInUser.language.toLowerCase()];

		// 			this.columnDefs = [
		// 				{
		// 					headerName: this.multiLanguageLable.az_rag_sociale,
		// 					field: "azRagSociale",
		// 					headerCheckboxSelection: true,
		// 					checkboxSelection: true,
		// 					minWidth: 200,
		// 					comparator: customComparator
		// 				},
		// 				{ headerName: this.multiLanguageLable.az_citta, field: "azCitta", minWidth: 200, comparator: customComparator },
		// 				{ headerName: this.multiLanguageLable.az_email_1, field: "azEmail1", minWidth: 150, comparator: customComparator },
		// 				{ headerName: this.multiLanguageLable.az_telefono_1, field: "azTelefono1", minWidth: 100 },
		// 				{ headerName: this.multiLanguageLable.az_cap, field: "azCap", minWidth: 180 },
		// 				{ headerName: this.multiLanguageLable.az_descrizione, field: "azDescrizione", comparator: customComparator }
		// 			];
		// 		},
		// 		error => {
		// 			console.log(error);
		// 		}
		// 	);

		this.finalClientLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.finalClientLable = response.multiLanguage.aziendeClientiFinali
					[this.loggedInUser.language.toLowerCase()];
				},
				error => {
					console.log(error);
				}
			);
		this.sediAziendeLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.sediAziendeLable = response.multiLanguage.sediAziende
					[this.loggedInUser.language.toLowerCase()];
				},
				error => {
					console.log(error);
				}
			);
		this.resetSortingObject();

		// Set aziende types and user dropdownlist value of aziende add/edit form.
		forkJoin(
			this.aziendeService.getAllAziendeTypes(),
			this.aziendeService.getOptimizedUsersList("A")
		).subscribe(
			response => {
				this.allTipoAziende = response[0];
				this.allUtenti = response[1];
			},
			error => {
				console.log(error);
			}
		);
		const customComparator = (valueA, valueB) => {
			if (!valueA) return -1;
			if (!valueB) return 1;
			if (valueA && valueB) {
				return valueA.toLowerCase().localeCompare(valueB.toLowerCase());
			}
		};

		this.setfilterSortingModelData();
		this.loadRadioButtons(this.filterSortingModel);
	}



	onRowSelected($event) {
		var selectedNodes: any[] = this.gridApi.getSelectedNodes();
		if (selectedNodes.length > 0) {
			selectedNodes.forEach(n => {
				console.log(n.data['azId']);
			});
		}
	}

	filterClear() {
		this.clearAllFilters();		
		this.onApplyFilter();
		// this.isFilterCleared = true;
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
		this.pageIndex = 1;
		if (this.appliedFilterIdInGrid > 0) {
			this.loadGridDataFromFilterID(this.filterSortingModel);
		} else {
			this.setfilterSortingModelData();
			this.loadGridDataFromFilterModel(this.filterSortingModel);
		}
	}

	// On filter management child component allFilter dropdown value change 
	// 
	filterChange(filter: MasterFilterTemplate) {

		var tempPageFilter = JSON.parse(JSON.stringify(this.filterSortingModel));

		// If clear all filter is true in global component filter template, 
		// 
		if (filter.tntfilFiltropagPulisciPrecedenti == "S") {
			this.clearAllFilters();
			this.setPageFilterInputsFromFilterObject(filter);
		}

		this.appliedFilterIdInGrid = filter.tntfilFiltropagId;
		this.loadGridDataFromFilterID(tempPageFilter);
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
		// this.isFilterCleared = true;
		// this.onApplyFilter();
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
		if (this.appliedFilterIdInGrid > 0) {
			this.loadGridDataFromFilterID(this.filterSortingModel);
		} else {
			this.onApplyFilter();
		}
	}

	// Initialize the grid according to applied filter data.
	onApplyFilter() {
		this.appliedFilterIdInGrid = 0;
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetFilterDefaultValues() {
		this.allFilters[4].option1 = "A-Z";
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}


	private setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) {

		// Page filter object -> log_ute_id, log_timestamp, log_descr.

		// Mapping first filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect1FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.allFilters[0].option1 = filter.tntfilFiltropagSelect1Valore;
				break;
			default:
				break;
		}

		// Mapping second filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect2FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.allFilters[0].option1 = filter.tntfilFiltropagSelect2Valore;
				break;
			default:
				break;
		}

		// Mapping third filter from filterTemplate to pageFilter
		switch (filter.tntfilFiltropagSelect3FiltropagcampoCodice) {
			case "logoperazioni_user":
				this.allFilters[0].option1 = filter.tntfilFiltropagSelect3Valore;
				break;
			default:
				break;
		}
	}


	//==========================================================//
	//             FILTER COMPONENT ACTIONS BEGIN               //
	//==========================================================//

	onTestFilterApply(testFilter: MasterFilterTemplate) {
		// If clear all filter is true in global component filter template, 
		// 
		if (testFilter.tntfilFiltropagPulisciPrecedenti == "S") {
			this.clearAllFilters();
			this.setPageFilterInputsFromFilterObject(testFilter);
		}
		this.createDifferentFilterWrapperObject(testFilter);
		this.loadGridDataFromTestFilterModel(this.differentFilterTypeWrapper, false);
	}


	differentFilterTypeWrapper: DifferentFilterTypeWrapper = new DifferentFilterTypeWrapper();

	private createDifferentFilterWrapperObject(testFilter: MasterFilterTemplate) {
		this.differentFilterTypeWrapper.filterSortingDto = this.filterSortingModel;
		this.differentFilterTypeWrapper.masterFilterDto = testFilter;

	}

	//==========================================================//
	//             FILTER COMPONENT ACTIONS END                 //
	//==========================================================//


	

	// Set default user id and client id values of newObject.
	// For EDIT only set the modUteId/Modified by.
	// For ADD set modified by,clientId and inserted by.
	setDefaultValue() {
		this.newObject.azModUteId = this.loggedInUser.uteId;
		if (this.isNewRowAdding) {
			this.newObject.azCliId = this.loggedInUser.uteCliId;
			this.newObject.azInsUteId = this.loggedInUser.uteId;
		}
	}

	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAddNew() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);

		// // Set isNewRowAdding value to true as we are adding a new row.
		// this.isNewRowAdding = true; 
		// // Reinitiate newObject.
		// this.newObject = null;
		// this.newObject = new Aziende();  
		// // set Attiva/Active to S so that in the dropdown list it will selected by default.  
		// this.newObject.azAttiva = "S";    
		// // set azId = 0 so that when we check if sigla is unique or not it will compare with all.  
		// this.azId = 0; 
		// this.newObject.azTipoAzienda = null;           
		// this.newObjectAddModal.show();    
		// this.onAddEditModalOpen();

		// this.onTipoChange();

		// // Set submitted property of the form to submitted.
		// // So that when user reopen the modal,
		// // default validation message of previous form submit is not shown.
		// this.newObjectAddForm.submitted = false;
	}

	// Click event of the Edit button
	onEditClick() {
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;

		// Set new object value as selected row of the grid.
		this.newObject = this.selectedObject;

		// Hide sede/cliente finale add form.
		this.isSedeFormVisible = false;
		this.isClienteFormVisible = false;
		this.isSedeFormVisible = false;
		this.isClienteFormVisible = false;


		this.newObjectAddModal.show();
		this.setDefaultDataForEdit();
	}

	// Set some default property of newObject while opening the form for edit.
	setDefaultDataForEdit() {
		// set azId = editable azienda's azId.
		// So that when we check if sigla is unique or not it will not check with itself. 
		this.azId = this.newObject.azId;
		// If editable azienda has secondary email address/phone,
		// then show the secondary email/phone input field.
		// Otherwise hide it and show secondary email/phone add button.
		this.isSecondEmailVisible = this.newObject.azEmail2 == null ? false : true;
		this.isSecondPhoneVisible = this.newObject.azTelefono2 == null ? false : true;

		this.onTipoChange();

		forkJoin(
			this.sediAziendeService.getAllByAzId(this.azId),
			this.clienteFinaleService.getAllByAzId(this.azId)
		).subscribe(
			response => {
				this.allSediAziende = response[0];
				this.allClientiFinale = response[1];
			}
		);

	}

	// Processing azienda data properties before posting to server.
	onNewObjectAddFormSubmit(form) {
		if (this.isSedeFormVisible && !this.newSede.azsedeCitta) {
			this.toastrService.error(
				this.translate.instant('aziende.usrmsg_warn.L4401_provideCity')
			);
			return;
		}

		if (this.isClienteFormVisible && !this.newClienteFinale.clifinLuogoLavoro) {
			this.toastrService.error(
				this.translate.instant('aziende.usrmsg_warn.L4402_provideluogoLavoro')
			);
			return;
		}

		if (form.valid) {
			this.setDefaultValue();

			// If Sigla is not provided, submit the form.
			if (this.newObject.azSiglaRichiesta == null) {
				this.submitAddOrEditForm();
			} else {
				// If sigla is provided check if inputted sigla is unique or not.
				// If unique, submit the form
				// else show not unique warning.
				this.aziendeService.findExistingAziendeBySigla(this.azId, this.newObject.azSiglaRichiesta)
					.subscribe(
						response => {
							if (response != null) {
								this.toastrService.warning(
									this.translate.instant('aziende.usrmsg_warn.L4403_existSiglaMSg')
								);
							} else {
								this.submitAddOrEditForm();
							}
						},
						error => {
							console.log(error);
						}
					);
			}
		} else {
			this.toastrService.error(
				this.translate.instant('common.usrmsg_err.L0203_invalidFormData')
			);
		}
	}

	// Post the form data to server.
	submitAddOrEditForm() {
		// Adding a new azienda.
		if (this.isNewRowAdding) {
			this.aziendeService.createAziende(this.newObject)
				.subscribe(
					response => {
						this.toastrService.success(
							this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg', { term: 'Company' })
						);
						this.onApplyFilter();
						// If sede form is visible, also add a new sede azienda.
						if (this.isSedeFormVisible) {
							this.newSede.azsedeAzId = response.azId;
							this.postSedeAziende();
						}
						// If cliente finale form is visible, also add a new cliente finale.
						else if (this.isClienteFormVisible) {
							this.newClienteFinale.clifinAzId = response.azId;
							this.postClienteFinale();
						}
						// Hide aziende add form modal.
						else {
							this.newObjectAddModal.hide();
						}
						this.clearForm();
					},
					error => {
						this.toastrService.error(
							this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg')
						);
						console.log(error);
					}
				);
		} else {
			// Updating an existing azienda.
			this.aziendeService.updateAziende(this.newObject)
				.subscribe(
					response => {
						this.toastrService.success(
							this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg', { term: 'Company' })
						);
						this.onApplyFilter();
						this.newObjectAddModal.hide();
						this.newObjectAddForm.submitted = false;
					},
					error => {
						this.toastrService.error(
							this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg')
						);
						console.log(error);
					}
				);
		}
	}

	onCloseAddEditModal() {
		// this.showCloseConfirmDialog = true;
		this.newObjectAddModal.hide();
	}

	// Pop up close confirmation modal click event.
	onDialogConfirm(choice: boolean) {
		if (choice) {
			this.newObjectAddModal.hide();
		}
		this.showCloseConfirmDialog = false;
	}

	// Clear form data by reinitiating newObject properties.
	clearForm() {
		this.newObject = null;
		this.newObject = new Aziende();
		this.newObjectAddForm.submitted = false;
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
		this.pullSelectedRowData();
	}

	// Show selected row detail in the modal.
	onRowClicked(event: any) {
		this.colunmsWidthBasedContent();

		// this.selectedObject = event.data;
		// this.rowNode = event.node;
		// this.pullSelectedRowData();
	}

	onCellClicked(event: any) {
		console.log(event);
		if (event.column.colId === "azRagSociale") {
			console.log('matched');
			this.selectedObject = event.data;
			this.rowNode = event.data;
			this.pullSelectedRowData();
			this.onEditClick();
		}
	}

	// Pull selected row object detail.
	pullSelectedRowData() {
		if (this.selectedObject.azId) {
			this.aziendeService.getAllSediAzienda(this.selectedObject)
				.subscribe(
					response => {
						this.allSediAziendeOfAziende = response;
					}
				);
		}
	}

	// Set secondary email and phone n umber visibility status.
	onAddEditModalOpen() {
		this.isSecondEmailVisible = this.newObject.azEmail2 ? true : false;
		this.isSecondPhoneVisible = this.newObject.azTelefono2 ? true : false;
	}

	showSecondEmail() {
		this.isSecondEmailVisible = true;
	}

	showSecondPhone() {
		this.isSecondPhoneVisible = true;
	}

	// On tipo change in add/edit form,
	// show/hide sedi aziende/cliente finale select list.
	onTipoChange() {

		// If add new row, hide both sede aziende and client finale dropdown list.
		this.isClienteSelectListVisible = false;
		this.isSedeSelectListVisible = false;

		this.isNewSedeAdding = false;
		this.isNewClienteFinaleAdding = false;

		this.isSedeFormVisible = false;
		this.isClienteFormVisible = false;

		// If edit, depending on tipo show/hide sede aziende and client finale dropdown list.
		if (!this.isNewRowAdding) {
			var tipo = this.newObject.azTipoAzienda;
			if (!tipo) {
				this.isClienteSelectListVisible = false;
				this.isSedeSelectListVisible = false;
			}
			else if (tipo === "Cliente Finale") {
				this.isClienteSelectListVisible = true;
				this.isSedeSelectListVisible = false;
			}
			else {
				this.isSedeSelectListVisible = true;
				this.isClienteSelectListVisible = false;
			}
		}
		else {
			var tipo = this.newObject.azTipoAzienda;
			if (!tipo) {
				this.isNewSedeAdding = false;
				this.isNewClienteFinaleAdding = false;
			}
			else if (tipo === "Cliente Finale") {
				this.isNewClienteFinaleAdding = true;
				this.isNewSedeAdding = false;
			}
			else {
				this.isNewSedeAdding = true;
				this.isNewClienteFinaleAdding = false;
			}
		}

	}

	// On add/Edit button click of sede aziende
	// open sede aziende add/edit modal/
	onSedeAddEdit() {
		this.showSedeAddEdit = false;
		this.currentAzId = this.azId;
		this.currentSedeAzId = this.selectedSedeId;
		this.isSedeAdding = this.selectedSedeId == 0 ? true : false;
		this.showSedeAddEdit = true;
	}

	// On submit add/edit form of sedi aziende
	// Close sede add/edit modal.
	onSedeAddEditComplete(event: SediAzienda) {
		this.selectedSedeId = 0;
		this.showSedeAddEdit = false;

		if (event != null) {
			// Add newly added sedi aziende to existing dropdown list.
			if (this.isSedeAdding) {
				this.allSediAziende.push(event);
			} else {
				// Update the sedi aziende dropdown list.
				var obj = this.allSediAziende.findIndex(a => a.azsedeId == event.azsedeId);
				this.allSediAziende.splice(obj, 1);
				this.allSediAziende.push(event);
			}
		}

	}

	// On submit add/edit form of cliente finale
	// Open cliente finale add/edit modal.
	onClienteFinaleAddEdit() {
		this.showClienteFinaleAddEdit = false;
		this.currentAzId = this.azId;
		this.currentClienteFinaleId = this.selectedClienteFinaleId;
		this.isClienteFinaleAdding = this.selectedClienteFinaleId == 0 ? true : false;
		this.showClienteFinaleAddEdit = true;
	}

	// On submit add/edit form of cliente finale
	// Close cliente finale add/edit modal.
	onClienteFinaleAddEditComplete(event: AziendeClientiFinale) {
		this.selectedClienteFinaleId = 0;
		this.showClienteFinaleAddEdit = false;

		if (event != null) {
			// Add newly added cliente finale to existing dropdown list.
			if (this.isClienteFinaleAdding) {
				this.allClientiFinale.push(event);
			} else {
				// Update the cliente finale dropdown list.
				var obj = this.allClientiFinale.findIndex(a => a.clifinId == event.clifinId);
				this.allClientiFinale.splice(obj, 1);
				this.allClientiFinale.push(event);
			}
		}
	}


	// During new azienda add, 
	// toogle sede add form when sede button is clicked.
	toggleSedeForm() {
		this.isSedeFormVisible = !this.isSedeFormVisible;
		if (this.isSedeFormVisible) {

			// Reinitiate newSede.
			this.newSede = null;
			this.newSede = new SediAzienda();
			// set Attiva/Active to S so that in the dropdown list it will selected by default.  
			this.newSede.azsedeAttiva = "S";
		}
	}

	// Submit new sede aziende object.
	postSedeAziende() {
		// Set default values before submitting new sede aziende object.
		this.newSede.azsedeModUteId = this.loggedInUser.uteId;
		this.newSede.azsedeLegale = "N";
		this.newSede.azsedeCliId = this.loggedInUser.uteCliId;
		this.newSede.azsedeInsUteId = this.loggedInUser.uteId;
		this.sediAziendeService.create(this.newSede)
			.subscribe(
				response => {
					this.toastrService.success("Sede aziende added successfully!");
					this.newObjectAddModal.hide();
				},
				error => {
					console.log(error);
					this.toastrService.error("Error adding sede aziende");
				}
			);
	}


	// During new azienda add, 
	// toogle cliente finale add form when cliente finale button is clicked.
	toggleClienteFinaleForm() {
		this.isClienteFormVisible = !this.isClienteFormVisible;
		if (this.isClienteFormVisible) {
			// Reinitiate newObject.        
			this.newClienteFinale = null;
			this.newClienteFinale = new AziendeClientiFinale();

			// set Attiva/Active to S so that in the dropdown list it will selected by default.  
			this.newClienteFinale.clifinRaggMezziPubblici = "S";
		}
	}

	// Submit new cliente finale object.
	postClienteFinale() {
		// If adding new data, set inserted by = current user.
		this.newClienteFinale.clifinInsUteId = this.loggedInUser.uteId
		this.newClienteFinale.clifinModUteId = this.loggedInUser.uteId;
		this.newClienteFinale.clifinCliId = this.loggedInUser.uteCliId;

		this.clienteFinaleService.saveClienteFinale(this.newClienteFinale)
			.subscribe(
				response => {
					this.toastrService.success("Cliente finale added successfully!");
					this.newObjectAddModal.hide();
				},
				error => {
					console.log(error);
					this.toastrService.error("Error adding cliente finale");
				}
			);
	}



	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}
