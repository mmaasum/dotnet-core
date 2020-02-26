import { NgModule } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import { AppCommonModule } from 'app/app-common.module';
import {
	ViewAziendeAuthGuard,
	ViewClienteFinaleAuthGuard,
	ViewContattiAuthGuard,
	ViewMachineLearningAuthGuard,
	ViewRisorseAuthGuard,
	ViewSediAziendeAuthGuard,
	ViewSurveyInvitationAuthGuard,
} from 'shared/auth/custom-auth.guard';
import { CustomLoadingOverlay } from 'shared/components/custom-loading-overlay/custom-loading-overlay.component';
import { SharedModule } from 'shared/shared.module';

import { ApplicationdataRoutingModule } from './application-data-routing.module';
import { AziendeComponent } from './components/aziende/aziende.component';
import { CandidateAddEditComponent } from './components/candidate-add-edit/candidate-add-edit.component';
import { CandidateSoftSkillComponent } from './components/candidate-soft-skill/candidate-soft-skill.component';
import { CandidatesComponent } from './components/candidates/candidates.component';
import { ClienteFinaleAddEditComponent } from './components/cliente-finale-add-edit/cliente-finale-add-edit.component';
import { ClienteFinaleComponent } from './components/cliente-finale/cliente-finale.component';
import { ContattiComponent } from './components/contatti/contatti.component';
import { HardSkillComponent } from './components/hard-skill/hard-skill.component';
import { MachineLearningComponent } from './components/machine-learning/machine-learning.component';
import { SediAziendeAddEditComponent } from './components/sedi-aziende-add-edit/sedi-aziende-add-edit.component';
import { SediAziendeComponent } from './components/sedi-aziende/sedi-aziende.component';
import { SurveyInvitationComponent } from './components/survey-invitation/survey-invitation.component';
import { AziendeService } from './services/aziende.service';
import { ContattiService } from './services/contatti.service';
import { MachineLearningService } from './services/machine-learning.service';
import { SurveyInvitationService } from './services/survey-invitation.service';


@NgModule({
	imports: [
		ApplicationdataRoutingModule,
		AgGridModule.withComponents([CustomLoadingOverlay]),
		SharedModule,
		AppCommonModule
	],
	declarations: [
		AziendeComponent,
		SurveyInvitationComponent,
		ContattiComponent,
		CandidatesComponent,
		HardSkillComponent,
		ClienteFinaleComponent,
		CandidateSoftSkillComponent,
		SediAziendeComponent,
		SediAziendeAddEditComponent,
		ClienteFinaleAddEditComponent,
		MachineLearningComponent,
		CandidateAddEditComponent
	],
	providers: [
		AziendeService,
		ContattiService,
		MachineLearningService,
		SurveyInvitationService,
		ViewAziendeAuthGuard,
		ViewSediAziendeAuthGuard,
		ViewClienteFinaleAuthGuard,
		ViewContattiAuthGuard,
		ViewSurveyInvitationAuthGuard,
		ViewRisorseAuthGuard,
		ViewMachineLearningAuthGuard
	],
	exports: []
})

export class ApplicationDataModule { }
