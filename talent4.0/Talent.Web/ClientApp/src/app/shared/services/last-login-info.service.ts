import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { Azioni } from 'shared/models/azioni';
import { CommonServiceOld } from 'shared/services/common.service';

@Injectable({
	providedIn: 'root'
})
export class LastLoginInfoService extends CommonServiceOld {

	private firstLoggedIn = new BehaviorSubject<boolean>(false);

	isFirstLogin() {
		return this.firstLoggedIn.asObservable();
	}

	setState(state: boolean) {
		this.firstLoggedIn.next(state);
	}

	lastLogin() {
		this.user = this.auth.currentUserObject;
		return this.http.get<Azioni>(`/api/Azioni/getsecondlastazioni/${this.user.uteCliId}/${this.user.uteId}`)
	}

}
