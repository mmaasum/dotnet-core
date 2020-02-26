import { Azioni } from 'shared/models/azioni';
import { ILoggedInUser } from 'shared/models/loggedin-user';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ILogInUser } from 'shared/models/login-user';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map, take, catchError } from 'rxjs/operators';
import { IDecodedToken } from 'shared/models/decoded-token';
import { UserProfileInfo } from 'shared/models/user-profile-info';


@Injectable({
	providedIn: 'root'
})

export class AuthService {

	private loggedIn = new BehaviorSubject<boolean>(false);

	constructor(
		private router: Router,
		private http: HttpClient
	) { }


	// Left menu will be populated
	// based on the user logedin radio button choice.
	// Parameter : loggedINUser object.
	// Return : List of authorized menu and submenu from database.  
	getMenuBasedOnLanguage(user: ILoggedInUser): Observable<any> {

		if (user != null) {
			return this.http.get(`/api/MultiLanguage/GetUtentiMenu/${user.language}/${user.uteId}/${user.uteCliId}`);
		}

	}

	// Get the Clients to show in Client dropdown list of login form.
	getClientsForLogin(userName: string) {
		return this.http.get('/api/Utenti/GetCliListByUteId/' + userName);
	}

	// Authenticate user.
	// store the token from API response and 
	// user in local storage,
	// return back original response object.
	login(user: ILogInUser, secretKey: string): Observable<UserProfileInfo> {
		return this.http.post('/api/auth/login', user)
			.pipe(
				take(1),
				map(response => {
					let result = JSON.parse(JSON.stringify(response));
					if (result && result.userAuthList) {
						this.storeUserAuthList(result.userAuthList);
					}
					if (result && result.email) {
						this.storeUserEmail(result.email);
					}
					if (result && result.userProfile) {
						this.storeUserProfile(result.userProfile)
					}
					if (result && result.token) {
						this.storeLoggedInInformation(user, result.token, secretKey, result.userProfile);
						return result.userProfile;
					}
				}),
				catchError(error => {
					throw error;
				})
			);
	}

	// Log out user.
	// send a logout request to server and 
	// if successful, remove token and user from local storage and return true
	// if failed, return false.
	logout(): void {
		var cliId = this.currentUserObject.uteCliId;
		var secretKey = this.currentUserObject.secretKey;
		var logObj = new Azioni(this.currentUserObject.uteId, "logout_user", this.currentUserObject.uteCliId, "logout");

		this.http.post("/api/Azioni/postAzioni", logObj)
			.subscribe(
				response => {
					this.removeLoggedInInformation();
					this.router.navigate(['/login', cliId, secretKey]);
				},
				error => {
					console.log(error);
				}
			);
	}

	// Get the user logged in status.
	get isLoggedIn(): Observable<boolean> {
		let status = true;
		let token = localStorage.getItem('access-token');
		if (!token) {
			status = false;
			this.loggedIn.next(status);
		}
		else if (this.isTokenExpired()) {
			status = false;
			this.loggedIn.next(status);
			this.router.navigate(['/login', this.currentUserObject.uteCliId, this.currentUserObject.secretKey]);
		}

		if (status) {
			this.loggedIn.next(status);
		}
		else {
			this.removeLoggedInInformation();
		}
		return this.loggedIn.asObservable();
	}

	// Return the current logged in user instance
	// from localstorage after decoding jwt token.
	get currentUser() {
		const helper = new JwtHelperService();
		let token = localStorage.getItem('access-token');
		if (!token)
			return null;

		const decodedToken = helper.decodeToken(token);
		let decodedObject: IDecodedToken = {
			name: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
			role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
			exp: decodedToken["exp"]
		};
		return decodedObject;
	}

	// Store logged in user data into local storage.
	private storeLoggedInInformation(user: ILogInUser, token: string, secretKey: string, userProfile: UserProfileInfo) {
		let loggedInUser: ILoggedInUser = {
			uteId: user.uteId,
			uteCliId: user.uteCliId,
			language: user.language,
			secretKey: secretKey
		};
		if (userProfile != undefined) {
			loggedInUser.uteId = userProfile.tauseUteId;
			loggedInUser.uteCliId = userProfile.tauseCliId;
			loggedInUser.language = userProfile.tauseDefaultLanguage;
		}
		localStorage.setItem('access-token', token);
		localStorage.setItem('loggedin-user', JSON.stringify(loggedInUser));
	}

	// Remove logged in user data from local storage.
	removeLoggedInInformation() {
		this.loggedIn.next(false);
		localStorage.removeItem('access-token');
		localStorage.removeItem('loggedin-user');
		localStorage.removeItem('auth-list');
		localStorage.removeItem('user-email');
		localStorage.removeItem('user-profile');
		localStorage.removeItem('grid-wait-msg');
	}

	// Store user auth list in the local storage.
	private storeUserAuthList(list: string[]) {
		localStorage.setItem('auth-list', JSON.stringify(list));
	}

	// Store user email in the local storage.
	private storeUserEmail(email: string) {
		localStorage.setItem('user-email', email);
	}

	private storeUserProfile(userProfile: UserProfileInfo) {
		localStorage.setItem('user-profile', JSON.stringify(userProfile));
	}

	storeGridWaitMessage(msg : string) {
		localStorage.setItem('grid-wait-msg', msg);
	}


	// Return the currrent logged in user email.
	get currentUserEmail(): string {
		return localStorage.getItem('user-email');
	}

	get currentUserProfile(): UserProfileInfo {
		let userProfileStr = localStorage.getItem('user-profile');
		if (!userProfileStr)
			return null;
		let userProfile: UserProfileInfo = JSON.parse(userProfileStr);
		return userProfile;
	}



	// Return the currrent logged in user information.
	get currentUserObject(): ILoggedInUser {
		let loggedInUserStr = localStorage.getItem('loggedin-user');
		if (!loggedInUserStr)
			return null;

		let loggedInUser: ILoggedInUser = JSON.parse(loggedInUserStr);
		return loggedInUser;
	}

	// Find out if logged in user has certain authorization.
	userIsInAuth(auth: string): boolean {
		var hasAccess = true;
		if (this.isTokenExpired()) {
			hasAccess = false;
		}

		let authListStr = localStorage.getItem('auth-list');
		let authList: string[] = JSON.parse(authListStr);
		if (authList == null) {
			hasAccess = false;
		}
		else if (!authList.includes(auth)) {
			hasAccess = false;
		}

		// if(!hasAccess){
		//    this.loggedIn.next(false);
		//    this.removeLoggedInInformation();
		// }

		return hasAccess;
	}

	// Check if token is expired or not.
	isTokenExpired(): boolean {
		let token = localStorage.getItem('access-token');

		if (!token)
			return true;

		const date = this.getTokenExpirationDate(token);
		if (date === undefined) return false;
		var access = !(date.valueOf() > new Date().valueOf());

		// If token is expired, log session expire message in server.
		if (access) {
			this.logSessionExpiredMessage();
		}
		return access;
	}

	// Return token expiration date.
	getTokenExpirationDate(token: string): Date {
		const decoded = this.currentUser;

		if (decoded.exp === undefined) return null;

		const date = new Date(0);
		date.setUTCSeconds(decoded.exp);
		return date;
	}

	// Log session expire message in server.
	logSessionExpiredMessage() {
		var logObj = new Azioni(this.currentUserObject.uteId, "user_session_expired", this.currentUserObject.uteCliId, "logout");

		// this.http.post("/api/Azioni/postAzioni", logObj)
		// .subscribe(
		//   response => {
		//     // console.log(response);
		//   }
		// );
	}


	validateClient(clientId: string, secretKey: string): Observable<any> {
		return this.http.get(`/api/Clienti/GetClientLogo/${clientId}/${secretKey}`);
	}
}
