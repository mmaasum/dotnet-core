import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { Aziende } from 'shared/models/aziende';
import { AziendeClientiFinale } from 'shared/models/aziende-clienti-finale';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { FilterService } from 'shared/services/filters.service';

import { AziendeService } from './../../services/aziende.service';
import { ClienteFinaleService } from './../../services/cliente-finale.service';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-cliente-finale-add-edit',
	templateUrl: './cliente-finale-add-edit.component.html',
	styleUrls: ['./cliente-finale-add-edit.component.css']
})
export class ClienteFinaleAddEditComponent extends CommonGridBehaviour implements OnChanges, OnInit {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}


	// Input and output variables.
	@Input() azId: number;
	@Input() clienteFinaleId: number;
	@Input() isNewRowAdding: boolean;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<AziendeClientiFinale>();

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;

	//private loggedInUser : ILoggedInUser;
	newObject: AziendeClientiFinale = new AziendeClientiFinale();
	allAziende: Aziende[] = [];
	showCloseConfirmDialog: boolean = false;

	constructor(
		private clienteFinaleService: ClienteFinaleService,
		private aziendeService: AziendeService,
		public toastrService: ToastrService,
		public authService: AuthService,
		public translate: TranslateService,
		public filterService: FilterService
	) {
		super(filterService, authService, toastrService, translate, "aziende");
	}

	ngOnChanges() {
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    
		if (this.showModal) {
			if (this.isNewRowAdding) {
				this.onAdd();
			}
			else if (this.clienteFinaleId > 0) {
				this.onEdit();
			}
			this.newObjectAddModal.show();
		}
		else {
			this.newObjectAddModal.hide();
		}
	}

	clientFinalAddEditLable: any;

	ngOnInit() {
		this.loggedInUser = this.authService.currentUserObject;

		this.aziendeService.getAllTheAziende()
			.subscribe(
				response => {
					this.allAziende = response;
				},
				error => {
					console.log(error);
				}
			);
		this.getMultiLanguageCommonLables();
		this.clientFinalAddEditLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.clientFinalAddEditLable = response.multiLanguage.aziendeClientiFinali
					[this.loggedInUser.language.toLowerCase()];
				},
				error => {
					console.log(error);
				}
			);
	}


	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAdd() {

		// Reinitiate newObject.        
		this.newObject = null;
		this.newObject = new AziendeClientiFinale();
		// set Attiva/Active to S so that in the dropdown list it will selected by default.  
		this.newObject.clifinRaggMezziPubblici = "S";
		this.setAziendeInDropdown();

		this.newObjectAddModal.show();
		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;
	}

	// Click event of the Edit button
	onEdit() {
		// Pull the detail of the provided sede aziende id.
		this.clienteFinaleService.detail(this.clienteFinaleId)
			.subscribe(
				response => {
					this.newObject = response;
					this.newObjectAddModal.show();
				},
				error => {
					console.log(error);
					this.toastrService.error("Invalid Cliente finale Id!!");
				}
			);
	}



	// Processing azienda data properties before posting to server.
	onNewObjectAddFormSubmit(form) {
		if (form.valid) {
			this.setDefaultValue();
			this.submitAddOrEditForm();
		}
		else {
			this.toastrService.error("Invalid form data");
		}
	}


	// Post the form data to server.
	submitAddOrEditForm() {
		// Adding a new azienda.
		if (this.isNewRowAdding) {
			this.clienteFinaleService.saveClienteFinale(this.newObject)
				.subscribe(
					response => {
						this.newObject.clifinId = response;
						this.toastrService.success("Successfully created");
						this.newObjectAddModal.hide();
						this.modalCloseEvent.emit(this.newObject);
						this.clearForm();
					},
					error => {
						this.toastrService.error("Unexpected error");
						console.log(error);
					}
				);
		}
		else {
			// Updating an existing cliente finale.
			this.clienteFinaleService.updateClienteFinale(this.newObject)
				.subscribe(
					response => {
						this.toastrService.success("Successfully updated");
						this.newObjectAddModal.hide();
						this.newObjectAddForm.submitted = false;
						this.modalCloseEvent.emit(this.newObject);
					},
					error => {
						this.toastrService.error("Unexpected error");
						console.log(error);
					}
				);
		}
	}

	// Set selected value in aziende dropdown list.
	setAziendeInDropdown() {
		if (this.azId === 0) {
			this.newObject.clifinAzId = null;
		}
		else {
			this.newObject.clifinAzId = this.azId;
		}
	}

	// Set default values of newObject before add/edit post.
	setDefaultValue() {
		// If adding new data, set inserted by = current user.
		if (this.isNewRowAdding) {
			this.newObject.clifinInsUteId = this.loggedInUser.uteId
		}
		this.newObject.clifinModUteId = this.loggedInUser.uteId;
		this.newObject.clifinCliId = this.loggedInUser.uteCliId;

		// // Set aziende rag sociale depending on az id.
		// var azRagSociale = this.allAziende.find(a => a.azId == this.newObject.clifinAzId).azRagSociale;
		// this.newObject.azRagSociale = azRagSociale;
	}



	// Clear form data by reinitiating newObject properties.
	clearForm() {
		this.newObject = null;
		this.newObject = new AziendeClientiFinale();
		this.newObjectAddForm.submitted = false;
	}

	// On modal close the modal and emit output with null.
	onCloseClicked() {
		this.showCloseConfirmDialog = true;
	}

	// Pop up close confirmation modal click event.
	onDialogConfirm(choice: boolean) {
		if (choice) {
			this.newObjectAddModal.hide();
			this.modalCloseEvent.emit(null);
		}
		this.showCloseConfirmDialog = false;
	}
}
