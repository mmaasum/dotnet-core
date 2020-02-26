import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISurveyInvitationModel } from 'shared/models/survey-invitation';


@Injectable({
	providedIn: 'root'
})
export class SurveyInvitationService {

	constructor(private http: HttpClient) { }

	// Post the invitation data to the server.
	// Parameter is ISurveyInvitationmodel instance.
	// Returns an observable of any type.
	postInvitation(surveyInvitationModel: ISurveyInvitationModel) {
		return this.http.post('/api/survey/invite', surveyInvitationModel);
	}

}
