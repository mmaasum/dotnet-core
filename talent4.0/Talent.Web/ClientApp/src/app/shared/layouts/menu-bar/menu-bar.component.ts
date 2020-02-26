import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subject } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { Azioni } from 'shared/models/azioni';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { FilterService } from 'shared/services/filters.service';
import { SearchService } from 'shared/services/search.service';
import { TranslateService } from 'shared/services/translate.service';
import { LeftMenu } from 'shared/models/leftMenu';

@Component({
	selector: 'app-menu-bar',
	templateUrl: './menu-bar.component.html',
	styleUrls: ['./menu-bar.component.css'],
	providers: []
})

export class MenuBarComponent implements OnInit {

	@ViewChild('confirmationModal', { static: false }) confirmationModal: ModalDirective;

	results: any[] = [];
	searchTerm$ = new Subject<string>();

	loggedInUser: ILoggedInUser;
	isLoggedIn$: Observable<boolean>;
	showLastLoginInfo: boolean = false;
	email: string;
	logAzioni: Azioni = new Azioni("", "", "", "");


	leftMenuList: LeftMenu[] = [];
	leftMenuListMaster: LeftMenu[] = [];


	constructor(
		private authService: AuthService,
		private searchService: SearchService,
		private toastrService: ToastrService,
		private filterService: FilterService,
		private translate: TranslateService
	) {
		this.searchService.search(this.searchTerm$)
			.subscribe(
				response => {
					this.results = response;
				}
			);
	}

	ngOnInit() {
		this.isLoggedIn$ = this.authService.isLoggedIn;
		this.loggedInUser = this.authService.currentUserObject;

		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common']);

		this.email = this.authService.currentUserEmail;
		this.loadMenu();
		
	}

	private loadMenu() {
		if (this.loggedInUser != null) {
			this.authService.getMenuBasedOnLanguage(this.loggedInUser)
				.subscribe(
					response => {
						console.log("Menu => ");
						console.log(response);
						this.leftMenuList = response;
					},
					error => {
						console.log(error);
					}
				);
		}
	}

	onLastLoginInfo() {
		this.showLastLoginInfo = true;
	}

	onLogout() {
		this.confirmationModal.show();
	}

	onHelpClick() {
		this.logAzioni = new Azioni(this.loggedInUser.uteId, "open", this.loggedInUser.uteCliId, "Help page");
		this.logTask();
	}

	onLinkClick() {
		this.toastrService.warning('Not implemented yet!');
	}

	onConfirm() {
		this.confirmationModal.hide();
		this.authService.logout();
	}

	onLastLoginInfoClose(choice) {
		this.showLastLoginInfo = false;
	}

	isVisible(menuItem) {
		return (menuItem.tntmenuParentid == null && this.leftMenuList.some(m => m.tntmenuParentid == menuItem.tntmenuId));
	}

	isVisibleSubMenu(submenuItem) {
		return (submenuItem.tntmenuParentid == null && this.leftMenuList.some(m => m.tntmenuParentid == submenuItem.tntmenuId));
	}

	private logTask() {
		this.filterService.log(this.logAzioni)
			.subscribe(
				response => {
					// console.log(response);
				},
				error => {
					console.log(error);
				}
			);
	}
}
