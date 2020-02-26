import { ErrorComponent } from 'shared/components/error/error.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'shared/components/home/home.component';
import { LoginComponent } from 'shared/components/login/login.component';

import { AuthGuard } from './shared/auth/auth.guard';
import { PageNotFoundComponent } from 'shared/components/page-not-found/page-not-found.component';
import { WrapperLayoutComponent } from 'shared/layouts/wrapper-layout/wrapper-layout.component';
import { UnauthorizedComponent } from 'shared/components/unauthorized/unauthorized.component';

const routes: Routes = [
	{
		path: '',
		component: WrapperLayoutComponent,
		children: [
			{ path: '', component: HomeComponent, canActivate: [AuthGuard] },
			{ path: 'home', component: HomeComponent, canActivate: [AuthGuard] }			
		]
	},
	{ path: 'login/:clientId/:secretKey', pathMatch: 'full', component: LoginComponent },
	{ path: 'login', pathMatch: 'full', component: LoginComponent },
	{ path: 'unauthorized', component: UnauthorizedComponent },
	{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })
	],
	exports: [RouterModule]
})
export class AppRoutingModule { }