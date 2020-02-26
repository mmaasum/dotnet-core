import { AuthGuard } from 'shared/auth/auth.guard';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { AmministrativoHomeComponent } from './components/amministrativo-home/amministrativo-home.component';
import { CommercialHomeComponent } from './components/commercial-home/commercial-home.component';
import { DataEntryHomeComponent } from './components/data-entry-home/data-entry-home.component';
import { RecruiterHomeComponent } from './components/recruiter-home/recruiter-home.component';
import { WrapperLayoutComponent } from './layouts/wrapper-layout/wrapper-layout.component';





const sharedRoutes: Routes = [
	{
		path: '',
		component: WrapperLayoutComponent,
		children: [
			{ path: 'admin/home', component: AdminHomeComponent, canActivate: [AuthGuard] },
			{ path: 'amministrativo/home', component: AmministrativoHomeComponent, canActivate: [AuthGuard] },
			{ path: 'commerciale/home', component: CommercialHomeComponent, canActivate: [AuthGuard] },
			{ path: 'data-entry/home', component: DataEntryHomeComponent, canActivate: [AuthGuard] },
			{ path: 'recruiter/home', component: RecruiterHomeComponent, canActivate: [AuthGuard] }
		]
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(sharedRoutes)
	],
	exports: [RouterModule]
})
export class SharedRoutingModule { }