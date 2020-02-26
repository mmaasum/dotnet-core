import { AuthGuard } from './../shared/auth/auth.guard';
import { HomeComponent } from 'shared/components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
	ViewAziendeAuthGuard,
	ViewClienteFinaleAuthGuard,
	ViewContattiAuthGuard,
	ViewMachineLearningAuthGuard,
	ViewRisorseAuthGuard,
	ViewSediAziendeAuthGuard,
	ViewSurveyInvitationAuthGuard,
} from 'shared/auth/custom-auth.guard';
import { WrapperLayoutComponent } from 'shared/layouts/wrapper-layout/wrapper-layout.component';


import { AziendeComponent } from './components/aziende/aziende.component';
import { CandidatesComponent } from './components/candidates/candidates.component';
import { ClienteFinaleComponent } from './components/cliente-finale/cliente-finale.component';
import { ContattiComponent } from './components/contatti/contatti.component';
import { MachineLearningComponent } from './components/machine-learning/machine-learning.component';
import { SediAziendeComponent } from './components/sedi-aziende/sedi-aziende.component';
import { SurveyInvitationComponent } from './components/survey-invitation/survey-invitation.component';



const applicationDataRoutes: Routes = [
	{
		path: '',
		component: WrapperLayoutComponent,
		children: [
			{ path: '', component: HomeComponent, canActivate: [AuthGuard] },
			{ path: 'aziende', component: AziendeComponent, canActivate: [ViewAziendeAuthGuard] }
		]
	},
	{
		path: '',
		component: WrapperLayoutComponent,
		children: [
			{ path: 'sedi-aziende', component: SediAziendeComponent, canActivate: [ViewSediAziendeAuthGuard] },
			{ path: 'aziende-clienti-finali', component: ClienteFinaleComponent, canActivate: [ViewClienteFinaleAuthGuard] },
			{ path: 'contatti', component: ContattiComponent, canActivate: [ViewContattiAuthGuard] },
			{ path: 'surveyinvitation', component: SurveyInvitationComponent, canActivate: [ViewSurveyInvitationAuthGuard] },
			{ path: 'risorse', component: CandidatesComponent, canActivate: [ViewRisorseAuthGuard] },
			{ path: 'machine-learning', component: MachineLearningComponent, canActivate: [ViewMachineLearningAuthGuard] }
		]
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(applicationDataRoutes)
	],
	exports: [RouterModule]
})
export class ApplicationdataRoutingModule { }