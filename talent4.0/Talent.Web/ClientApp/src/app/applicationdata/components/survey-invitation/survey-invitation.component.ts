
import { Component, ViewChild } from '@angular/core';
import { SurveyInvitationService } from '../../services/survey-invitation.service';
import { ISurveyInvitationModel } from 'shared/models/survey-invitation';
import { ToastrService } from 'ngx-toastr';


@Component({
	selector: 'survey-invitation',
	templateUrl: './survey-invitation.component.html',
})

export class SurveyInvitationComponent {

	@ViewChild('surveyInvitationForm', { static: false }) surveyInvitationForm: HTMLFormElement;

	user: ISurveyInvitationModel;

	ngOnInit() {
		this.setBlankUserProperty();
	}

	constructor(
		private surveyInvitationService: SurveyInvitationService,
		private toastrService: ToastrService
	) { }

	// Post the user data to the server.
	onSubmit() {
		this.surveyInvitationService.postInvitation(this.user)
			.subscribe(
				response => {
					this.setBlankUserProperty();
					this.surveyInvitationForm.submitted = false;
					this.toastrService.success("Please check your mail", "Invitation has been sent");
				}
			);
	}

	setBlankUserProperty() {
		this.user = {
			firstName: "",
			surName: "",
			email: ""
		};
	}

	// On common-grid child component clear button click
	// clear option1 and option2 property of all filter in allFilter array.
	// Reinitialize grid. 
	clearAllFilters($event) {
	}

	// On common-grid child component save filter button click
	// send the applied filter data from parent component to child component.
	onChangeFilterText($event) {
	}
}

