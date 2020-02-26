import { RuoloService } from './../../services/ruolo.service';
import { forkJoin } from 'rxjs';
import { Roles } from 'shared/models/roles';
import { Component, OnInit, Input, ViewChild, OnChanges, Output, EventEmitter } from '@angular/core';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-roles-add-edit',
	templateUrl: './roles-add-edit.component.html',
	styleUrls: ['./roles-add-edit.component.css']
})
export class RolesAddEditComponent implements OnChanges,OnInit {

	@Input() isNewRowAdding: boolean;
	@Input() selectedRole: Roles;

	@Output() taskCompleteEvent = new EventEmitter<boolean>();

	
	@ViewChild('newObjectAddForm', { static: true }) newObjectAddForm: HTMLFormElement;

	loggedInUser: ILoggedInUser;
	selectedObject: Roles = new Roles();


	isFormSubmitted: boolean = false;
	internalAddEditFlag: boolean = true; 		// true for add and false for edit.

	constructor(
		private toastrService: ToastrService,
		private ruoloService: RuoloService,
		private translate: TranslateService,
	) { 
		this.loggedInUser = this.ruoloService.user;	
		console.log(this.loggedInUser);	
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'ruoli']);
	}

	ngOnChanges() {
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    

		if (this.isNewRowAdding) {
			this.onAdd();
			this.internalAddEditFlag = true;
		}
		else {
			this.onEdit();
			this.internalAddEditFlag = false;
		}
		
	}

	ngOnInit() {

	}


	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAdd() {
		// Reinitiate newObject.        
		this.selectedObject = null;
		this.selectedObject = new Roles();
		this.setDefaultPropertty();
		this.isFormSubmitted = false;

		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;

		this.setPermissionAndUserGrid();
		this.group1 = null;
		this.group2 = null;
	}

	// Click event of the Edit button
	onEdit() {
		this.isFormSubmitted = false;

		this.selectedObject.ruoloModUteId = this.loggedInUser.uteId;
		this.selectedObject.ruoloAbilitato = this.selectedObject.ruoloAbilitato == null ? "" : this.selectedObject.ruoloAbilitato;
		this.selectedObject.ruolodescrLingua = this.selectedObject.ruolodescrLingua == null ? "" : this.selectedObject.ruolodescrLingua;
		this.selectedObject.ruoloSystem = this.selectedObject.ruoloSystem == null ? "" : this.selectedObject.ruoloSystem;
		this.selectedObject = this.selectedRole;

		this.setPermissionAndUserGrid();
		this.getUsersForRole();
	}

	onDeleteClicked() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}


	onLanguageChange() {

		// If form is in edit mode and selected language is not empty
		// fetch the role detail...
		if(!this.internalAddEditFlag && this.selectedObject.ruolodescrLingua != "") {
			this.ruoloService.detail(this.selectedObject)
				.subscribe(
					response => {
						console.log(response);

						this.selectedObject.ruolodescrDescrizione = response.ruolodescrDescrizione;
						this.selectedObject.ruolodescrDescrizioneBreve = response.ruolodescrDescrizioneBreve;
						this.selectedObject.ruolodescrDescrizioneEstesa = response.ruolodescrDescrizioneEstesa;
					},
					error => {
						console.log(error);
					}
				)
		}
	}


	private getUsersForRole() {
		this.group1 = null;
		this.group2 = null;

		forkJoin(
			this.ruoloService.getAllPermissionsForRole(this.selectedObject.ruolo),
			this.ruoloService.getAllUsersForRole(this.selectedObject.ruolo)
		).subscribe(
			response => {
				console.log(response);
				this.group1 = response[0];
				this.group2 = response[1];
				this.gridApiPermission.sizeColumnsToFit();
				this.gridApiUsers.sizeColumnsToFit();
			},
			error => {
				console.log(error);
			}
		)
	}

	private setDefaultPropertty() {
		this.selectedObject.ruoloInsUteId = this.loggedInUser.uteId;
		this.selectedObject.ruoloModUteId = this.loggedInUser.uteId;
		this.selectedObject.ruoloCliId = this.loggedInUser.uteCliId;
		this.selectedObject.ruolodescrLingua = this.loggedInUser.language;
		this.selectedObject.ruoloInsTimestamp = new Date();
		this.selectedObject.ruoloAbilitato = "S";
		this.selectedObject.ruoloSystem = "N";
		this.selectedObject.noOfPermission = 0;
		this.selectedObject.noOfActiveUser = 0;
	}



	onNewObjectAddFormSubmit() {

		console.log(this.selectedObject);
		this.isFormSubmitted = true;

		// Check if form is in valid state or not
		if(this.newObjectAddForm.valid) {

			if(this.internalAddEditFlag) {
				console.log('Adding..');
				this.ruoloService.add(this.selectedObject)
					.subscribe(
						response => {
							this.onTaskComplete();
							console.log(response);
							this.toastrService.success(
								this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg', {term : ""})
							);
							
							this.internalAddEditFlag = false;
							this.isFormSubmitted = false;
						},
						error => {
							this.customErrorHandle(error);
						}
					);
			}

			else {
				console.log('Updating..');
				this.ruoloService.update(this.selectedObject)
					.subscribe(
						response => {
							this.onTaskComplete();
							console.log(response);
							this.toastrService.success(
								this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg', {term : ""})
							);

							this.isFormSubmitted = false;
						},
						error => {
							this.customErrorHandle(error);
						}
					);
			}
		}
		else {
			this.toastrService.error(
				this.translate.instant('common.usrmsg_err.L0203_invalidFormData')
			);
		}
		
	}

	onTaskComplete() {
		this.taskCompleteEvent.emit(true);
	}

	private customErrorHandle(error) {
		console.log(error);
		if(error.status == 400 && error.error.code) {
			this.toastrService.error(
				this.translate.instant('ruoli.usrmsg_err.' + error.error.code)
			);
		}
		else {
			this.toastrService.error(
				this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg')
			);
		}
	}

	

	//=============================================================
	//				PERMISSION AND USER GRID LOGIC BEGIN
	//=============================================================

	group1 : any;
	group2 : any;

	gridApiPermission: any;
	gridApiUsers: any;
	
	gridColumnApiPermission: any;
	gridColumnApiUsers: any;


	colDefPermissions = [
		{ headerName: "Permissions", field: "customDataString" }
	];

	colDefUsers = [
		{ headerName: "Users", field: "customDataString" }
	];

	defaultColDef = {      
		sortable: true,
		filter: true
	};

	private async setPermissionAndUserGrid() {
		var permissionTitle = await this.translate.get('ruoli.usrmsg_info.L07368_noOfPermissionTitle', {count : this.selectedObject.noOfPermission}).toPromise();
		var userTitle = await this.translate.get('ruoli.usrmsg_info.L07369_noOfUserTitle', {count : this.selectedObject.noOfActiveUser}).toPromise();
		this.colDefPermissions = [
			{ 
				headerName: permissionTitle, 
				field: "customDataString" 
			}
		];
		this.colDefUsers = [
			{ 
				headerName: this.selectedObject.noOfActiveUser.toString() + " active user(s) with role",
				field: "customDataString" 
			}
		];
	}

	onPermissionGridReady(params) {
		this.gridApiPermission = params.api;
		this.gridColumnApiPermission = params.columnApi;   
	}

	onUserGridReady(params) {
		this.gridApiUsers = params.api;
		this.gridColumnApiUsers = params.columnApi;   
	}


	//=============================================================
	//				PERMISSION AND USER GRID LOGIC END
	//=============================================================




	openPermissionModal() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

	onResetUserClicked() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

}
