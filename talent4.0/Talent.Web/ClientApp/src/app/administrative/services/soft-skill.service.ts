import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonServiceOld } from 'shared/services/common.service';

@Injectable({
  providedIn: 'root'
})
export class SoftSkillService extends CommonServiceOld {

  // Get all the soft skills.
  // GET : api/SoftSkill/GetAllSkill/{language}.
  getAllSkills() : Observable<any> {
    return this.http.get('api/SoftSkill/GetAllSkill/' + this.user.language);
  }

  // Get the profile description against a rich id.
  // GET : api/SoftSkill/GetSoftSkillProfileDescription/{richId}.
  getProfileDescription(richId : string) : Observable<any> {
    return this.http.get('api/SoftSkill/GetSoftSkillProfileDescription/' + richId);
  }

  // Post the selected soft skills.
  // POST : api/SoftSkill/PostSoftSkillProfile/{richId}.
  saveJobSkill(richId: string, selectedSkills : string[]) : Observable<any> {
    return this.http.post('api/SoftSkill/PostSoftSkillProfile/' + richId, selectedSkills);
  }
}