import { AuthService } from 'shared/auth/auth.service';
import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { ISurveyInvitationModel } from 'shared/models/survey-invitation';
import { Risorse } from 'shared/models/risorse';
import { ModalDirective } from 'ngx-bootstrap';
import { SoftSkillWsResult } from 'shared/models/soft-skill-ws-result';
import { CandidateSoftSkillService } from 'app/applicationdata/services/candidate-soft-skill.service';
import { ToastrService } from 'ngx-toastr';
import { SurveyInvitationService } from 'app/applicationdata/services/survey-invitation.service';
import { ILoggedInUser } from 'shared/models/loggedin-user';

@Component({
	selector: 'app-candidate-soft-skill',
	templateUrl: './candidate-soft-skill.component.html',
	styleUrls: ['./candidate-soft-skill.component.css']
})
export class CandidateSoftSkillComponent implements OnInit {

	// Input and output variables.
	@Input() risorse: Risorse;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<string>();

	@ViewChild('hardSkillModal', { static: false }) hardSkillModal: ModalDirective;

	// Local variables.
	possessedSoftSkills: SoftSkillWsResult[] = [];
	user: ISurveyInvitationModel;

	loggedInUser: ILoggedInUser;

	constructor(
		private authService: AuthService,
		private candidateSoftSkillService: CandidateSoftSkillService,
		private toastrService: ToastrService,
		private surveyInvitationService: SurveyInvitationService
	) { }

	ngOnInit() {
		this.loggedInUser = this.authService.currentUserObject;
		this.loadLanguageSpecificData();
	}

	// On input variable change
	// load the possessed hard skills against a ris id,
	// Show or hide hard skill modal.
	ngOnChanges() {
		if (this.hardSkillModal !== undefined) {

			// If showModal=true is setted by the parent component, open the modal
			// else close the modal.    
			if (this.showModal) {
				// If ris id is set, get the possessed hard skills of the ris id.
				if (this.risorse.risId != null) {
					this.candidateSoftSkillService.getSoftSkills(this.risorse.risId)
						.subscribe(
							response => {
								this.possessedSoftSkills = response;
							},
							error => {
								console.log(error);
							}
						);
				}
				this.hardSkillModal.show();
			}
			else {
				this.hardSkillModal.hide();
			}
		}
	}


	caption: string;

	playFieldLabel: string;
	profileLabel: string;
	playLabel: string;
	descriptionLabel: string;


	notFoundMessage: string;

	yesBtnText: string;
	noBtnText: string;
	closeBtnText: string;

	loadLanguageSpecificData() {
		this.caption = (this.loggedInUser.language === 'ENG') ? 'Soft Skill' :
			((this.loggedInUser.language === 'ITA') ? 'Morbido Competenze' : 'Suave Habilidades');

		this.playFieldLabel = (this.loggedInUser.language === 'ENG') ? 'Play field' :
			((this.loggedInUser.language === 'ITA') ? 'Campo di gioco' : 'Campo de juego');

		this.playLabel = (this.loggedInUser.language === 'ENG') ? 'Play' :
			((this.loggedInUser.language === 'ITA') ? 'Giocare' : 'Jugar');

		this.profileLabel = (this.loggedInUser.language === 'ENG') ? 'Profile' :
			((this.loggedInUser.language === 'ITA') ? 'Profilo' : 'Perfil');

		this.descriptionLabel = (this.loggedInUser.language === 'ENG') ? 'Description' :
			((this.loggedInUser.language === 'ITA') ? 'Descrizione' : 'Descripción');

		this.notFoundMessage = (this.loggedInUser.language === 'ENG') ? 'There’s no soft skill recorded, would you like to send a request ?' :
			((this.loggedInUser.language === 'ITA') ? 'Non è stata registrata alcuna soft skill, vorresti inviare una richiesta?' : 'No hay ninguna habilidad suave registrada, ¿te gustaría enviar una solicitud?');


		this.yesBtnText = (this.loggedInUser.language === 'ENG') ? 'Yes' :
			((this.loggedInUser.language === 'ITA') ? 'Sí' : 'Sí');

		this.noBtnText = (this.loggedInUser.language === 'ENG') ? 'No' :
			((this.loggedInUser.language === 'ITA') ? 'No' : 'No');

		this.closeBtnText = (this.loggedInUser.language === 'ENG') ? 'Close' :
			((this.loggedInUser.language === 'ITA') ? 'Vicino' : 'Cerrar');
	}



	// On close button click of the hard skill modal
	// call the modal close function of the parent component.
	// Set visibility = hidden for both dropdown list.
	onModalClose() {
		this.hardSkillModal.hide();
		this.modalCloseEvent.emit("closed");
	}

	// On yes button click show the first(competenze) dropdown list.
	onYesClicked() {
		this.user = {
			firstName: this.risorse.risNome,
			surName: this.risorse.risCognome,
			email: this.risorse.risEmail
		};

		if (confirm("Are you sure to send an invitation link?")) {
			this.surveyInvitationService.postInvitation(this.user)
				.subscribe(
					response => {
						this.toastrService.success("Please check your mail", "Invitation has been sent");
						this.onModalClose();
					}
				);
		}
	}


}
