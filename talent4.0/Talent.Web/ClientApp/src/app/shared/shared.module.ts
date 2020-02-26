import { GridManagementService } from 'shared/services/grid-management.service';
import { FilterManagementComponent } from 'shared/components/filter-management/filter-management.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { AlertModule, BsDropdownModule, SortableModule } from 'ngx-bootstrap';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AdminHomeComponent } from 'shared/components/admin-home/admin-home.component';
import { AmministrativoHomeComponent } from 'shared/components/amministrativo-home/amministrativo-home.component';
import { CommercialHomeComponent } from 'shared/components/commercial-home/commercial-home.component';
import { DataEntryHomeComponent } from 'shared/components/data-entry-home/data-entry-home.component';
import { HomeComponent } from 'shared/components/home/home.component';
import { MainContentComponent } from 'shared/components/main-content/maincontent.component';
import { RecruiterHomeComponent } from 'shared/components/recruiter-home/recruiter-home.component';
import { MenuBarComponent } from 'shared/layouts/menu-bar/menu-bar.component';
import { CommonServiceOld } from 'shared/services/common.service';

import { AuthGuard } from './auth/auth.guard';
import { AuthService } from './auth/auth.service';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { CustomLoadingOverlay } from './components/custom-loading-overlay/custom-loading-overlay.component';
import { GlobalSearchComponent } from './components/global-search/global-search.component';
import { GridPaginationComponent } from './components/grid-pagination/grid-pagination.component';
import { LastLoginInfoComponent } from './components/last-login-info/last-login-info.component';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { WrapperLayoutComponent } from './layouts/wrapper-layout/wrapper-layout.component';
import { SharedRoutingModule } from './shared-routing.module';
import { AppCommonModule } from 'app/app-common.module';
import { GridManagementComponent } from './components/grid-management/grid-management.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';


@NgModule({
	imports: [
		BsDropdownModule.forRoot(),
		TooltipModule.forRoot(),
		AlertModule.forRoot(),
		SharedRoutingModule,
		SortableModule.forRoot(),
		AppCommonModule
	],
	providers: [
		AuthService,
		CommonServiceOld,
		AuthGuard
	],
	declarations: [
		AdminHomeComponent,
		AmministrativoHomeComponent,
		CommercialHomeComponent,
		DataEntryHomeComponent,
		HomeComponent,
		LoginComponent,
		MainContentComponent,
		MenuBarComponent,
		RecruiterHomeComponent,
		GridPaginationComponent,
		ConfirmationDialogComponent,
		CustomLoadingOverlay,
		GlobalSearchComponent,
		FilterManagementComponent,
		FooterComponent,
		WrapperLayoutComponent,
		PageNotFoundComponent,
		LastLoginInfoComponent,
		GridManagementComponent,
		UnauthorizedComponent
	],

	exports: [
		MenuBarComponent,
		FilterManagementComponent,
		GlobalSearchComponent,
		GridPaginationComponent,
		MainContentComponent,
		ConfirmationDialogComponent,
		GridManagementComponent,
		CustomLoadingOverlay,
		FooterComponent
	],
	schemas: [
		CUSTOM_ELEMENTS_SCHEMA
	]
})

export class SharedModule { }
