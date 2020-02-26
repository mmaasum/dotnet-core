import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { Aziende } from 'shared/models/aziende';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { SediAzienda } from 'shared/models/sedi-aziende';

import { AziendeService } from './../../services/aziende.service';
import { SediAziendeService } from './../../services/sedi-aziende.service';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-sedi-aziende-add-edit',
	templateUrl: './sedi-aziende-add-edit.component.html',
	styleUrls: ['./sedi-aziende-add-edit.component.css']
})
export class SediAziendeAddEditComponent extends CommonGridBehaviour implements OnChanges, OnInit {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}


	// Input and output variables.
	@Input() azId: number;
	@Input() azsedeId: number;
	@Input() isNewRowAdding: boolean;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<SediAzienda>();

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;

	// private loggedInUser : ILoggedInUser;
	newObject: SediAzienda = new SediAzienda();

	allAziende: Aziende[] = [];
	showCloseConfirmDialog: boolean = false;


	constructor(
		private sediAziendeService: SediAziendeService,
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
			else if (this.azsedeId > 0) {
				this.onEdit();
			}
			this.newObjectAddModal.show();
		}
		else {
			this.newObjectAddModal.hide();
		}
	}
	sediAzendiAddEditLable: any;
	ngOnInit() {

		this.getMultiLanguageCommonLables();
		this.sediAzendiAddEditLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.sediAzendiAddEditLable = response.multiLanguage.sediAziende
					[this.loggedInUser.language.toLowerCase()];
				},
				error => {
					console.log(error);
				}
			);

		this.loggedInUser = this.authService.currentUserObject;
		//this.loadLanguageSpecificData();

		// Pull all the aziende list for add/edit dropdown list
		this.aziendeService.getAllTheAziende()
			.subscribe(
				response => {
					this.allAziende = response;
				},
				error => {
					console.log(error);
				}
			);
	}

	// caption: string;  
	// companyLabel : string;
	// descriptionLabel : string;
	// indicLabel : string;
	// indicColloquioLabel : string;

	// activeLabel : string;
	// addressLabel : string;
	// cityLabel : string;
	// postcodeLabel : string;

	// submitButtonText : string;
	// cancelButtonText : string;

	// loadLanguageSpecificData() {

	//   this.caption = (this.loggedInUser.language === 'ENG') ? 'Company locations' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Sedi Aziendali' : 'Ubicaciones de Empresas'); 

	//   this.companyLabel = (this.loggedInUser.language === 'ENG') ? 'Company' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Azienda' : 'Empresa');

	//   this.descriptionLabel = (this.loggedInUser.language === 'ENG') ? 'Company Location Description' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Descrizione Sede Azienda' : 'Descripción de la ubicación de la empresa');

	//   this.indicLabel = (this.loggedInUser.language === 'ENG') ? 'Indic' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Indic' : 'Indic');

	//   this.indicColloquioLabel = (this.loggedInUser.language === 'ENG') ? 'Indic interview' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Indic colloquio' : 'Indic entrevista');

	//   this.activeLabel = (this.loggedInUser.language === 'ENG') ? 'Active' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Attiva' : 'Activo');

	//   this.addressLabel = (this.loggedInUser.language === 'ENG') ? 'Address' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Indirizzo' : 'Dirección');

	//   this.cityLabel = (this.loggedInUser.language === 'ENG') ? 'City' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Città' : 'Ciudad');

	//   this.postcodeLabel = (this.loggedInUser.language === 'ENG') ? 'CAP' :
	//     ((this.loggedInUser.language === 'ITA') ? 'CAP' : 'CAP');

	//   this.submitButtonText = (this.loggedInUser.language === 'ENG') ? 'Submit' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Presentare' : 'Enviar');

	//   this.cancelButtonText = (this.loggedInUser.language === 'ENG') ? 'Close' :
	//     ((this.loggedInUser.language === 'ITA') ? 'Vicino' : 'Cerca');
	// }



	// For adding new row.
	onAdd() {
		// Reinitiate newObject.        
		this.newObject = null;
		this.newObject = new SediAzienda();

		// set Attiva/Active to S so that in the dropdown list it will selected by default.  
		this.newObject.azsedeAttiva = "S";
		this.setAziendeInDropdown();

		this.newObjectAddModal.show();
		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;
	}



	// For editing existing row.
	onEdit() {
		// Pull the detail of the provided sede aziende id.
		this.sediAziendeService.detail(this.azsedeId)
			.subscribe(
				response => {
					this.newObject = response;
					this.newObjectAddModal.show();
				},
				error => {
					console.log(error);
					this.toastrService.error("Invalid Sede Aziende Id!!");
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
			this.sediAziendeService.create(this.newObject)
				.subscribe(
					response => {
						this.newObject.azsedeId = response;
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
			// Updating an existing azienda.
			this.sediAziendeService.update(this.newObject)
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
			this.newObject.azsedeAzId = null;
		}
		else {
			this.newObject.azsedeAzId = this.azId;
		}
	}


	// Set default user id and client id values of newObject.
	// For EDIT only set the modUteId/Modified by.
	// For ADD set modified by,clientId and inserted by.
	setDefaultValue() {
		this.newObject.azsedeModUteId = this.loggedInUser.uteId;
		this.newObject.azsedeLegale = "N";
		if (this.isNewRowAdding) {
			this.newObject.azsedeCliId = this.loggedInUser.uteCliId;
			this.newObject.azsedeInsUteId = this.loggedInUser.uteId;
		}
	}


	// Clear form data by reinitiating newObject properties.
	clearForm() {
		this.newObject = null;
		this.newObject = new SediAzienda();
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
