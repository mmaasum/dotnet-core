import { TestValutazione } from 'shared/models/test-valutazione';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TestCompetenze } from 'shared/models/test-competenze';
import { TestResultati } from 'shared/models/test-resultati';
import { CommonServiceOld } from 'shared/services/common.service';
import { Email } from 'shared/models/email';
import { DefaultMail } from 'shared/models/default-mail';

@Injectable({
	providedIn: 'root'
})
export class HardSkillService extends CommonServiceOld {

	/**
	 * Get all the hard skills.
	 * GET : api/HardSkill/GetHardSkill/{risId}.
	 * @param risId 
	 * Output is observable of TestResultati array.
	 */
	getHardSkills(risId: number) {
		return this.http.get<TestResultati[]>('api/HardSkill/GetHardSkill/' + risId.toString());
	}

	// Get all the competenze(competence) list.
	// GET : api/HardSkill/GetAllCompetenza/{clientId}.
	// Output is observable of any type.
	getAllCompetenze(): Observable<any> {
		return this.http.get('api/HardSkill/GetAllCompetenza/' + this.user.uteCliId);
	}

	// Get all the evaluations.
	// GET : api/HardSkill/GetAllTestValutazione/{competenze}/{clientId}.
	// Parameter is competenze : string.
	// Output is observable of any type.
	getTestValutazione(risId: number, type: string) {
		return this.http.get<TestValutazione[]>('api/HardSkill/GetMandatoryTestValutazione/' + this.user.uteCliId + '/' + risId.toString() + '/' + type);
	}

	// Post the selected evaluation.
	// POST : api/HardSkill/SendHardSkillInvitation/{risId}/{clientId}.
	// Parameter is ris Id : number, titolo : TestValutazione.
	// Output is observable of any type.
	sendHardSkillInvitation(risId: number, titoloList: string[]): Observable<any> {
		return this.http.post('api/HardSkill/SendHardSkillInvitation/' + risId.toString() + "/" + this.user.uteCliId, titoloList);
	}


	sendInvitation(email: Email) {
		return this.http.post<any>('/api/Survey/TestEmail', email);
	}

	getDefaultMail() {
		return this.http.get<DefaultMail[]>('/api/HardSkill/GetMailModelObj/' + this.user.language);
	}

}
