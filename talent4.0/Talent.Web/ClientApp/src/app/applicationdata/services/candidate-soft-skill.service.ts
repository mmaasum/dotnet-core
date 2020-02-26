import { Injectable } from '@angular/core';
import { CommonServiceOld } from 'shared/services/common.service';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class CandidateSoftSkillService extends CommonServiceOld {

	// Get all the hard skills.
	// GET : api/HardSkill/GetHardSkill/{risId}.
	// Parameter is ris Id : number.
	// Output is observable of any type.
	getSoftSkills(risId: number): Observable<any> {
		return this.http.get('/api/SoftSkill/GetSavedWsResultByRisId/' + risId.toString() + "/" + this.user.language);
	}
}
