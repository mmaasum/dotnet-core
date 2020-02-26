import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aziende } from 'shared/models/aziende';
import { CommonServiceOld } from 'shared/services/common.service';
import { UtentiOptimized } from 'shared/models/utenti-optimized';

@Injectable({
	providedIn: 'root'
})
export class AziendeService extends CommonServiceOld {

	// Create new Aziende.
	// Parameter is an aziende/company object.
	// Returns an observable of any type.
	createAziende(aziende: Aziende): Observable<any> {
		return this.http.post("/api/aziende/postaziende", aziende);
	}

	// Update an existing aziende.
	// Parameter is an existing aziende.
	// Returns an observable of any type.
	updateAziende(aziende: Aziende): Observable<any> {
		return this.http.put('/api/aziende/updateaziende/', aziende);
	}

	// Pull all sedi azienda of a specific azienda.
	// For a given aziende azId and client id, 
	// this method gets all the sedi aziende related to that az id.
	// Parameter is an aziende object.
	// Returns an observable of any type.
	getAllSediAzienda(azienda: Aziende): Observable<any> {
		return this.http.get("/api/aziende/GetSediAziende/" + azienda.azId + "/" + azienda.azCliId);
	}

	// Get all the aziende types.
	// For a specific client id, this method gets all the aziende type.
	getAllAziendeTypes(): Observable<any> {
		return this.http.get("/api/Aziende/GetAllTipiAzienda/" + this.user.uteCliId);
	}

	/**
	 * Returns optimized user list depending on the user status flag.
	 * To get only active users, set userStatusFlag = "S"
	 * To get only inactive users, set userStatusFlag = "N"
	 * To get only all users, set userStatusFlag = "A"
	 * @param userStatusFlag 
	 */
	getOptimizedUsersList(userStatusFlag: string): Observable<any> {
		return this.http.get<UtentiOptimized[]>(`/api/Utenti/GetOptimizedUtentiList/${this.user.uteCliId}/${userStatusFlag}`);
	}

	// This method checks if there is any Sigla exists or not.
	// While checking in the server end, given azId is discarded.
	// So that in the aziende edit submit, aziende sigla is not checked with itself.
	// Parameter is azId and sigla of a aziende object.
	// Returns observable of any type.
	findExistingAziendeBySigla(azId: number, sigla: string): Observable<any> {
		return this.http.get("/api/aziende/FindBySiglaRichiestaData/" + azId + "/" + this.user.uteCliId + "/" + sigla);
	}


	getAllTheAziende(): Observable<any> {
		return this.http.get("/api/aziende/GetlistAziende/" + this.user.uteCliId);
	}

}
