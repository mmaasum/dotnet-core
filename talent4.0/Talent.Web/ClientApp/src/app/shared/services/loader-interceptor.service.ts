import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { LoaderService } from './loader.service';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { ILoggedInUser } from 'shared/models/loggedin-user';

@Injectable({
	providedIn: 'root'
})
export class LoaderInterceptorService implements HttpInterceptor {

	constructor(
		private loaderService: LoaderService,
		private router: Router) { }

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		this.showLoader();

		// Injecting authorizations header
		let token = localStorage.getItem('access-token');
		if (token) {
			req = req.clone({
				setHeaders: {
					Authorization: `Bearer ${token}`
				}
			});
		}

		return next.handle(req)
			.pipe(
				tap(
					(event: HttpEvent<any>) => {
						if (event instanceof HttpResponse) {
							this.onEnd();
						}
					},
					(err: any) => {
						this.onEnd();
					}
				),
				catchError(
					error => {
						if (error.status === 401) {
							var user: ILoggedInUser = JSON.parse(localStorage.getItem('loggedin-user'));
							var cliId = user.uteCliId;
							var secretKey = user.secretKey;
							localStorage.removeItem('access-token');
							localStorage.removeItem('loggedin-user');
							this.router.navigate(['/login', cliId, secretKey]);
						} else {
							return throwError(error);
						}
					}
				)
			);

	}

	private onEnd(): void {
		this.hideLoader();
	}

	private showLoader(): void {
		this.loaderService.show();
	}

	private hideLoader(): void {
		this.loaderService.hide();
	}
}
