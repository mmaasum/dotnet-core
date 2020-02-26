import { HttpClient } from '@angular/common/http';
import { Injector, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { ILoggedInUser } from 'shared/models/loggedin-user';

import { Azioni } from '../models/azioni';

@Injectable()
export class CommonService {

	user: ILoggedInUser;
	auth: AuthService;
	http: HttpClient;

	constructor(public injector: Injector) {
		this.auth = this.injector.get(AuthService);
		this.http = this.injector.get(HttpClient);
		this.user = this.auth.currentUserObject;
	}

    /**
        * Log a task into Azioni table.
    */
	log(azioni: Azioni): Observable<any> {
		return this.http.post("/api/Azioni/postAzioni", azioni);
	}

}