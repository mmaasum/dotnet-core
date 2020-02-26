import { CommonServiceOld } from 'shared/services/common.service';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { Risorse } from 'shared/models/risorse';
import { Titoli } from 'shared/models/titoli';
import { RichiesteListaRisorse } from 'shared/models/richiesteListaRisorse';

@Injectable({
	providedIn: 'root'
})
export class CandidateService extends CommonServiceOld {

	/**
	 * Get the detail Risorse/Candidate of a risorse id.
	 * @param risId 
	 */
	detail(risId: number) {
		return this.http.get<Risorse>('/api/Risorse/GetRisorseDetails/' + risId);
	}

	/**
	 * Create a new Risorse/Candidate.
	 * @param risorse 
	 */
	create(risorse: Risorse) {
		return this.http.post<any>('/api/Risorse/insertrisorse', risorse);
	}

	assignCandidate(richiesteListaRisorse: RichiesteListaRisorse) {
		console.log(richiesteListaRisorse);
		return this.http.post<any>('/api/Richieste/InsertTalentRichlistRisorse', richiesteListaRisorse);
	}

	/**
	 * Update an existing Risorse/Candidate.
	 * @param risorse 
	 */
	update(risorse: Risorse) {
		return this.http.put<any>('/api/Risorse/updaterisorse', risorse);
	}

	/**
	 * Get all titolo/titles.
	 * Returns observable of any type.
	*/
	getAllTitles() {
		return this.http.get<Titoli[]>("/api/utenti/GetAllTitoli/" + this.user.uteCliId);
	}

	/**
	 * Upload a cv file.
	 */
	upload(risId: number, file: File) {
		const formData = new FormData();
		formData.append('file', file);
		return this.http.post(`/api/Risorse/UploadCV/${this.user.uteCliId}/${risId}`, formData);
	}


	/**
	 * Extract cv content as text.
	 */
	scanCv(risId: number) {
		return this.http.get<any>(`/api/Risorse/ScanCV/${this.user.uteCliId}/${risId}`);
	}
}
