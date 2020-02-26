import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
	providedIn: 'root'
})
export abstract class CustomAuthGuard implements CanActivate {

	constructor(public authService: AuthService, public router: Router) { }

	canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
		
		if(this.handleRoute()) {
			return of(true);
		}
		else {
			let targetUrl = this.fixTargetUrl(state.url);
			this.router.navigate(['/unauthorized'], {queryParams: {targetURL: targetUrl}});
			return of(false);
		}
	}

	abstract handleRoute() : boolean;

	private fixTargetUrl(url : string) {
		if(url.startsWith('/')) {
			url = url.substr(1, url.length);
		}
		return url;
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewAzioniAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewAzioni");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewOperazioniAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewOperazioni");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewUserCreateAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewUserCreate");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewRoleManagementAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewRoleManagement");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewTerminiAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewTermini");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewAziendeAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewAziende");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewContattiAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewContatti");
	}
}


@Injectable({
	providedIn: 'root'
})
export class ViewRichiestaAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewRichieste");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewSurveyInvitationAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewSurveyInvitation");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewRisorseAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewRisorse");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewClienteFinaleAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewClientFinale");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewSediAziendeAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewSediAziende");
	}
}



@Injectable({
	providedIn: 'root'
})
export class ViewMachineLearningAuthGuard extends CustomAuthGuard {
	handleRoute() {
		return this.authService.userIsInAuth("Talent.ViewMachineLearning");
	}
}


