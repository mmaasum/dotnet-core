import { KeyValuePair } from 'shared/models/key-value-pair';
import 'shared/_extensions/string-extension';

import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { UtentiService } from 'app/administrative/services/user-create.service';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin, Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { AppliedFilter } from 'shared/models/applied-filter';
import { FilterSortingModel } from 'shared/models/filter-sorting-model';
import { GridFiltriMaster } from 'shared/models/grid-filtri-master';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { MasterFilterCustomTemplate } from 'shared/models/master-filter-custom-temp';
import { MasterFilterFields } from 'shared/models/master-filter-fields';
import { UtentiOptimized } from 'shared/models/utenti-optimized';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

import { DifferentFilterTypeWrapper, MasterFilterTemplate } from '../../models/master-filter-temp';

@Component({
	selector: 'app-filter-management',
	templateUrl: './filter-management.component.html',
	styleUrls: ['./filter-management.component.css'],
	providers: [FilterService]
})
export class FilterManagementComponent implements OnInit, OnChanges {

	@Input() gridName: string;
	@Input() isFilterSaveable: boolean;
	@Input() isFilterCleared: boolean;
	@Input() appliedFilterInGrid: string;
	@Input() appliedSortingInGrid: string;
	@Input() appliedFilterIdInGrid: number;
	@Input() showBindedButtons: boolean;
	@Input() filterSortingModel: FilterSortingModel;


	@Output() filterChangeEvent = new EventEmitter<MasterFilterTemplate>();
	@Output() allFiltersClearEvent = new EventEmitter<string>();
	@Output() testFilterApplyEvent = new EventEmitter<MasterFilterTemplate>();

	@ViewChild('filterManagementModal', { static: false }) filterManagementModal: ModalDirective;
	@ViewChild('filterManagementForm', { static: false }) filterManagementForm: HTMLFormElement;

	allPageFiltersForButton: MasterFilterCustomTemplate[] = [];
	allPageFiltersForButtonInEditModal: MasterFilterCustomTemplate[] = [];
	allPageFiltersForDdl: MasterFilterTemplate[] = [];
	selectedFilterId: number = 0;
	selectedFilterName: string = "";

	setAsDefault: boolean = false;
	masterFilterTemplate: MasterFilterTemplate = new MasterFilterTemplate();
	tempMasterFilterTemplate: MasterFilterTemplate = new MasterFilterTemplate();

	allPrivateFilters: GridFiltriMaster[] = [];
	buttonLabelBeforeEdit: string;
	isButtonCreatable: boolean = false;
	isPageFiltersCleared: boolean = false;

	showButtonResetConfirmation: boolean = false;
	showDeleteFilterConfirmation: boolean = false;
	buttonResetMessage: string = "";

	inEditMode: boolean = false;
	isSameAuthor: boolean = true;

	bsDateConfig = {
		dateInputFormat: 'DD/MM/YYYY',
		rangeInputFormat: 'DD/MM/YYYY',
		useUtc: false,
		showWeekNumbers: false,
		isAnimated: true,
		containerClass: 'theme-default',
		customTodayClass: 'custom-today-class'
	};

	loggedInUser: ILoggedInUser;
	hasPublicSavePermission: boolean = false;
	allUsers: UtentiOptimized[];

	filterFields: MasterFilterFields[] = [];
	sortingFields: MasterFilterFields[] = [];

	numberConditions: KeyValuePair[] = [];
	dateConditions: KeyValuePair[] = [];
	stringConditions: KeyValuePair[] = [];
	userConditions: KeyValuePair[] = [];
	listConditions: KeyValuePair[] = [];

	filter1ConditionsList: KeyValuePair[] = [];
	filter2ConditionsList: KeyValuePair[] = [];
	filter3ConditionsList: KeyValuePair[] = [];

	appliedFilters: AppliedFilter[] = [
		{ field: "", condition: "", value: "", type: "", dateRangeValue: [], rowCount: -1 },
		{ field: "", condition: "", value: "", type: "", dateRangeValue: [], rowCount: -1 },
		{ field: "", condition: "", value: "", type: "", dateRangeValue: [], rowCount: -1 }
	];

	appliedSorting: KeyValuePair[] = [
		{ key: "", value: "S", description: "S" },
		{ key: "", value: "S", description: "S" }
	];
	

	// Variables for list type filters dropdown list
	filter1DropdownListValue: KeyValuePair[] = [];
	filter2DropdownListValue: KeyValuePair[] = [];
	filter3DropdownListValue: KeyValuePair[] = [];




	binded_button: string = "";



	constructor(
		private authService: AuthService,
		private toastrService: ToastrService,
		private filterService: FilterService,
		private utenteService: UtentiService,
		private translate: TranslateService
	) {
		this.hasPublicSavePermission = this.authService.userIsInAuth("Talent.HavePublicFilterAccess");
	}

	ngOnInit() {
		this.loggedInUser = this.authService.currentUserObject;
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'filter']);


		this.pullAllFiltersForButtons();
		this.pullAllFiltersForDropdownList(true);
		this.getFilterSortingFields();
		this.setDefaultValues();
		this.loadUsersList();
		this.loadListTypeFilterValues();
		this.loadLanguageSpecificFilterConditions();
	}


	ngOnChanges() {
		console.log(this.gridName);
		this.selectedFilterId = this.appliedFilterIdInGrid;
		this.setFilterNameInDropdown();
	}

	private loadLanguageSpecificFilterConditions() {
		this.translate.get('filter.usrmsg_info')
			.subscribe(
				tran => {

					this.numberConditions = [
						{ key: "equal", value: tran.L7529_equal },
						{ key: "lower", value: tran.L7543_lower },
						{ key: "greater", value: tran.L7544_greater },
						{ key: "lowerorequal", value: tran.L7545_lowerorequal },
						{ key: "greaterorequal", value: tran.L7546_greaterorequal }
					];
					this.dateConditions = [
						{ key: "before", value: tran.L7538_before },
						{ key: "after", value: tran.L7539_after },
						{ key: "sameorbefore", value: tran.L7540_sameorbefore },
						{ key: "sameorafter", value: tran.L7541_sameorafter },
						{ key: "empty", value: tran.L7527_empty },
						{ key: "notempty", value: tran.L7528_notempty },
						{ key: "range", value: tran.L7542_range }
					];
					this.stringConditions = [
						{ key: "contains", value: tran.L7532_contains },
						{ key: "notcontains", value: tran.L7533_notcontains },
						{ key: "begins", value: tran.L7534_begins },
						{ key: "notbegins", value: tran.L7535_notbegins },
						{ key: "finish", value: tran.L7536_finish },
						{ key: "notfinishes", value: tran.L7537_notfinishes },
						{ key: "empty", value: tran.L7527_empty, description: "no" },
						{ key: "notempty", value: tran.L7528_notempty, description: "no" }
					];
					this.userConditions = [
						{ key: "empty", value: tran.L7527_empty, description: "no" },
						{ key: "notempty", value: tran.L7528_notempty, description: "no" },
						{ key: "equal", value: tran.L7529_equal },
						{ key: "notequal", value: tran.L7530_notequal },
						{ key: "me", value: tran.L7531_me }
					];
					this.listConditions = [
						{ key: "empty", value: tran.L7527_empty, description: "no" },
						{ key: "notempty", value: tran.L7528_notempty, description: "no" },
						{ key: "equal", value: tran.L7529_equal },
						{ key: "notequal", value: tran.L7530_notequal }
					];



				}
			)
	}


	// Load all the user list.
	loadUsersList() {
		this.utenteService.getOptimizedUsersList("A")
			.subscribe(
				(response: UtentiOptimized[]) => {
					this.allUsers = response;
				}
			)
	}

	// Get all the filter fields and sorting fields.
	private getFilterSortingFields() {
		forkJoin(
			this.filterService.getAllPageFields(this.gridName, 'filter'),
			this.filterService.getAllPageFields(this.gridName, 'sort')
		).subscribe(
			response => {
				this.filterFields = response[0];
				this.sortingFields = response[1];
				
				console.log("Filter fields => ");
				console.log(this.filterFields);
			}
		)
	}





	// This method is executed on Clear filter button click.
	// Set the selectedd filter in all filters dropdown list to null.
	// Emit all filter clear event, this event calls the clearAllFilters() of parent component
	// which subsequently cears all applied filters in the grid.
	onClearAllFilters() {
		this.selectedFilterId = 0;
		this.resetFilterNameInDropdown();
		this.allFiltersClearEvent.emit();
	}



	////////////////=====================//////////======================//////////////////
	//                      FILTER DROPDOWN LIST CHANGE EVENTS BEGIN                     //
	////////////////=====================//////////======================//////////////////

	// Gets all the filters for dropdown list.
	pullAllFiltersForDropdownList(setDefault: boolean) {
		this.filterService.getAllFiltersForDdl(this.gridName)
			.subscribe(
				response => {
					console.log("Dropdoen list => ");
					console.log(response);
					this.allPageFiltersForDdl = response;
					if (setDefault) {
						this.setDefaultFilter();
					}
					this.setFilterNameInDropdown();
				},
				error => {
					console.log(error);
				}
			);
	}


	// Gets all the filters for button list.
	pullAllFiltersForButtons() {
		this.filterService.getAllButtonFilters(this.gridName)
			.subscribe(
				response => {
					console.log("Button list => ");
					console.log(response);
					this.allPageFiltersForButton = response;
				},
				error => {
					console.log(error);
				}
			);
	}


	// Set user specific default filter.
	setDefaultFilter() {
		var filterId = 0;

		if (this.allPageFiltersForDdl.length > 0) {
			var defaultFilters = this.allPageFiltersForDdl.filter(a => a.tntfilFiltropagUteDefault == 'S');
			if (defaultFilters.length > 0) {
				filterId = defaultFilters[0].tntfilFiltropagId;
			}
		}
		this.onFilterChange(filterId);
	}

	// Reset filter name in filter dropdown list.
	private async resetFilterNameInDropdown() {
		this.selectedFilterName = await this.translate.get('filter.usrmsg_info.L7518_userFilterDropdown').toPromise();
	}

	// Set filter name in dropdown list.
	private setFilterNameInDropdown() {
		if (this.selectedFilterId != 0 && this.allPageFiltersForDdl.length > 0) {
			var selectedFilter = this.allPageFiltersForDdl.find(a => a.tntfilFiltropagId == this.selectedFilterId);
			if (selectedFilter != undefined && selectedFilter != null) {
				this.selectedFilterName = selectedFilter.tntfilFiltropagNomeCorto;
			}
		}
		else {
			this.resetFilterNameInDropdown();
		}
	}

	// Set access level name i.e Public/Private according to boolean access level value.
	setAccessLevelNameInAllGridFilters() {
		// Need to reimplement for new model
	}

	// Pull out the filter detail and update the grid on filter dropdown menu change event.
	onFilterChange(filterId: number) {
		if (filterId != 0) {
			this.selectedFilterId = filterId;
			this.setFilterNameInDropdown();
			this.filterService.detail(this.selectedFilterId).subscribe(
				response => {
					console.log("Filter change => ");
					console.log(response);
					this.tempMasterFilterTemplate = response;
					this.filterChangeEvent.emit(response);
				}
			)
		}
		else {
			this.resetFilterNameInDropdown();
		}
	}

	////////////////=====================//////////======================//////////////////
	//                      FILTER DROPDOWN LIST CHANGE EVENTS END                       //
	////////////////=====================//////////======================//////////////////





	////////////////=====================//////////======================//////////////////
	//                      FILTER SETTINGS DROPDOWN LIST BEGIN                          //
	////////////////=====================//////////======================//////////////////

	// On add button (first button), open filter management modal in add mode.
	onAddNewClicked() {
		this.isPageFiltersCleared = true;
		this.setAsDefault = false;
		this.isSameAuthor = true;
		this.isFormSubmitted = false;
		this.binded_button = "";
		if (this.isFilterSaveable) {
			this.masterFilterTemplate = null;
			this.masterFilterTemplate = new MasterFilterTemplate();
			this.setDefaultValues();
			this.resetAppliedFiltersArray();
			this.resetAppliedSortingArray();
			this.setButtonCreatableStatus();
			this.setEditModalButtonsList();
			this.filterManagementModal.show();
			this.inEditMode = false;
		}
	}

	// On edit button (2nd button) click, open filter management modal in edit mode.
	onEditClicked() {
		this.isFormSubmitted = false;
		if (this.selectedFilterId > 0) {

			// If user have no permission to add/edit public filter
			// but selected a public filter in dropdown,
			// then block the user from editing it.
			if (!this.hasPublicSavePermission && this.masterFilterTemplate.tntfilFiltropagPubblico == "S") {
				// Show warning message of not having permission.
				this.toastrService.warning(
					this.translate.instant('filter.usrmsg_err.L1502_noEditPermissionMsg')
				);
			}
			else {
				this.resetAppliedFiltersArray();
				this.resetAppliedSortingArray();


				this.masterFilterTemplate = Object.assign({}, this.tempMasterFilterTemplate);
				this.masterFilterTemplate.tntfilFiltropagModUteId = this.loggedInUser.uteId;
				this.isPageFiltersCleared = this.masterFilterTemplate.tntfilFiltropagPulisciPrecedenti == "S" ? true : false;
				this.setEditModalButtonsList();

				this.filterService.getButtonLabelsAndIfFilterIsDefault(this.selectedFilterId)
					.subscribe(
						response => {
							console.log("Button detail API => ");
							console.log(response);
							this.masterFilterTemplate.tntfilFiltropagUteButtonLabel = response.tntfilFiltropagUteButtonLabel;
							this.masterFilterTemplate.tntfilFiltropagUteDefault = response.tntfilFiltropagUteDefault;
							this.masterFilterTemplate.tntfilFiltropagUteId = response.tntfilFiltropagUteId;
							this.masterFilterTemplate.tntfilFiltropagUteButtonId = response.tntfilFiltropagUteButtonId || 0;

							this.setAsDefault = this.masterFilterTemplate.tntfilFiltropagUteDefault == "S" ? true : false;
							this.buttonLabelBeforeEdit = this.masterFilterTemplate.tntfilFiltropagUteButtonLabel;

							this.setAppliedFilterArrayFromObject();
							this.setAppliedSortingArrayFromObject();

							this.setButtonCreatableStatus();
							this.verifyIfSameAuthor();
							this.filterManagementModal.show();

							this.inEditMode = true;
						},
						error => {
							// Show unexpeccted error message.
							this.toastrService.error(this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg'));
							console.log(error);
						}
					)


			}

		}
		else {
			// Show error message to select a filter.
			this.toastrService.error(this.translate.instant('filter.usrmsg_err.L1501_noFilterMsg'));
		}
	}

	private verifyIfSameAuthor() {
		this.isSameAuthor = this.masterFilterTemplate.tntfilFiltropagInsUteId == this.loggedInUser.uteId;
	}

	// Set add/edit modal button list object value.
	private setEditModalButtonsList() {
		this.allPageFiltersForButtonInEditModal = [];

		this.allPageFiltersForButton.forEach(btn => {
			var obj = Object.assign({}, btn);
			if (obj.tntfilFiltropagUteFiltroPagId == this.masterFilterTemplate.tntfilFiltropagId) {
				obj.tntfilFiltropagUteButtonLabel = "Not assigned";
			}
			this.allPageFiltersForButtonInEditModal.push(obj);
		});

		console.log(this.allPageFiltersForButtonInEditModal);
	}

	// On reset button of add/edit modal.
	// onButtonResetConfirm2(choice: boolean) {
	// 	this.showButtonResetConfirmation = false;
	// 	if (choice) {
	// 		var observable = this.filterService.update(this.masterFilterTemplate)
	// 		this.saveOrUpdateApiCall(observable);
	// 	}
	// }


	// On reset button of add/edit modal.
	onDeleteFilterConfirm(choice: boolean) {
		this.showDeleteFilterConfirmation = false;
		if (choice) {
			if (this.selectedFilterId > 0) {

				// If user have no permission to add/edit public filter
				// but selected a public filter in dropdown,
				// then block the user from deleting it.
				if (!this.hasPublicSavePermission && this.masterFilterTemplate.tntfilFiltropagPubblico == "S") {
					// Show warning message of not having permission.
					this.toastrService.warning(
						this.translate.instant('filter.usrmsg_err.L1503_noDeletePermissionMsg')
					);
				}
				else {
					this.filterService.getNUmberOfButtonsAssignedWithFilter(this.selectedFilterId)
						.subscribe(
							res => {
								console.log(res);
								if (res > 0) {
									this.toastrService.warning(
										this.translate.instant('filter.usrmsg_err.L1504_filterAssignedWithButton')
									);
								}
								else {
									// if (confirm(this.translate.instant('filter.usrmsg_warn.L4501_deleteConfirmation'))) {
										this.filterService.delete(this.selectedFilterId)
											.subscribe(
												() => {
													this.toastrService.success(
														this.translate.instant('common.usrmsg_info.L7012_deleteSuccessMsg', { term: "Filter" })
													);
													this.onClearAllFilters();
													this.pullAllFiltersForButtons();
													this.pullAllFiltersForDropdownList(false);
													this.filterManagementModal.hide();
												}
											);
									// }
								}
							},
							error => {
								console.log(error);
								this.toastrService.error(
									this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg')
								);
							}
						);
	
				}
	
			}
			else {
				// Show error message to select a filter.
				this.toastrService.error(this.translate.instant('filter.usrmsg_err.L1501_noFilterMsg'));
			}
		}
	}


	



	////////////////=====================//////////======================//////////////////
	//                      FILTER SETTINGS DROPDOWN LIST END                            //
	////////////////=====================//////////======================//////////////////




	////////////////=====================//////////======================/////////////
	//                          FILTER SAVING BLOCK BEGIN                           //
	////////////////=====================//////////======================/////////////  

	// Filter field change event.
	onFilterFieldChange(filterNumber: number, setCondition: boolean = true) {
		var selectedField = this.appliedFilters[filterNumber].field;
		var type = "";
		if (selectedField != "") {
			type = this.filterFields.find(f => f.tntfilFiltropagcampoCodice == selectedField).tntfilFiltropagcampoTipo;
		}

		this.appliedFilters[filterNumber].type = type;
		this.appliedFilters[filterNumber].rowCount = -1;

		var conditions: KeyValuePair[] = [];
		switch (type) {
			case "S":
				conditions = this.stringConditions;
				break;
			case "D":
				conditions = this.dateConditions;
				break;
			case "N":
				conditions = this.numberConditions;
				break;
			case "L":
				conditions = this.listConditions;
				break;
			case "U":
				conditions = this.userConditions;
				break;
			default:
				break;
		}

		if (filterNumber == 0) {
			this.filter1ConditionsList = conditions;
		}
		else if (filterNumber == 1) {
			this.filter2ConditionsList = conditions;
		}
		else {
			this.filter3ConditionsList = conditions;
		}

		if (conditions.length > 0 && setCondition) {
			this.appliedFilters[filterNumber].condition = conditions[0].key;
			this.onFilterConditionChange(filterNumber);
		}
		else {
			// this.resetAllOtherNextFilters(filterNumber);
		}



		// If filter type is list, set dropdown list value for the filter
		if(type == "L") {
			this.setListTypeFiltersDropdownList(filterNumber);
		}

		this.appliedFilters[filterNumber].value = "";
		this.appliedFilters[filterNumber].date = null;
		this.appliedFilters[filterNumber].dateRangeValue = [];


	}


	// On delete click show confirm dialog before finally deleting filter.
	onDeleteClicked() {
		this.showDeleteFilterConfirmation = true;
		
	}
	
	// Filter condition change event.
	onFilterConditionChange(filterNo: number, pullRecord: boolean = true) {
		var type = this.appliedFilters[filterNo].type;
		var condition = this.appliedFilters[filterNo].condition;
		var pullableRecord: boolean = false;


		console.log("filter condition change function => filter no- " + filterNo + ", condition - " + condition);

		this.appliedFilters[filterNo].value = "";
		this.appliedFilters[filterNo].date = null;
		this.appliedFilters[filterNo].dateRangeValue = [];
		this.appliedFilters[filterNo].rowCount = -1;


		switch (type) {
			case "S":
				if (condition == "empty" || condition == "notempty") {
					pullableRecord = true;
				}
				break;
			case "D":
				if (condition == "empty" || condition == "notempty") {
					pullableRecord = true;
				}
				break;
			case "L":
				if (condition == "empty" || condition == "notempty") {
					pullableRecord = true;
				}
				break;
			case "U":
				if (condition == "empty" || condition == "notempty") {
					pullableRecord = true;
				}
				else if (condition == "me") {
					this.appliedFilters[filterNo].value = this.loggedInUser.uteId;
					pullableRecord = true;
				}
				break;
			default:
				break;
		}

		// Only reset the following filers, if not in edit mode.
		if (!this.inEditMode) {
			this.resetAllOtherNextFilters(filterNo);
		}


		if (pullableRecord && pullRecord) {
			this.pullRecordCountForFilter(filterNo);
		}
	}

	// Get record count for a filter in add/edit modal.
	pullRecordCountForFilter(filterNo: number) {

		if (this.preFilterObjectPropSetTaskSucceded()) {
			var tempWrapperObject = this.createDifferentFilterWrapperObject();

			this.filterService.getGridDataFromTestModel(tempWrapperObject, 1, 10000, true)
				.subscribe(
					(response: any) => {
						console.log(response);
						this.appliedFilters[filterNo].rowCount = response.totalRecords;
					},
					error => {
						console.log(error);
						this.toastrService.error(
							this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg')
						);
					}
				);
		}

	}

	// Get record count for a filter in add/edit modal after datepicker value change.
	pullRecordCountForFilterWithDate(event:any, filterNo: number) {

		console.log(filterNo);

		if (this.appliedFilters[filterNo].date != null) {
			this.pullRecordCountForFilter(filterNo);
		}
	}

	// Get record count for a filter in add/edit modal after daterangepicker value change.
	pullRecordCountForFilterWithDateRange(evemt : any, filterNo: number) {

		if (this.appliedFilters[filterNo].dateRangeValue != null && this.appliedFilters[filterNo].dateRangeValue.length == 2) {
			this.pullRecordCountForFilter(filterNo);
		}

	}

	// Reset all the filters following the current filter.
	private resetAllOtherNextFilters(filterNumber: number = 0) {
		for (let index = filterNumber + 1; index < this.appliedFilters.length; index++) {
			this.appliedFilters[index].field = "";
			this.appliedFilters[index].type = "";
			this.appliedFilters[index].value = "";
			this.appliedFilters[index].condition = "";
			this.appliedFilters[index].date = null;
			this.appliedFilters[index].dateRangeValue = [];
			this.appliedFilters[index].rowCount = -1;
		}

	}

	// Sorting field change event.
	onSortingChanged(sortingNumber: number) {
		var selectedField = this.appliedSorting[sortingNumber].key;
		var type = "";
		if (selectedField != "") {
			type = this.filterFields.find(f => f.tntfilFiltropagcampoCodice == selectedField).tntfilFiltropagcampoTipo;
		}
		this.appliedSorting[sortingNumber].description = type;

		console.warn(selectedField);
		if(sortingNumber == 0 && selectedField == "") {
			this.appliedSorting[1].key = "";
			this.appliedSorting[1].value = "S";
			this.appliedSorting[1].description = "S";
		}
	}





	// Set the default values of master filter template object.
	private setDefaultValues() {
		this.masterFilterTemplate.tntfilFiltropagId = 0;
		this.masterFilterTemplate.tntfilFiltropagCliId = this.loggedInUser.uteCliId;
		this.masterFilterTemplate.tntfilFiltropagPaginaCodice = this.gridName;
		this.masterFilterTemplate.tntfilFiltropagInsUteId = this.loggedInUser.uteId;
		this.masterFilterTemplate.tntfilFiltropagModUteId = this.loggedInUser.uteId;
		this.masterFilterTemplate.tntfilFiltropagPubblico = "N";

		this.masterFilterTemplate.tntfilFiltropagUteDefault = "N";
		//this.masterFilterTemplate.tntfilFiltropagPulisciPrecedenti = "S";    
	}


	// Reset applied filter array.
	private resetAppliedFiltersArray() {
		this.appliedFilters = null;
		this.appliedFilters = [
			{ field: "", condition: "", value: "", type: "", rowCount: -1 },
			{ field: "", condition: "", value: "", type: "", rowCount: -1 },
			{ field: "", condition: "", value: "", type: "", rowCount: -1 }
		];

		this.filter1ConditionsList = [];
		this.filter2ConditionsList = [];
		this.filter3ConditionsList = [];

		this.filter1DropdownListValue = [];
		this.filter2DropdownListValue = [];
		this.filter3DropdownListValue = [];

	}

	// Reset applied sorting array.
	private resetAppliedSortingArray() {
		this.appliedSorting = null;
		this.appliedSorting = [
			{ key: "", value: "S", description: "S" },
			{ key: "", value: "S", description: "S" }
		];
	}

	// Set appliedFilter array value 
	// from masterFilterTemplate object.
	private setAppliedFilterArrayFromObject() {

		var tempObj = Object.assign({}, this.masterFilterTemplate);
		this.appliedFilters[0].field = tempObj.tntfilFiltropagSelect1FiltropagcampoCodice;
		this.onFilterFieldChange(0, false);

		this.appliedFilters[0].condition = tempObj.tntfilFiltropagSelect1Filtrocond.toLowerCase();
		this.onFilterConditionChange(0, false);

		this.appliedFilters[0].value = tempObj.tntfilFiltropagSelect1Valore;
		if (this.appliedFilters[0].type == "D") {
			this.appliedFilters[0].date = null;
			this.appliedFilters[0].dateRangeValue = [];
			if (this.appliedFilters[0].condition == "range") {
				this.appliedFilters[0].dateRangeValue = this.stringToDateRange(this.appliedFilters[0].value);
			}
			else if (this.appliedFilters[0].value.length == 10) {
				this.appliedFilters[0].date = this.appliedFilters[0].value.toCustomDate();
			}

		}

		if (tempObj.tntfilFiltropagSelect2FiltropagcampoCodice) {
			this.appliedFilters[1].field = tempObj.tntfilFiltropagSelect2FiltropagcampoCodice;
			this.onFilterFieldChange(1, false);
			this.appliedFilters[1].condition = tempObj.tntfilFiltropagSelect2Filtrocond.toLowerCase();
			this.onFilterConditionChange(1, false);
			this.appliedFilters[1].value = tempObj.tntfilFiltropagSelect2Valore;
			if (this.appliedFilters[1].type == "D") {
				this.appliedFilters[1].date = null;
				this.appliedFilters[1].dateRangeValue = [];
				if (this.appliedFilters[1].condition == "range") {
					this.appliedFilters[1].dateRangeValue = this.stringToDateRange(this.appliedFilters[1].value);
					// this.appliedFilters[1].rowCount = 34;
				}
				else if (this.appliedFilters[1].value.length == 10) {
					this.appliedFilters[1].date = this.appliedFilters[1].value.toCustomDate();
				}
			}
		}

		if (tempObj.tntfilFiltropagSelect3FiltropagcampoCodice) {
			this.appliedFilters[2].field = tempObj.tntfilFiltropagSelect3FiltropagcampoCodice;
			this.onFilterFieldChange(2, false);
			this.appliedFilters[2].condition = tempObj.tntfilFiltropagSelect3Filtrocond.toLowerCase();
			this.onFilterConditionChange(2, false);
			this.appliedFilters[2].value = tempObj.tntfilFiltropagSelect3Valore;
			if (this.appliedFilters[2].type == "D") {
				this.appliedFilters[2].date = null;
				this.appliedFilters[2].dateRangeValue = [];
				if (this.appliedFilters[2].condition == "range") {
					this.appliedFilters[2].dateRangeValue = this.stringToDateRange(this.appliedFilters[2].value);
				}
				else if (this.appliedFilters[2].value.length == 10) {
					this.appliedFilters[2].date = this.appliedFilters[2].value.toCustomDate();
				}
			}
		}
	}

	// Set appliedSorting array value 
	// from masterFilterTemplate object.
	private setAppliedSortingArrayFromObject() {
		var tempObj = Object.assign({}, this.masterFilterTemplate);
		if (tempObj.tntfilFiltropagOrder1FiltropagcampoCodice) {
			this.appliedSorting[0].key = tempObj.tntfilFiltropagOrder1FiltropagcampoCodice;
			this.appliedSorting[0].value = tempObj.tntfilFiltropagOrder1Ascending;
			this.onSortingChanged(0);
		}

		if (tempObj.tntfilFiltropagOrder2FiltropagcampoCodice) {
			this.appliedSorting[1].key = tempObj.tntfilFiltropagOrder2FiltropagcampoCodice;
			this.appliedSorting[1].value = tempObj.tntfilFiltropagOrder2Ascending;
			this.onSortingChanged(1);
		}
	}

	// Converrt a daterange string to date array.
	private stringToDateRange(dateRangeString: string) {
		var dates = dateRangeString.split(' - ');
		var dateRange: Date[] = [dates[0].toCustomDate(), dates[1].toCustomDate()];
		return dateRange;
	}

	// COnvert a date array to date range string.
	private dateRangeToString(dates: Date[]) {
		var dateRangeInString = "";
		if (dates != undefined && dates != null && dates.length == 2) {
			dateRangeInString = dates[0].getDatePortion() + " - " + dates[1].getDatePortion();
		}
		return dateRangeInString;
	}

	// Set master filter template Filter and sorting value 
	// from appliedFilter and appliedSorting array.
	private setFilterObjectValueFromFilterArray() {
		if (this.appliedFilters[0].field) {
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltropagcampoCodice = this.appliedFilters[0].field;
			this.masterFilterTemplate.tntfilFiltropagSelect1Filtrocond = this.appliedFilters[0].condition;
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltrocondDatafissa = this.appliedFilters[0].type == "D" ? "S" : "N";

			if (this.appliedFilters[0].type == "D") {
				if (this.appliedFilters[0].condition == "range") {
					this.masterFilterTemplate.tntfilFiltropagSelect1Valore = this.dateRangeToString(this.appliedFilters[0].dateRangeValue);
				}
				else if (this.appliedFilters[0].date == null) {
					this.masterFilterTemplate.tntfilFiltropagSelect1Valore = "";
				}
				else {
					this.masterFilterTemplate.tntfilFiltropagSelect1Valore = this.appliedFilters[0].date.getDatePortion();
				}
			}
			else {
				this.masterFilterTemplate.tntfilFiltropagSelect1Valore = this.appliedFilters[0].value;
			}

			// this.masterFilterTemplate.tntfilFiltropagSelect1Valore = this.appliedFilters[0].type == "D" 
			// ? (this.appliedFilters[0].date == null ? "" : this.appliedFilters[0].date.getDatePortion() )
			// : this.appliedFilters[0].value;
		}
		else {
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltropagcampoCodice = null;
			this.masterFilterTemplate.tntfilFiltropagSelect1Filtrocond = null;
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltrocondDatafissa = null;
			this.masterFilterTemplate.tntfilFiltropagSelect1Valore = null;
		}

		if (this.appliedFilters[1].field) {
			this.masterFilterTemplate.tntfilFiltropagSelect2FiltropagcampoCodice = this.appliedFilters[1].field;
			this.masterFilterTemplate.tntfilFiltropagSelect2Filtrocond = this.appliedFilters[1].condition;
			this.masterFilterTemplate.tntfilFiltropagSelect2FiltrocondDatafissa = this.appliedFilters[1].type == "D" ? "S" : "N";

			if (this.appliedFilters[1].type == "D") {
				if (this.appliedFilters[1].condition == "range") {
					this.masterFilterTemplate.tntfilFiltropagSelect2Valore = this.dateRangeToString(this.appliedFilters[1].dateRangeValue);
				}
				else if (this.appliedFilters[1].date == null) {
					this.masterFilterTemplate.tntfilFiltropagSelect2Valore = "";
				}
				else {
					this.masterFilterTemplate.tntfilFiltropagSelect2Valore = this.appliedFilters[1].date.getDatePortion();
				}
			}
			else {
				this.masterFilterTemplate.tntfilFiltropagSelect2Valore = this.appliedFilters[1].value;
			}
		}
		else {
			this.masterFilterTemplate.tntfilFiltropagSelect2FiltropagcampoCodice = null;
			this.masterFilterTemplate.tntfilFiltropagSelect2Filtrocond = null;
			this.masterFilterTemplate.tntfilFiltropagSelect2FiltrocondDatafissa = null;
			this.masterFilterTemplate.tntfilFiltropagSelect2Valore = null;
		}

		if (this.appliedFilters[2].field) {
			this.masterFilterTemplate.tntfilFiltropagSelect3FiltropagcampoCodice = this.appliedFilters[2].field;
			this.masterFilterTemplate.tntfilFiltropagSelect3Filtrocond = this.appliedFilters[2].condition;
			this.masterFilterTemplate.tntfilFiltropagSelect3FiltrocondDatafissa = this.appliedFilters[2].type == "D" ? "S" : "N";

			if (this.appliedFilters[2].type == "D") {
				if (this.appliedFilters[2].condition == "range") {
					this.masterFilterTemplate.tntfilFiltropagSelect3Valore = this.dateRangeToString(this.appliedFilters[2].dateRangeValue);
				}
				else if (this.appliedFilters[2].date == null) {
					this.masterFilterTemplate.tntfilFiltropagSelect3Valore = "";
				}
				else {
					this.masterFilterTemplate.tntfilFiltropagSelect3Valore = this.appliedFilters[2].date.getDatePortion();
				}
			}
			else {
				this.masterFilterTemplate.tntfilFiltropagSelect3Valore = this.appliedFilters[2].value;
			}
		}
		else {
			this.masterFilterTemplate.tntfilFiltropagSelect3FiltropagcampoCodice = null;
			this.masterFilterTemplate.tntfilFiltropagSelect3Filtrocond = null;
			this.masterFilterTemplate.tntfilFiltropagSelect3FiltrocondDatafissa = null;
			this.masterFilterTemplate.tntfilFiltropagSelect3Valore = null;
		}

		this.masterFilterTemplate.tntfilFiltropagUteDefault = this.setAsDefault ? "S" : "N";

	}

	// Set master filter template Filter and sorting value 
	// from appliedFilter and appliedSorting array.
	private setSortingObjectValueFromSortingArray() {
		if (this.appliedSorting[0].key) {
			this.masterFilterTemplate.tntfilFiltropagOrder1FiltropagcampoCodice = this.appliedSorting[0].key;
			this.masterFilterTemplate.tntfilFiltropagOrder1Ascending = this.appliedSorting[0].value;
		}
		else {
			this.masterFilterTemplate.tntfilFiltropagOrder1FiltropagcampoCodice = null;
			this.masterFilterTemplate.tntfilFiltropagOrder1Ascending = null;
		}

		if (this.appliedSorting[1].key) {
			this.masterFilterTemplate.tntfilFiltropagOrder2FiltropagcampoCodice = this.appliedSorting[1].key;
			this.masterFilterTemplate.tntfilFiltropagOrder2Ascending = this.appliedSorting[1].value;
		}
		else {
			this.masterFilterTemplate.tntfilFiltropagOrder2FiltropagcampoCodice = null;
			this.masterFilterTemplate.tntfilFiltropagOrder2Ascending = null;
		}


	}


	// Set is external filter clear property of master filter template object 
	// from isPageFiltersCleared property.
	private setClearPageFilterFlag() {
		this.masterFilterTemplate.tntfilFiltropagPulisciPrecedenti = this.isPageFiltersCleared ? "S" : "N";
	}

	// Set filter value as lgged in user id for user type filter and me condition.
	private setFilterDataWithUserConditions() {
		this.appliedFilters.forEach(elem => {
			if (elem.type == "U" && elem.condition == "me") {
				elem.value = this.loggedInUser.uteId;
			}
		});
	}


	// Set filter object property before add/edit submit.
	private preFilterObjectPropSetTaskSucceded() {
		this.setFilterDataWithUserConditions();
		this.setClearPageFilterFlag();

		// Validate filter array data type of inserted value...

		if (this.validateAppliedFilterArray()) {
			this.setFilterObjectValueFromFilterArray();
			this.setSortingObjectValueFromSortingArray();
			return true;
		}

		return false;
	}


	private validateAppliedFilterArray(): boolean {
		
		for (var i = 0; i < 3; i++) {

			var filter = this.appliedFilters[i];			
			var filterNo = (i + 1).toString();
			var maxStringLength = "100";

			if (filter.field) {
				switch (filter.type) {
					case "S":
						if ((filter.condition == "contains" || filter.condition == "contains" || filter.condition == "begins" || filter.condition == "notbegins" || filter.condition == "finish" || filter.condition == "notfinishes") && !filter.value) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1505_emptyValueFilter',  { filterNo: filterNo })
							)
							return false;
						}
						else if(filter.value && filter.value.length > 100) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1506_largeStringFilter',  { filterNo: filterNo, maxCharacter : maxStringLength })
							)
							return false;
						}

						break;
					case "D":
						if ((filter.condition == "before" || filter.condition == "after" || filter.condition == "sameorbefore" || filter.condition == "sameorafter") && filter.date == null) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1507_emptyDateFilter',  { filterNo: filterNo })
							)
							return false;
						}
						else if (filter.condition == "range" && (filter.dateRangeValue == null || filter.dateRangeValue.length != 2)) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1508_emptyDateRangeFilter',  { filterNo: filterNo })
							)
							return false;
						}
						break;
					case "N":	
						if(!filter.value) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1505_emptyValueFilter',  { filterNo: filterNo })
							)
							return false;
						}
						else if(isNaN(+filter.value)) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1509_noNumberFilter',  { filterNo: filterNo })
							)
							return false;
						}
						break;
					case "L":
						if ((filter.condition == "equal" || filter.condition == "notequal") && !filter.value) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1505_emptyValueFilter',  { filterNo: filterNo })
							)
							return false;
						}
						break;
					case "U":
						if ((filter.condition == "equal" || filter.condition == "notequal") && !filter.value) {
							this.toastrService.error(
								this.translate.instant('filter.usrmsg_err.L1510_noUserFilter',  { filterNo: filterNo })
							)
							return false;
						}
						break;
					default:
						break;
				}
			}
		}
		return true;
	}


	// Filter management form submit event.
	onFilterManagementFormSubmit(type) {
		if (type == undefined) {
			return;
		}
		else if (type == "duplicate") {
			this.masterFilterTemplate.tntfilFiltropagId = 0;
			this.masterFilterTemplate.tntfilFiltropagInsUteId = this.loggedInUser.uteId;
			this.masterFilterTemplate.tntfilFiltropagModUteId = this.loggedInUser.uteId;
			this.filterSaveTask(false);
		}
		else if (type == "saveAndApply") {
			this.filterSaveTask(true);
		}
		else {
			this.filterSaveTask(false);
		}
	}


	showCloseErrorDialog = false;
	errorMessage = "";

	// Validate current filter object.
	private get isFilterObjectValid() {
		var isFormValid = true;
		var isAnyFilterSelected = false;
		if (this.masterFilterTemplate.tntfilFiltropagSelect1FiltropagcampoCodice ||
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltropagcampoCodice ||
			this.masterFilterTemplate.tntfilFiltropagSelect1FiltropagcampoCodice) {
			isAnyFilterSelected = true;
		}
		var isAnySortingSelected = false;
		if (this.masterFilterTemplate.tntfilFiltropagOrder1FiltropagcampoCodice ||
			this.masterFilterTemplate.tntfilFiltropagOrder2FiltropagcampoCodice) {
			isAnySortingSelected = true;
		}

		if (isAnyFilterSelected || isAnySortingSelected) {
			isFormValid = true;
		}
		else {
			isFormValid = false;
			this.toastrService.error(this.translate.instant('filter.usrmsg_warn.L4505_noFilterSorting'))
			// this.showCloseErrorDialog = true;
			// this.errorMessage = ;
		}


		// Assigned button check.
		// If user entered a button label but not chose any button,
		// Show an error message
		if (this.masterFilterTemplate.tntfilFiltropagUteButtonLabel && !this.masterFilterTemplate.tntfilFiltropagUteButtonId) {
			isFormValid = false;
			this.toastrService.error(this.translate.instant('filter.usrmsg_warn.L4506_removeButtonLabel'));
		}

		return isFormValid;


	}



	doApplyFilter: boolean = true;
	isFormSubmitted: boolean = false;

	// Filter save task.
	private filterSaveTask(doApply: boolean) {

		this.doApplyFilter = doApply;
		this.isFormSubmitted = true;


		if (this.preFilterObjectPropSetTaskSucceded()) {
			if (this.isFilterObjectValid) {
				if (this.filterManagementForm.valid) {

					console.log('Before finally saving => ');

					// If user assigned a button
					// But forget to enter a button label,
					// Then assign the 'Name in list' as button label
					if (
						this.masterFilterTemplate.tntfilFiltropagUteButtonId != null &&
						this.masterFilterTemplate.tntfilFiltropagUteButtonId != 0
					) {
						if (!this.masterFilterTemplate.tntfilFiltropagUteButtonLabel) {
							this.masterFilterTemplate.tntfilFiltropagUteButtonLabel = this.masterFilterTemplate.tntfilFiltropagNomeCorto;
						}
					}


					this.masterFilterTemplate.tntfilFiltropagUteButtonId = this.masterFilterTemplate.tntfilFiltropagUteButtonId || 0;
					console.log(this.masterFilterTemplate);


					var observable: Observable<any>;

					// If filter id == 0, then new filter. Hence set ovservale to save method.
					if (this.masterFilterTemplate.tntfilFiltropagId == 0) {
						observable = this.filterService.save(this.masterFilterTemplate);
					}
					// Filter has previous button label, but the label is removed, 
					// show confirmation dialog asking user if s/he wants to proceed or not.
					else if (!this.masterFilterTemplate.tntfilFiltropagUteButtonLabel && this.buttonLabelBeforeEdit) {
						this.buttonResetMessage = this.translate.instant('filter.usrmsg_warn.L4503_buttonRemoveWarning');
						this.showButtonResetConfirmation = true;
					}
					// Else old filter, Hence set ovservale to update method.
					else {
						observable = this.filterService.update(this.masterFilterTemplate);
					}

					// Finally save/update filter.
					if (observable != undefined) {
						this.saveOrUpdateApiCall(observable);
					}
				}
				else {
					this.toastrService.error(this.translate.instant('common.usrmsg_err.L0203_invalidFormData'));
				}
			}
		}


	}


	// On reset button of add/edit modal.
	onButtonResetConfirm(choice: boolean) {
		this.showButtonResetConfirmation = false;
		if (choice) {
			var observable = this.filterService.update(this.masterFilterTemplate)
			this.saveOrUpdateApiCall(observable);
		}
	}

	

	// Final api call for add/edit filter.
	private saveOrUpdateApiCall(observable: Observable<any>) {
		observable.subscribe(
			response => {
				if (this.doApplyFilter) {
					this.selectedFilterId = +response;
					this.masterFilterTemplate.tntfilFiltropagId = this.selectedFilterId;

					// For next edit purpose, save the sate to tempMasterFilterTemplate object.
					this.tempMasterFilterTemplate = Object.assign({}, this.masterFilterTemplate);
					this.filterChangeEvent.emit(this.masterFilterTemplate);
				}
				this.afterFilterSaveTasks();
			},
			error => {
				// Show unexpeccted error message.
				this.toastrService.error(this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg'));
				console.log(error);
			}
		);
	}


	// Post filter saving actions
	// add new filter with the filter name dropdown list if 
	// saved filter access level and global access level are same,
	// clear all filters from the grid,
	// clear filter save model in the modal.
	private afterFilterSaveTasks() {
		this.filterManagementModal.hide();
		this.toastrService.success(
			this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg', { term: "Filter" })
		);
		this.masterFilterTemplate = null;
		this.masterFilterTemplate = new MasterFilterTemplate();

		this.pullAllFiltersForButtons();
		this.pullAllFiltersForDropdownList(false);

		this.setDefaultValues();
		this.isFormSubmitted = false;
	}

	////////////////=====================//////////======================/////////////
	//                          FILTER SAVING BLOCK END                             //
	////////////////=====================//////////======================/////////////




	// Filter button change event.
	onCustomButtonChange() {
		this.onFilterChange(this.selectedFilterId);
	}

	// Set button creatable status for a specific user.
	private setButtonCreatableStatus() {
		console.log('inside button creatable status check => ' + this.masterFilterTemplate.tntfilFiltropagId);
		var assignedButtonCount = 0;
		if (this.allPageFiltersForButton) {
			this.allPageFiltersForButton.filter(a => a.tntfilFiltropagUteFiltroPagId > 0).length;
		}
		console.log('assigned buttons => ' + assignedButtonCount);
		if (this.masterFilterTemplate.tntfilFiltropagId > 0) {
			if (this.masterFilterTemplate.tntfilFiltropagUteButtonLabel) {
				this.isButtonCreatable = true;
			}
			else if (assignedButtonCount < 4) {
				this.isButtonCreatable = true;
			}
			else {
				this.isButtonCreatable = false;
			}
		}
		else {
			this.isButtonCreatable = assignedButtonCount < 4;
		}
	}

	// Reset button click event of add/edit modal.
	resetBindButton() {

		this.allPageFiltersForButtonInEditModal.forEach(btn => {
			if (btn.tntfilFiltropagUteFiltroPagId == this.masterFilterTemplate.tntfilFiltropagId) {
				btn.tntfilFiltropagUteFiltroPagId = -1;
			}
		})

		this.masterFilterTemplate.tntfilFiltropagUteButtonLabel = "";
		this.masterFilterTemplate.tntfilFiltropagUteButtonId = 0;
	}

	// Test filter button click event.
	onTestFilter() {
		if(this.preFilterObjectPropSetTaskSucceded()) {
			this.testFilterApplyEvent.emit(this.masterFilterTemplate);
		}		
	}






	differentFilterTypeWrapper: DifferentFilterTypeWrapper = new DifferentFilterTypeWrapper();

	// Retuen a different filter type wrapper.
	private createDifferentFilterWrapperObject(): DifferentFilterTypeWrapper {
		var obj: DifferentFilterTypeWrapper = new DifferentFilterTypeWrapper();
		obj.filterSortingDto = this.filterSortingModel;
		obj.masterFilterDto = Object.assign({}, this.masterFilterTemplate);
		return obj;
	}


	/* BIND BUTTON RELATEDD CODES BEGIN */

	isButtonAssigned(): boolean {
		return true;
	}

	//  Binded button click event of add/edit modal.
	onBindButtonClick(btnNo: number) {
		this.masterFilterTemplate.tntfilFiltropagUteButtonId = btnNo + 1;
	}
	/* BIND BUTTON RELATEDD CODES END */


	// Close error dialog modal.
	onErrorDialogConfirm() {
		this.showCloseErrorDialog = false;
	}











	////////////////==============//////////////////===================/////////////
	//																			 ///
	//						LIST TYPE FILTER LOGIC BEGIN						 ///
	//																			 ///
	////////////////==============/////////////////====================/////////////


	loadListTypeFilterValues() {

		switch(this.gridName)  {
			case "azioni" :
				this.loadAzioniListTypeFilterData();
				break;

			case "gestione_termini" :
				this.loadTerminiListTypeFilterData();
				break;

			case "gestione_ruoli" :
				this.loadRoleListTypeFilterData();
				break;

			default : 
				break;
		}
	}

	private setListTypeFiltersDropdownList(filterNumber : number) {
		switch(this.gridName)  {
			case "azioni" :
				this.setAzioniDropdownListForSelectedFilter(filterNumber);
				break;
			case "gestione_termini" :
				this.setTerminiDropdownListForSelectedFilter(filterNumber);
				break;
			case "gestione_ruoli" :
				this.setRoleDropdownListForSelectedFilter(filterNumber);
				break;
			default : 
				break;
		}
	}

	//=================================================
	// 		AZIONI RELATED LOGIC BEGIN
	//=================================================
	azioniActionDescrList : KeyValuePair[] = [];
	azioniActionCategoryDescrList : KeyValuePair[] = [];
	private loadAzioniListTypeFilterData() {
		this.filterService.getAzioniListTypeFilterData()
			.subscribe(
				response => {
					console.log(response);
					this.azioniActionCategoryDescrList = response[0];
					this.azioniActionDescrList = response[1];
				}
			);
	}
	private setAzioniDropdownListForSelectedFilter(filterNumber : number) {
		var listValue: KeyValuePair[] = [];
		switch(this.appliedFilters[filterNumber].field) {
			case "action_type_category_descr" :
				listValue = this.azioniActionCategoryDescrList;
				break;

			case "action_type_descr" :
				listValue = this.azioniActionDescrList;
				break;

			default:
				break;
		}

		if(filterNumber == 0) {
			this.filter1DropdownListValue = listValue;
		}
		else if(filterNumber == 1) {
			this.filter2DropdownListValue = listValue;
		}
		else if(filterNumber == 2) {
			this.filter3DropdownListValue = listValue;
		}
	}
	//================================================
	// 		AZIONI RELATED LOGIC END
	//================================================


	//=================================================
	// 		TERMINI RELATED LOGIC BEGIN
	//=================================================
	terminiStateList : KeyValuePair[] = [];
	terminiTypesList : KeyValuePair[] = [];
	terminiLanguageList : KeyValuePair[] = [];
	private loadTerminiListTypeFilterData() {
		this.filterService.getTerminiListTypeFilterData()
			.subscribe(
				response => {
					console.log(response);
					this.terminiStateList = response[0];
					this.terminiLanguageList = response[1];
					this.terminiTypesList = response[2];
				}
			);
	}
	private setTerminiDropdownListForSelectedFilter(filterNumber : number) {
		var listValue: KeyValuePair[] = [];
		switch(this.appliedFilters[filterNumber].field) {
			case "ter_stato" :
				listValue = this.terminiStateList;
				break;
			case "ter_lingua" :
				listValue = this.terminiLanguageList;
				break;
			case "ter_tipo_termine" :
				listValue = this.terminiTypesList;
				break;
			default:
				break;
		}

		if(filterNumber == 0) {
			this.filter1DropdownListValue = listValue;
		}
		else if(filterNumber == 1) {
			this.filter2DropdownListValue = listValue;
		}
		else if(filterNumber == 2) {
			this.filter3DropdownListValue = listValue;
		}
	}
	//================================================
	// 		TERMINI RELATED LOGIC END
	//================================================


	//=================================================
	// 		RUOLO RELATED LOGIC BEGIN
	//=================================================
	roleCodeList : KeyValuePair[] = [];
	roleNameList : KeyValuePair[] = [];
	roleLanguageList : KeyValuePair[] = [];
	roleStateList : KeyValuePair[] = [];
	roleSystemList : KeyValuePair[] = [];

	private loadRoleListTypeFilterData() {
		this.filterService.getRoleListTypeFilterData()
			.subscribe(
				response => {
					console.log(response);
					this.roleCodeList = response[0];
					this.roleNameList = response[1];
					this.roleLanguageList = response[2];
					this.roleStateList = response[3];
					this.roleSystemList = response[4];
				}
			);
	}
	private setRoleDropdownListForSelectedFilter(filterNumber : number) {
		var listValue: KeyValuePair[] = [];
		switch(this.appliedFilters[filterNumber].field) {
			case "ruoli_utenti.ruolo" :
				listValue = this.roleCodeList;
				break;
			case "ruolodescr_descrizione" :
				listValue = this.roleNameList;
				break;
			case "ruolodescr_lingua" :
				listValue = this.roleLanguageList;
				break;
			case "ruolo_abilitato" :
				listValue = this.roleStateList;
				break;
			case "ruolo_system" :
				listValue = this.roleSystemList;
				break;
			default:
				break;
		}

		if(filterNumber == 0) {
			this.filter1DropdownListValue = listValue;
		}
		else if(filterNumber == 1) {
			this.filter2DropdownListValue = listValue;
		}
		else if(filterNumber == 2) {
			this.filter3DropdownListValue = listValue;
		}
	}
	//================================================
	// 		RUOLO RELATED LOGIC END
	//================================================




	////////////////==============//////////////////===================/////////////
	//																			 ///
	//						  LIST TYPE FILTER LOGIC END						 ///
	//																			 ///
	////////////////==============/////////////////====================/////////////



}
