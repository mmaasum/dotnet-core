import { Component, HostListener } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';


@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})
export class AppComponent {

	isLoggedIn$: Observable<boolean>;

	isMobile = false;
	isLoggedIn$2: Observable<boolean>;
	screenSizeMessage: string;
	screenSizeMessageTitle: string;
	isPoc = false;
	@HostListener("window:resize", [])
	onResize() {
		const width = window.innerWidth;

		this.isMobile = (width < 992) ? true : false;
	}

	constructor(private authService: AuthService) { }


	ngOnInit() {
		this.isLoggedIn$ = this.authService.isLoggedIn;
		this.isPoc = true;
	}
}
