import { Component, OnInit, HostListener } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';

@Component({
	selector: 'app-wrapper-layout',
	templateUrl: './wrapper-layout.component.html',
	styleUrls: ['./wrapper-layout.component.css']
})
export class WrapperLayoutComponent implements OnInit {

	isLoggedIn$: Observable<boolean>;

	isMobile = false;
	screenSizeMessage: string;
	screenSizeMessageTitle: string;

	@HostListener("window:resize", [])

	onResize() {
		const width = window.innerWidth;

		this.isMobile = (width < 992) ? true : false;
	}

	constructor(private authService: AuthService) { }


	ngOnInit() {
		this.isLoggedIn$ = this.authService.isLoggedIn;
	}

	onActivate($event) {
		window.scroll(0, 0);
		console.clear();
	}
}
