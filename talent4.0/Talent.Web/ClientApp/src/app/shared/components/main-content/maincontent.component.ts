import { TranslateService } from './../../services/translate.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { LeftMenu } from 'shared/models/leftMenu';
import { ModalDirective } from 'ngx-bootstrap';
import { CommonGridBehaviour } from 'shared/models/common-grid-behaviour';
import { FilterService } from 'shared/services/filters.service';
import { ToastrService } from 'ngx-toastr';
import { Azioni } from 'shared/models/azioni';

@Component({
	selector: 'main-content',
	templateUrl: './maincontent.component.html'
})

export class MainContentComponent extends CommonGridBehaviour implements OnInit {
	public setColumnDefinations(): void {
		throw new Error("Method not implemented.");
	}

	@ViewChild('confirmationModal', { static: false }) confirmationModal: ModalDirective;

	loggedInUser: ILoggedInUser;
	isLoggedIn$: Observable<boolean>;
	welcome: string;
	email: string;

	leftMenuList: LeftMenu[];
	leftMenuListMaster: LeftMenu[];

	constructor(public authService: AuthService,
		public toastrService: ToastrService,
		public filterService: FilterService,
		public translate: TranslateService) {
		super(filterService, authService, toastrService, translate, "");
	}
	multiLanguageLable: any;
	ngOnInit() {

		this.getMultiLanguageCommonLables();

		this.multiLanguageLable = this.getMultiLanguegeData()
			.subscribe(
				response => {
					this.multiLanguageLable = response.multiLanguage.login
					[this.loggedInUser.language.toLowerCase()];
				},
				error => {
					console.log(error);
				}
			);

		this.isLoggedIn$ = this.authService.isLoggedIn;
		this.loggedInUser = this.authService.currentUserObject;
		this.email = this.authService.currentUserEmail;
	}

	onLogout() {
		this.confirmationModal.show();
	}

	onHelpClick() {
		this.logAzioni = new Azioni(this.loggedInUser.uteId, "open", this.loggedInUser.uteCliId, "Help page");
		this.logTask();
	}


	onConfirm() {
		this.confirmationModal.hide();
		this.authService.logout();
	}

	isVisible(menuItem) {
		return (menuItem.tntmenuParentid == null && this.leftMenuList.some(m => m.tntmenuParentid == menuItem.tntmenuId));
	}
}
