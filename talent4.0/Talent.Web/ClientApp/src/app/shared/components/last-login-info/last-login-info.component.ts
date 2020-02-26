import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { Azioni } from 'shared/models/azioni';
import { LastLoginInfoService } from 'shared/services/last-login-info.service';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-last-login-info',
	templateUrl: './last-login-info.component.html',
	styleUrls: ['./last-login-info.component.css'],
	providers: [LastLoginInfoService]
})
export class LastLoginInfoComponent implements OnInit, OnChanges {

	@Input() show: boolean;
	@Output() onClose = new EventEmitter<boolean>();

	@ViewChild('lastLoginInfoModal', { static: false }) lastLoginInfoModal: ModalDirective;

	loginTime: Date;
	lastLoginData: Azioni;
	ip: string;
	client: string;
	os: string;

	osIcon: string;
	browserIcon: string;

	constructor(
		private lastLoginInfoService: LastLoginInfoService,
		private translate: TranslateService
	) {

	}

	ngOnChanges() {
		if (this.lastLoginInfoModal !== undefined) {
			if (this.show) {
				this.getLastLoginInfo();
				this.lastLoginInfoModal.show();
			}
			else {
				this.lastLoginInfoModal.hide();
			}
		}
	}

	ngOnInit() {
		let user = this.lastLoginInfoService.user;
		this.translate.use(user.language);
		this.translate.load(['common']);
	}

	private getLastLoginInfo() {
		this.lastLoginInfoService.lastLogin()
			.subscribe(
				response => {
					this.loginTime = response.azioneInizio;
					this.lastLoginData = response;
					this.extractDetail();
				}
			);
	}

	private extractDetail() {
		if (this.lastLoginData != null && this.lastLoginData != undefined) {
			var detail = this.lastLoginData.azioneDescrizione;
			if (detail) {
				var indexOfClient = detail.toLowerCase().indexOf("client");
				var indexOfOs = detail.toLowerCase().indexOf("os");
				this.ip = detail.substr(0, indexOfClient - 1);
				this.client = detail.substr(indexOfClient, indexOfOs - indexOfClient);
				this.os = detail.substr(indexOfOs);

				this.setBrowserIcon();
				this.setOsIcon();
			}
		}
	}


	private setBrowserIcon() {

		if (this.client.match(/firefox/gi))
			this.browserIcon = "fa fa-firefox browser";
		else if (this.client.match(/safari/gi))
			this.browserIcon = "fa fa-safari browser";
		else if (this.client.match(/edge/gi))
			this.browserIcon = "fa fa-edge browser";
		else if (this.client.match(/explorer/gi))
			this.browserIcon = "fa fa-internet-explorer browser";
		else
			this.browserIcon = "fa fa-chrome browser";
	}

	private setOsIcon() {

		if (this.os.match(/ubuntu/gi))
			this.osIcon = "fa fa-ubuntu os";
		else if (this.os.match(/suse/gi))
			this.osIcon = "fa fa-suse os";
		else if (this.os.match(/linux/gi))
			this.osIcon = "fa fa-linux os";
		else if (this.os.match(/fedora/gi))
			this.osIcon = "fa fa-fedora os";
		else if (this.os.match(/centos/gi))
			this.osIcon = "fa fa-centos os";
		else if (this.os.match(/ios/gi))
			this.osIcon = "fa fa-apple os";
		else if (this.os.match(/apple/gi))
			this.osIcon = "fa fa-apple os";
		else
			this.osIcon = "fa fa-windows os";
	}

	onCloseModal() {
		this.onClose.emit(true);
		this.lastLoginInfoModal.hide()
	}
}
