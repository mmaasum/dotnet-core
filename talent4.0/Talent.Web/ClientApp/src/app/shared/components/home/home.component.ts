import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'shared/auth/auth.service';

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

	constructor(private auth: AuthService, private router: Router) { }

	ngOnInit() {
		//operazioni
		// Depending on logged in user role redirect user to appropriate page.
		let landingPage = this.auth.currentUserProfile.tauseLandingPage;
		switch (landingPage) {
			case "azioni":
				this.router.navigate(['/azioni']);
				break;
			case "gestione_aziende":
				this.router.navigate(['/aziende']);
				break;
			case "log_operazioni":
				this.router.navigate(['/operazioni']);
				break;
			// case "recruiter" :
			//   this.router.navigate(
			//     ['/richieste'], 
			//     {
			//       queryParams : {type : 'self'}, 
			//       queryParamsHandling: 'merge'
			//     }
			//   ); 
			//   break;
			default:
				this.router.navigate(['/admin/home']);
				break;
		}
	}


}
