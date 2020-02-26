import { ActivatedRoute } from '@angular/router';
import { TranslateService } from 'shared/services/translate.service';
import { ToastrService } from 'ngx-toastr';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { AuthService } from 'shared/auth/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-unauthorized',
	templateUrl: './unauthorized.component.html',
	styleUrls: ['./unauthorized.component.css']
})
export class UnauthorizedComponent implements OnInit {

	user: ILoggedInUser;
	language: string = "ENG";
	targetUrl: string = "";

	constructor(
		private authService: AuthService,
		private translate: TranslateService,
		private toastrService: ToastrService,
		private route: ActivatedRoute
	) { }

	ngOnInit() {
		
		this.user = this.authService.currentUserObject;
		if (this.user) {
			this.language = this.user.language;
		}

		this.route.queryParams
			.subscribe(params => {
				this.targetUrl = params.targetURL;
			});

		this.translate.use(this.language);
		this.translate.load(['common']);
	}

	onHelpClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

}
