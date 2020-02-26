import { AzioniService } from './services/azioni.service';

import { ErrorHandler, NgModule } from '@angular/core';
import { AgGridModule } from 'ag-grid-angular';
import {
	ViewAzioniAuthGuard,
	ViewOperazioniAuthGuard,
	ViewRichiestaAuthGuard,
	ViewRoleManagementAuthGuard,
	ViewTerminiAuthGuard,
	ViewUserCreateAuthGuard,
} from 'shared/auth/custom-auth.guard';
import { CustomLoadingOverlay } from 'shared/components/custom-loading-overlay/custom-loading-overlay.component';
import { CommonServiceOld } from 'shared/services/common.service';
import { FilterService } from 'shared/services/filters.service';
import { SharedModule } from 'shared/shared.module';

import { AzioniComponent } from '../administrative/components/azioni/azioni.component';
import { OperazioniComponent } from '../administrative/components/operazioni/operazioni.component';
import { RichiesteComponent } from '../administrative/components/richieste/richieste.component';
import { TerminiComponent } from '../administrative/components/termini/termini.component';
import { TerminiService } from '../administrative/services/termini.service';
import { AziendeService } from '../applicationdata/services/aziende.service';
import { AppCommonModule } from '../app-common.module';
import { AdministrativeRoutingModule } from './administrative-routing.module';
import {
	MachineLearningMatchingButtonComponent,
} from './components/machine-learning-matching-button/machine-learning-matching-button.component';
import { MatchingRecordComponent } from './components/matching-record/matching-record.component';
import { RoleManagementComponent } from './components/role-management/role-management.component';
import { SoftSkillComponent } from './components/soft-skill/soft-skill.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { RoleManagementService } from './services/role-management.service';
import { UtentiService } from './services/user-create.service';
import { GridManagementService } from '../shared/services/grid-management.service';
import { TerminiAddEditComponent } from './components/termini-add-edit/termini-add-edit.component';
import { TerminiOldComponent } from './components/termini-old/termini-old.component';
import { TerminiAllStatsComponent } from './components/termini-all-stats/termini-all-stats.component';
import { RoleManagementOldComponent } from './components/role-management-old/role-management-old.component';
import { RolesAddEditComponent } from './components/roles-add-edit/roles-add-edit.component';

@NgModule({
	imports: [
		AdministrativeRoutingModule,
		AgGridModule.withComponents([
			CustomLoadingOverlay,
			MachineLearningMatchingButtonComponent
		]),
		AppCommonModule,
		SharedModule
	],
	providers: [
		ErrorHandler,
		AziendeService,
		AzioniService,
		CommonServiceOld,
		FilterService,
		RoleManagementService,
		UtentiService,
		TerminiService,
		ViewAzioniAuthGuard,
		ViewOperazioniAuthGuard,
		ViewRoleManagementAuthGuard,
		ViewUserCreateAuthGuard,
		ViewTerminiAuthGuard,
		ViewRichiestaAuthGuard,
		GridManagementService,
	],
	declarations: [
		AzioniComponent,
		OperazioniComponent,
		RoleManagementComponent,
		UserCreateComponent,
		TerminiComponent,
		RichiesteComponent,
		MatchingRecordComponent,
		SoftSkillComponent,
		MachineLearningMatchingButtonComponent,
		TerminiAddEditComponent,
		TerminiOldComponent,
		TerminiAllStatsComponent,
		RoleManagementOldComponent,
		RolesAddEditComponent
	],

	exports: []
})

export class AdministrativeModule { }
