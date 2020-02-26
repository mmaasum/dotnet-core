import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { CommonServiceOld } from 'shared/services/common.service';
import { Termini, TerminiReviewInfo } from 'shared/models/termini';
@Injectable({
	providedIn: 'root'
})
export class TerminiService extends CommonServiceOld {
	private baseUrl = 'api/termini';

	// For a given termini name and client id, this method retrieve the detail.
	// Parameter is termini name.
	// Returns an observable of any type.
	getTerminiDetails(terminiName: string): Observable<any> {
		return this.http.get(`${this.baseUrl}/getterminidetails/${terminiName}/${this.user.uteCliId}`);
	}

	// Update an existing termini.
	// Parameter is an existing termini.
	// Returns an observable of any type.
	updateTermineRecord(termini: Object): Observable<Object> {
		return this.http.put('/api/termini/updatetermini/', termini);
	}

	// Create new termini.
	// Parameter is an termini/keyword object.
	// Returns an observable of any type.
	saveTermineRecord(termini: Termini): Observable<any> {
		return this.http.post(`${this.baseUrl}/savetermini`, termini);
	}

	// Get all tipi termine.
	// Tipi termine is a foreign key in termini table.
	// For a specific client id retrieves all the tipi termine.
	getAllTipiTermine(): Observable<any> {
		return this.http.get(`/api/termini/gettipiterminis/${this.user.uteCliId}`);
	}

	// This method checks if there is any termini with one of these synonym exists or not.
	// While checking in the server end, given termini name is discarded.
	// So that in the termini edit submit, synonyms are not checked with itself.
	// Parameter is string array of synonyms and termini name of a termini object.
	// Returns observable of any type.
	getTerminBySynonym(sinonimoArray: string[], termini: string) {
		return this.http.post<Termini[]>("/api/Termini/GetAllTerminiBySinonimo/" + termini + "/" + this.user.uteCliId, sinonimoArray);
	}


	getLastKeywordRunInfo() {
		let info = new TerminiReviewInfo();
		info.noOfKeyword = 25;
		info.lastAnalysisTime = new Date();
		return of(info);
		//return this.http.get<TerminiReviewInfo>(`/api/Termini/GetLastAnalysisInfo/${this.user.uteCliId}/${this.user.uteId}`);
	}

	getNextTermini(termini : Termini) {
		return this.http.post<Termini>('/api/Termini/GetNextTermini', termini);
	}
}
