import { Component, ViewChild, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { ILogInUser } from 'shared/models/login-user';
import { LastLoginInfoService } from 'shared/services/last-login-info.service';

import { KeyValuePair } from './../../models/key-value-pair';
import { TranslateService } from 'shared/services/translate.service';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
	selector: 'app-login',
	templateUrl: './login-new.component.html',
	styleUrls: ['./login-new.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

	isUrlValid: boolean = false;
	invalidUrlMsg: string;
	clientLogo: string;

	@ViewChild('loginForm', { static: false }) ShowHideInput;

	selectedFlag: string;
	selectedLanguage: string;
	flagImageSource: KeyValuePair[] = [
		{ key: "ITA", value: "IT.png", description: "Italiano" },
		{ key: "ESP", value: "ES.png", description: "Español" },
		{ key: "ENG", value: "GB.png", description: "English" },
	];

	clientId: string;
	secretKey: string;
	user: ILogInUser = {
		uteId: "",
		utePassword: "",
		uteCliId: "",
		language: "ITA"
	};

	showHide(val) {
		console.log(val.type);
		alert();
	}
	username: string;
	password: string;
	usernameTooltip: string;
	passwordTooltip: string;
	needHelp: string;
	clickhere: string;
	enterButtonText: string;

	errorMessage: string;
	copywriteText: string;
	copywriteAtsText: string;
	versionText: string;
	show: boolean;

	subscription: Subscription;

	constructor(
		private authService: AuthService,
		private lastLoginInfoService: LastLoginInfoService,
		private toastrService: ToastrService,
		private router: Router,
		private route: ActivatedRoute,
		private translate: TranslateService
	) {
		this.show = false;
	}
	eyeSlash: boolean = true;
	showPassword() {
		this.show = !this.show;
		this.eyeSlash = !this.eyeSlash;
	}

	ngOnInit() {
		this.subscription = this.authService.isLoggedIn
			.subscribe(state => {
				if (state) {
					this.router.navigate(['/aziende']);
				}
			});
		this.validateClientId();
		this.getBrowserLanguage();
		this.onLanguageChange(this.user.language);
	}

	private getBrowserLanguage() {
		var osLanguage = window.navigator.language;
		switch (osLanguage) {
			case "it":
				this.user.language = "ITA";
				break;
			case "es":
				this.user.language = "ESP";
				break;
			default:
				this.user.language = "ENG";
				break;
		}
	}

	errorMessage5: string;

	private validateClientId() {
		this.clientLogo = "";
		this.route.paramMap.subscribe(param => {
			this.clientId = param.get('clientId');
			this.secretKey = param.get('secretKey');
			if (!this.clientId) {
				this.isUrlValid = false;
				this.setInvalidUrlMsg(false);
			}
			else {
				this.authService.validateClient(this.clientId, this.secretKey)
					.subscribe(
						response => {
							console.log(response);
							if (!response.isValid) {
								this.isUrlValid = false;
								this.setInvalidUrlMsg(true);
							}
							else {
								this.isUrlValid = true;
								this.user.uteCliId = this.clientId;
								//this.clientLogo = `../../../../assets/img/clients/${response.logoLink}`;
								this.clientLogo = response.logoLink;
							}
						},
						err => {
							this.errorMessage5 = err.error.error;
							// this.errorMessage = err.error.message;
							console.log(err);
							this.showCloseErrorDialog = true;

							this.toastrService.error(err.error.message, err.error.error);
						}
					);
			}
		});
	}

	private setInvalidUrlMsg(isCLientExist: boolean) {
		var msgKey = 'login.usrmsg_err.';
		msgKey += isCLientExist ? 'L1007_invalidclientid' : 'L1006_emptyclientid';
		this.translate.get(msgKey).subscribe(msg => this.invalidUrlMsg = msg);
	}


	onLanguageChange(lan: string) {

		this.user.language = lan;

		this.translate.use(this.user.language);
		this.translate.load(['login','common']);
		this.translate.get('login.usrmsg_info')
			.subscribe(
				msg => {
					this.needHelp = msg.L7001_needHelp;
					this.clickhere = msg.L7002_clickHere;
					this.enterButtonText = msg.L7003_enterButton;
					this.username = msg.L7004_usernameLabel;
					this.password = msg.L7005_passwordLabel;
					this.usernameTooltip = msg.L7006_usernameTooltip;
					this.passwordTooltip = msg.L7007_passwordTooltip;
				}
			);

		if (this.clientId) {
			this.setInvalidUrlMsg(true);
		}
		else {
			this.setInvalidUrlMsg(false);
		}

		this.setFlagSource();
		this.setFullSlectedLanguage();
	}

	// Login method.
	// First validate username, password and client id.
	// Then post the log in user object.
	// If login successful, redirect to the home page.
	async onLogin() {
		if (!this.user.uteId) {
			this.toastrService.error(this.translate.instant('login.usrmsg_err.L1003_emptyusername'));
		}
		else if (!this.user.utePassword) {
			this.toastrService.error(this.translate.instant('login.usrmsg_err.L1004_emptypassword'));
		}
		else {
			this.user.uteCliId = this.user.uteCliId.toUpperCase();
			var userProfile = await this.authService.login(this.user, this.secretKey)
								.toPromise()
								.catch(error => this.handleLoginError(error));
			if(userProfile) {
				this.lastLoginInfoService.setState(true);
				this.subscription.unsubscribe();

				this.translate.use(userProfile.tauseDefaultLanguage);
				this.translate.load(['common']);

				let waitMessage = await this.translate.get('common.usrmsg_info.L7026_gridLoadWait').toPromise();
				this.authService.storeGridWaitMessage(waitMessage);
				this.router.navigateByUrl('/home');
			}
			
		}
	}


	private setFlagSource() {
		this.selectedFlag = this.flagImageSource.find(a => a.key == this.user.language).value;
	}

	private setFullSlectedLanguage() {
		this.selectedLanguage = this.flagImageSource.find(a => a.key == this.user.language).description;
	}

	showCloseErrorDialog: boolean = false;

	onErrorDialogConfirm(choice: boolean) {
		console.log(choice);
		this.showCloseErrorDialog = false;
	}

	private handleLoginError(err) {
		if (err.error.message) {
			this.toastrService.error(
				this.translate.instant(`login.${err.error.error_type}.${err.error.message}`),
				this.translate.instant('login.usrmsg_err.L1009_loginFailed')
			);
		}
		else {
			this.showCloseErrorDialog = true;
		}
	}

	ngOnDestroy() {

	}
}




