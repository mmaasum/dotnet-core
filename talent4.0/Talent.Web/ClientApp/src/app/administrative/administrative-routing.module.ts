import { RoleManagementOldComponent } from './components/role-management-old/role-management-old.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
	ViewAzioniAuthGuard,
	ViewOperazioniAuthGuard,
	ViewRichiestaAuthGuard,
	ViewRoleManagementAuthGuard,
	ViewTerminiAuthGuard,
	ViewUserCreateAuthGuard,
} from 'shared/auth/custom-auth.guard';

import { AzioniComponent } from './components/azioni/azioni.component';
import { MatchingRecordComponent } from './components/matching-record/matching-record.component';
import { OperazioniComponent } from './components/operazioni/operazioni.component';
import { RichiesteComponent } from './components/richieste/richieste.component';
import { RoleManagementComponent } from './components/role-management/role-management.component';
import { TerminiComponent } from './components/termini/termini.component';
import { UserCreateComponent } from './components/user-create/user-create.component';
import { WrapperLayoutComponent } from 'shared/layouts/wrapper-layout/wrapper-layout.component';
import { TerminiOldComponent } from './components/termini-old/termini-old.component';



const administrativeRoutes: Routes = [
	{
		path: '',
		component: WrapperLayoutComponent,
		children: [
			{ path: 'azioni', component: AzioniComponent, canActivate: [ViewAzioniAuthGuard] },
			{ path: 'operazioni', component: OperazioniComponent, canActivate: [ViewOperazioniAuthGuard] },
			{ path: 'rolemanagement', component: RoleManagementComponent, canActivate: [ViewRoleManagementAuthGuard] },
			{ path: 'rolemanagement-old', component: RoleManagementOldComponent, canActivate: [ViewRoleManagementAuthGuard] },
			{ path: 'user-create', component: UserCreateComponent, canActivate: [ViewUserCreateAuthGuard] },
			{ path: 'termini', component: TerminiComponent, canActivate: [ViewTerminiAuthGuard] },
			{ path: 'termini-old', component: TerminiOldComponent, canActivate: [ViewTerminiAuthGuard] },
			{ path: 'matchingrecord', component: MatchingRecordComponent, canActivate: [ViewRichiestaAuthGuard] },
			{ path: 'richieste', component: RichiesteComponent, canActivate: [ViewRichiestaAuthGuard] }
		]
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(administrativeRoutes)
	],
	exports: [RouterModule]
})
export class AdministrativeRoutingModule { }