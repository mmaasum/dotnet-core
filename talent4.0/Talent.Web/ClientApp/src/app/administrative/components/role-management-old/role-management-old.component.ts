import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { RoleAuths } from 'shared/models/role-auths';
import { Roles } from 'shared/models/roles';
import { FilterService } from 'shared/services/filters.service';

import { RoleManagementService } from '../../services/role-management.service';
import { Sorting, FilterSortingModel, Filter } from 'shared/models/filter-sorting-model';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { TranslateService } from 'shared/services/translate.service';

const KEY_UP = 38;
const KEY_DOWN = 40;


@Component({
  selector: 'app-role-management-old',
  templateUrl: './role-management-old.component.html',
  styleUrls: ['./role-management-old.component.css']
})
export class RoleManagementOldComponent extends CommonGridBehaviour implements OnInit, OnDestroy {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('confirmationModal', { static: false }) confirmationModal: ModalDirective;
	@ViewChild('addNewModal', { static: false }) addNewModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;

	isNewRowAdding: boolean = true;
	isDelete: boolean = false;

	newObject: Roles = new Roles();
	selectedObject: Roles = new Roles();
	allAuths: RoleAuths[] = [];
	totalUserInRole: number = 0;
	totalAuthsInRole: number = 0;

	columnName: string = "ruoli_utenti";
	isFilterSaveable: boolean = false;
	isFilterCleared: boolean = true;
	showCloseConfirmDialog: boolean = false;

	//Filters and sorting data variables
	allFilters: Filter[] = [
		{
			columnName: "ruolo",
			dataType: "text",
			filterType: "like",
			option1: "",
			option2: ""
		}
	];
	defaultSorting: Sorting = {
		columnName: "ruolo_mod_timestamp DESC",
		type: ""
	};
	sorting: Sorting = new Sorting();
	filterSortingModel: FilterSortingModel = {
		filters: [],
		clientColumn: "ruolo_cli_id"
	};

	sortableColumns: KeyValuePair[] = [];


	public paginationNumberFormatter = function (params) {
		return "[" + params.value.toLocaleString() + "]";
	};

	// Initiating the grid columns along with attributes
	columnDefs = [
		{
			headerName: (this.loggedInUser.language === 'ITA') ? 'Ruolo' :
				((this.loggedInUser.language === 'ENG') ? 'Role' : 'Papel'),
			field: "ruolo", sortable: true, filter: true
		}
	];

	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public filterService: FilterService,
		public translate: TranslateService,
		private roleManagementService: RoleManagementService
	) {
		super(filterService, authService, toastrService, translate, "ruoli_utenti");
	}
	saveText: string;
	authorization: string;
	selected: string;

	ngOnInit() {
		this.logPageOpenTask();
		this.loadLanguageSpecificData();

		this.resetSortingObject();
	}


	caption: string;

	/**
	 * Load the form based on the
	 * login languege
	 * */
	loadLanguageSpecificData() {
		this.caption = (this.loggedInUser.language === 'ENG') ? 'Role Management' :
			((this.loggedInUser.language === 'ITA') ? 'Gestione dei ruoli' : 'Gestión de roles');



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
		this.selectedObject = new Roles();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	resetSortingObject() {
		this.sorting.columnName = this.defaultSorting.columnName;
		this.sorting.type = this.defaultSorting.type;
	}

	// Show related authorizations of row data role.
	onRowClicked(event: any) {
		// var element = document.getElementById("idGrid");
		// element.classList.remove("col-md-12");
		// element.classList.add("col-md-8");

		this.saveText = (this.loggedInUser.language === 'ENG') ? 'save' :
			((this.loggedInUser.language === 'ITA') ? 'salvare' : 'salvar');

		this.authorization = (this.loggedInUser.language === 'ENG') ? 'Authorization' :
			((this.loggedInUser.language === 'ITA') ? 'Autorizzazione' : 'Autorización');

		this.selected = (this.loggedInUser.language === 'ENG') ? 'Selected' :
			((this.loggedInUser.language === 'ITA') ? 'Selezionato' : 'Seleccionado');

		this.selectedObject = event.data;

		this.pullRoleSpecificDetailData();
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
		}
		this.pullRoleSpecificDetailData();
	}

	// Pull 
	// 1. Total users count assigned to role,
	// 2. All the auths with selected by role
	// 3. Total auths count assigned to role
	pullRoleSpecificDetailData() {
		if (this.selectedObject.ruolo) {
			forkJoin(
				this.roleManagementService.getAllAuthentications(this.selectedObject.ruolo),
				this.roleManagementService.getTotalUserInRoleCount(this.selectedObject.ruolo),
				this.roleManagementService.getTotalAuthsInRoleCount(this.selectedObject.ruolo)
			).subscribe(
				response => {
					this.allAuths = response[0];
					this.totalUserInRole = response[1];
					this.totalAuthsInRole = response[2];
				},
				error => {
					console.log(error);
				}
			)
		}
	}

	// Update authorizations of selected role.
	onSubmit() {
		this.confirmationModal.show();
	}

	// On confirmation button click take appropriate action.
	// To change the defined auth list for a role.
	// To change the defined auth list for each user who are having this role. 
	// ( It happens only when userAuthChangedConfirmation is 1(YES)).
	onConfirm(confirmation: boolean) {
		let onlySelectedAuths = [];

		this.allAuths.forEach(element => {
			if (element.uteabUteId) {
				let singleAuth = {
					ruoltipabRuolo: element.uteabUteId,
					ruoltipabUteabProcedura: element.tipoabilitProcedura,
					ruoltipabCliId: this.loggedInUser.uteCliId
				}
				onlySelectedAuths.push(singleAuth);
			}

		});
		let confirmationString = confirmation ? "1" : "0";

		this.roleManagementService.postAuthenticationsOfRole(onlySelectedAuths, confirmationString)
			.subscribe(
				response => {
					this.toastrService.success("Successfully updated");
					this.confirmationModal.hide();
				},
				error => {
					this.toastrService.error("Unexpected error occured");
					console.log(error);
				}
			);
	}

	// On checkbox state change, change state of allAuths object.
	onAuthsChange(index: number) {
		this.allAuths[index].uteabUteId = this.allAuths[index].uteabUteId
			? null
			: this.selectedObject.ruolo;
	}

	/**
	 *Click on addNew button a popup
	 * will apeare. Put the value on the
	 * text box and submit to the server.
	 * */
	onAddNew() {
		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = true;
		this.isDelete = false;

		// Reinitiate newObject.        
		this.newObject = null;
		this.newObject = new Roles();

		this.addNewModal.show();
		this.newObjectAddForm.submitted = false;
	}


	onEditClick() {
		// this.toastrService.warning("Not implemented yet");

		// Set isRowAdding = false as we are editing.
		this.isNewRowAdding = false;
		this.isDelete = false;

		// Set new object value as selected row of the grid.
		this.newObject = Object.assign({}, this.selectedObject);

		this.addNewModal.show();
	}

	onDeleteClick() {
		this.isDelete = true;
		// Set new object value as selected row of the grid.
		this.newObject = Object.assign({}, this.selectedObject);

		this.addNewModal.show();
	}

	//  Submit/delete button click event of object add/edit form.
	onNewObjectAddFormSubmit(form) {
		this.setDefaultValue();

		if (form.valid) {

			if (this.isNewRowAdding && !this.isDelete) {
				// Adding new role
				this.saveRole();
			}
			else if (this.totalAuthsInRole == 0 && this.totalUserInRole == 0 && !this.isDelete) {
				// Updating existing role
				this.updateRole();
			}
			else if (this.totalAuthsInRole == 0 && this.totalUserInRole == 0 && this.isDelete) {
				// Deleting role
				this.deleteRole();
			}
			else {
				// If role is assigned to user or auths
				var msg = "Role assigned to users/auths. <br />Remove the role from users/auths and retry ";
				this.toastrService.warning(msg);
			}
		}
	}

	// Set default values in newObject.
	setDefaultValue() {
		// Modified by is set for both add and update.
		this.newObject.ruoloModUteId = this.loggedInUser.uteId;

		// Created by and client id is set only in add.
		if (this.isNewRowAdding) {
			this.newObject.ruoloInsUteId = this.loggedInUser.uteId;
			this.newObject.ruoloCliId = this.loggedInUser.uteCliId;
		}

	}

	// Save new role.
	saveRole() {
		this.roleManagementService.addNewRole(this.newObject)
			.subscribe(
				response => {
					this.afterSuccessCommonTask("Role added successfully");
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);

	}

	// Update existing role.
	updateRole() {
		this.roleManagementService.updateRole(this.newObject, this.selectedObject.ruolo)
			.subscribe(
				response => {
					this.selectedObject = Object.assign({}, this.newObject);
					this.afterSuccessCommonTask("Role updated successfully");
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);
	}

	// Delete a role.
	deleteRole() {
		this.roleManagementService.deleteRole(this.newObject.ruolo)
			.subscribe(
				response => {
					this.selectedObject = new Roles();
					this.afterSuccessCommonTask("Successfully deleted role");
				},
				error => {
					console.log(error);
					this.toastrService.error("Unexpected error occured");
				}
			);
	}

	afterSuccessCommonTask(msg: string) {
		this.rowData = this.roleManagementService.getAllRoles();
		this.toastrService.success(msg);
		this.addNewModal.hide();
	}

	onCloseClicked() {
		this.showCloseConfirmDialog = true;
	}

	// Pop up close confirmation modal click event.
	onDialogConfirm(choice: boolean) {
		if (choice) {
			this.addNewModal.hide();
		}
		this.showCloseConfirmDialog = false;
	}

	// On page leave log page close task.
	ngOnDestroy() {
		this.logPageCloseTask();
	}
}