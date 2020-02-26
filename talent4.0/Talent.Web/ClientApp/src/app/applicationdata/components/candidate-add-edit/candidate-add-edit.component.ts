import { CandidateService } from './../../services/candidate.service';
import { Component, OnInit, Input, Output, ViewChild, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { Risorse } from 'shared/models/risorse';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { Titoli } from 'shared/models/titoli';

@Component({
	selector: 'app-candidate-add-edit',
	templateUrl: './candidate-add-edit.component.html',
	styleUrls: ['./candidate-add-edit.component.css']
})
export class CandidateAddEditComponent implements OnInit {

	// Input and output variables.
	@Input() risorseId: number;
	@Input() isNewRowAdding: boolean;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<Risorse>();

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;



	newObject: Risorse = new Risorse();
	showCloseConfirmDialog: boolean = false;

	allTitoli: Titoli[] = [];

	constructor(
		private candidateService: CandidateService,
		public toastrService: ToastrService,
		public authService: AuthService
	) { }


	ngOnChanges() {
		if (this.newObjectAddModal !== undefined) {
			// If showModal=true is setted by the parent component, open the modal
			// else close the modal.    
			if (this.showModal) {
				if (this.isNewRowAdding) {
					this.onAdd();
				}
				else if (this.risorseId > 0) {
					this.onEdit();
				}
				this.newObjectAddModal.show();
			}
			else {
				this.newObjectAddModal.hide();
			}
		}
	}

	ngOnInit() {
		this.candidateService.getAllTitles()
			.subscribe(
				response => {
					this.allTitoli = response;
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
		this.newObject = new Risorse();
		// set Attiva/Active to S so that in the dropdown list it will selected by default.  
		this.newObject.risSesso = "M";
		this.newObject.risTitolo = this.allTitoli.length > 0 ? this.allTitoli[0].titolo : "";
		// this.setAziendeInDropdown();

		this.newObjectAddModal.show();
		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;
	}

	// Click event of the Edit button
	onEdit() {
		// Pull the detail of the provided risorse id.
		this.candidateService.detail(this.risorseId)
			.subscribe(
				response => {
					this.newObject = response;
					this.newObjectAddModal.show();
				},
				error => {
					console.log(error);
					this.toastrService.error("Invalid Risorse Id!!");
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
			this.candidateService.create(this.newObject)
				.subscribe(
					response => {
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
			this.candidateService.update(this.newObject)
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

	// Set default values of newObject before add/edit post.
	setDefaultValue() {
		// If adding new data, set inserted by = current user.
		if (this.isNewRowAdding) {
			this.newObject.risDisponibile = '';
			this.newObject.risProtetto = 'N';
		}
	}

	// Clear form data by reinitiating newObject properties.
	clearForm() {
		this.newObject = null;
		this.newObject = new Risorse();
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
