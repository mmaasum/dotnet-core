import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule, ModalModule } from 'ngx-bootstrap';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from 'shared/auth/auth.guard';
import { AuthService } from 'shared/auth/auth.service';
import { ErrorComponent } from 'shared/components/error/error.component';
import { LoaderComponent } from 'shared/components/loader/loader.component';
import { LoaderInterceptorService } from 'shared/services/loader-interceptor.service';
import { TranslateService } from 'shared/services/translate.service';

import { AdministrativeModule } from './administrative/administrative.module';
import { AppCommonModule } from './app-common.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApplicationDataModule } from './applicationdata/application-data.module';
import { GlobalErrorHandlerService } from './shared/services/global-error-handler.service';
import { SharedModule } from './shared/shared.module';

@NgModule({
	declarations: [
		AppComponent,
		ErrorComponent,
		LoaderComponent
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		HttpClientModule,
		FormsModule,
		BrowserAnimationsModule,
		ApplicationDataModule,
		AdministrativeModule,
		SharedModule,
		AppRoutingModule,
		ModalModule.forRoot(),
		TooltipModule.forRoot(),
		BsDatepickerModule.forRoot(),
		ToastrModule.forRoot({
			timeOut: 5000,
			positionClass: 'toast-center-center',
			preventDuplicates: true,
			closeButton: true,
			enableHtml: true
		}),
		AppCommonModule
	],
	providers: [
		AuthService,
		AuthGuard,
		TranslateService,
		// {
		//   provide : ErrorHandler,
		//   useClass : GlobalErrorHandlerService
		// },
		{
			provide: HTTP_INTERCEPTORS,
			useClass: LoaderInterceptorService,
			multi: true
		}
	],
	bootstrap: [AppComponent]
})
export class AppModule { }
