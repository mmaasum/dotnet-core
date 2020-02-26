import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { Email } from 'shared/models/email';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { Risorse } from 'shared/models/risorse';
import { TestResultati } from 'shared/models/test-resultati';
import { TestValutazione } from 'shared/models/test-valutazione';

import { CandidateService } from './../../services/candidate.service';
import { HardSkillService } from './../../services/hard-skill.service';

import { CKEditor4 } from 'ckeditor4-angular/ckeditor';

@Component({
	selector: 'app-hard-skill',
	templateUrl: './hard-skill.component.html',
	styleUrls: ['./hard-skill.component.css']
})
export class HardSkillComponent implements OnInit, OnChanges {

	// Input and output variables.
	@Input() risId: number;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<string>();


	@ViewChild('hardSkillModal', { static: false }) hardSkillModal: ModalDirective;
	@ViewChild('emailModal', { static: false }) emailModal: ModalDirective;
	@ViewChild('emailForm', { static: false }) emailForm: HTMLFormElement;


	// Local variables.
	possessedHardSkills: TestResultati[] = [];
	mandatorySkills: TestValutazione[] = [];
	optionalSkills: TestValutazione[] = [];
	selectedSkills: string[] = [];

	risorse: Risorse = new Risorse();
	fromMailAddresses: string[] = [
		"recruiting@itpartneritalia.com",
		"hr.milano@itpartneritalia.com",
		"hr.firenze@itpartneritalia.com"
	];

	email: Email = new Email();

	loggedInUser: ILoggedInUser;

	constructor(
		private hardSkillService: HardSkillService,
		private candidateService: CandidateService,
		private toastrService: ToastrService,
		private authService: AuthService
	) { }

	ngOnInit() {
		this.loggedInUser = this.authService.currentUserObject;
		this.loadLanguageSpecificData();
		this.fromMailAddresses.splice(0, 0, this.authService.currentUserEmail);
		this.email.from = this.authService.currentUserEmail;
		this.loadDefaultEmail();
	}

	// On input variable change
	// load the possessed hard skills against a ris id,
	// Show or hide hard skill modal.
	ngOnChanges() {

		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.   
		if (this.hardSkillModal !== undefined) {
			if (this.showModal) {
				// If ris id is set, get the possessed hard skills of the ris id.    
				if (this.risId) {

					forkJoin(
						this.hardSkillService.getHardSkills(this.risId),
						this.candidateService.detail(this.risId)
					).subscribe(
						response => {
							this.possessedHardSkills = response[0];
							this.risorse = response[1];

							this.email.to = this.risorse.risEmail;
							if (this.possessedHardSkills.length === 0) {
								this.loadMandatoryAndOptionalSkills();
							}

							var body = this.email.body;
							body = body.replace(/@ris_titolo/gi, this.risorse.risTitolo);
							body = body.replace(/@ris_nome/gi, this.risorse.risNome);
							body = body.replace(/@ris_cognome/gi, this.risorse.risCognome);
							this.email.body = body;

							this.hardSkillModal.show();
						},
						error => {
							console.log(error);
						}
					);

				}

			}
			else {
				this.hardSkillModal.hide();
			}
		}
	}

	private loadDefaultEmail() {
		this.hardSkillService.getDefaultMail()
			.subscribe(
				response => {

					this.email.cC = response[0].modemCc;
					this.email.sub = response[0].modemOggetto;

					if (response[0].modemTestoInizio)
						this.email.body = response[0].modemTestoInizio + '<br />';
					if (response[0].modemTestoIntermedio)
						this.email.body += response[0].modemTestoIntermedio + '<br />';
					if (response[0].modemTestoIntermedio2)
						this.email.body += response[0].modemTestoIntermedio2 + '<br />';
					if (response[0].modemTestoFine)
						this.email.body += response[0].modemTestoFine + '<br />';

				}
			);
	}

	caption: string;

	//table header
	testLabel: string;
	completionDateLabel: string;
	gradeLabel: string;
	correctAnsLabel: string;
	durationLabel: string;

	notFoundMessage: string;
	selectLabel: string;
	skillLabel: string;

	evaluationSelectLabel: string;

	sendBtnText: string;
	closeBtnText: string;

	loadLanguageSpecificData() {
		this.caption = (this.loggedInUser.language === 'ENG') ? 'Hard Skill' :
			((this.loggedInUser.language === 'ITA') ? 'Difficile Competenze' : 'Difícil Habilidades');

		this.testLabel = (this.loggedInUser.language === 'ENG') ? 'Test title' :
			((this.loggedInUser.language === 'ITA') ? 'Titolo del test' : 'Titulo de prueba');

		this.completionDateLabel = (this.loggedInUser.language === 'ENG') ? 'Date of completion' :
			((this.loggedInUser.language === 'ITA') ? 'Data di completamento' : 'Fecha de realización');

		this.gradeLabel = (this.loggedInUser.language === 'ENG') ? 'Grade' :
			((this.loggedInUser.language === 'ITA') ? 'Grado' : 'Grado');

		this.correctAnsLabel = (this.loggedInUser.language === 'ENG') ? 'Corredct answer' :
			((this.loggedInUser.language === 'ITA') ? 'Risposta corretta' : 'Respuesta correcta');

		this.durationLabel = (this.loggedInUser.language === 'ENG') ? 'Duration' :
			((this.loggedInUser.language === 'ITA') ? 'Durata' : 'Duración');

		this.notFoundMessage = (this.loggedInUser.language === 'ENG') ? 'No matching hard skill quiz found , please select them from the list' :
			((this.loggedInUser.language === 'ITA') ? 'Nessun quiz corrispondente, selezionarne uno dalla lista' : 'No se ha encontrado ningún cuestionario de habilidades duras coincidentes, selecciónelos de la lista');

		this.selectLabel = (this.loggedInUser.language === 'ENG') ? 'Select' :
			((this.loggedInUser.language === 'ITA') ? 'Seleziona' : 'Seleccionar');

		this.skillLabel = (this.loggedInUser.language === 'ENG') ? 'Evaluation test' :
			((this.loggedInUser.language === 'ITA') ? 'Test di valutazione' : 'Prueba de evaluacion');

		this.evaluationSelectLabel = (this.loggedInUser.language === 'ENG') ? 'Please select an evaluation test' :
			((this.loggedInUser.language === 'ITA') ? 'Si prega di selezionare un test di valutazione' : 'Por favor seleccione una prueba de evaluación');

		this.sendBtnText = (this.loggedInUser.language === 'ENG') ? 'Send' :
			((this.loggedInUser.language === 'ITA') ? 'Inviare' : 'Enviar');

		this.closeBtnText = (this.loggedInUser.language === 'ENG') ? 'Close' :
			((this.loggedInUser.language === 'ITA') ? 'Vicino' : 'Cerrar');
	}



	// On close button click of the hard skill modal
	// call the modal close function of the parent component.
	// Set visibility = hidden for both dropdown list.
	onModalClose() {
		this.hardSkillModal.hide();
		this.modalCloseEvent.emit("closed");
		this.mandatorySkills = [];
		this.optionalSkills = [];
	}

	// Load all the mandatory and optional skills list.
	loadMandatoryAndOptionalSkills() {
		forkJoin(
			this.hardSkillService.getTestValutazione(this.risId, "mandatory"),
			this.hardSkillService.getTestValutazione(this.risId, "optional")
		).subscribe(
			response => {
				this.mandatorySkills = response[0];
				this.optionalSkills = response[1];
			}
		);

	}

	// On second(evaluation) dropdown list change 
	// Send the hard skill request with selected evaluation.
	onEmailModalOpen() {
		var titolo = (<HTMLInputElement>document.getElementById("optionalSelectList")).value;
		if (titolo) {
			this.selectedSkills.push(titolo);
		}

		if (this.selectedSkills.length > 0) {

			var dt: TestValutazione;
			if (this.optionalSkills.some(a => a.tsvalTitolo == this.selectedSkills[0])) {
				dt = this.optionalSkills.find(a => a.tsvalTitolo == this.selectedSkills[0])
			}
			else if (this.mandatorySkills.some(a => a.tsvalTitolo == this.selectedSkills[0])) {
				dt = this.mandatorySkills.find(a => a.tsvalTitolo == this.selectedSkills[0])
			}

			var testContent: string = "";
			if (dt != undefined) {
				testContent = dt.tsvalTitolo + ', ' + dt.tsvalLink;
			}

			this.email.body = this.email.body.replace(/@test/gi, '');
			this.emailModal.show();

		}
		else {
			this.toastrService.warning("Select minimum 1 skill!");
		}

	}

	// On change event of the skill checkbox.
	// If a skill is checked, add it to the selectedSkills array.
	// If a skill is unchecked, remove it from selectedSkills array.
	onSkillCheck(event) {
		if (event.target.checked) {
			this.selectedSkills.push(event.target.defaultValue);
		}
		else {
			let indexOfElement = this.selectedSkills.indexOf(event.target.defaultValue);
			this.selectedSkills.splice(indexOfElement, 1);
		}
	}


	onSendInvitation(form) {
		if (form.valid) {
			this.hardSkillService.sendInvitation(this.email)
				.subscribe(
					response => {
						if (response.status == 'success') {
							this.toastrService.success("Invitation sent!");
							this.onEmailModalClose();
							this.onModalClose();
						}
						else {
							this.toastrService.error(response.status);
						}
					},
					error => {
						console.log(error);
					}
				);
		}
		else {
			this.toastrService.error("Invalid form data!");
		}

	}

	onEmailModalClose() {
		this.emailModal.hide();
	}


}
