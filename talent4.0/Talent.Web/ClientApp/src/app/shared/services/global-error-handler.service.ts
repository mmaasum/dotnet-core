import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Injectable, ErrorHandler, Injector, NgZone } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class GlobalErrorHandlerService implements ErrorHandler {

	constructor(private injector: Injector, private ngZone: NgZone) { }

	handleError(error: Error | HttpErrorResponse) {

		const toastrService = this.injector.get(ToastrService);
		console.log("ERROR : ");
		console.log(error);

		if (error instanceof HttpErrorResponse) {
			var title = '';
			var message = '';
			if (!navigator.onLine) {
				title = "Internet unavailable";
				message = "Check your network connection"
			}
			else {
				title = error.error.error ? error.error.error : error.error.title;
				message = error.error.message ? error.error.message : '';
			}
			this.ngZone.run(() => {
				toastrService.error(message, title);
			})

		}
		else {
			console.log("Client side error");
		}
	}
}
