import { Component, EventEmitter, Input, OnChanges, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { AuthService } from 'shared/auth/auth.service';
import { TranslateService } from 'shared/services/translate.service';


@Component({
	selector: 'app-confirmation-dialog',
	templateUrl: './confirmation-dialog.component.html',
	styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnChanges {

	@Input() showDialog: boolean;
	@Input() showErrorDialog: boolean;
	@Input() confirmationMessage: string;
	@Input() errorMessage: string;

	@Output() confirmationSelectEvent = new EventEmitter<boolean>();

	@ViewChild('confirmationModal', { static: false }) confirmationModal: ModalDirective;
	@ViewChild('globalErrorModal', { static: false }) globalErrorModal: ModalDirective;

	errorMessage5: string;
	message: string;


	constructor(
		private authService: AuthService,
		private translate: TranslateService
	) {
		var user = this.authService.currentUserObject;
		if (user != undefined) {
			this.translate.use(user.language);
			this.translate.load(['common']);
		}
	}

	ngOnChanges() {
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    

		if (this.confirmationModal != undefined) {

			if (this.showDialog) {
				this.message = this.confirmationMessage ?
					this.confirmationMessage :
					this.translate.instant('common.usrmsg_info.L7019_confirmation');
				this.confirmationModal.show();
			}
			else {
				this.confirmationModal.hide();
			}
		}

		if (this.globalErrorModal != undefined) {

			if (this.showErrorDialog) {
				this.globalErrorModal.show();
			}
			else {
				this.globalErrorModal.hide();
			}
		}

		if (this.errorMessage) {
			this.errorMessage5 = this.errorMessage;
		}

	}

	// Emit the selected choice (yes/no).
	onConfirm(choice: boolean) {
		this.confirmationSelectEvent.emit(choice);
	}

	onCloseErrorModel() {
		this.confirmationSelectEvent.emit(false);
	}

}
