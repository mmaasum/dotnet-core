import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contatti } from 'shared/models/contatti';
import { Email } from 'shared/models/email';
import { CommonServiceOld } from 'shared/services/common.service';

@Injectable({
	providedIn: 'root'
})
export class ContattiService extends CommonServiceOld {

	// Get all the aziende against logged in user's client id.
	// Returns observable of any type.
	getAllAziende(): Observable<any> {
		return this.http.get('/api/aziende/getlistaziende/' + this.user.uteCliId);
	}

	// Create new Contatti.
	// Parameter is a contatti/contact object.
	// Returns an observable of any type.
	createContatti(contatti: Contatti): Observable<any> {
		return this.http.post("/api/contatti/postcontatti", contatti);
	}

	// Update an existing contatti.
	// Parameter is an existing contatti.
	// Returns an observable of any type.
	updateContatti(contatti: Contatti): Observable<any> {
		return this.http.put('/api/contatti/updatecontatti/', contatti);
	}

	// Get all tipo contatto.
	// Returns observable of any type.
	getAllTipoContatto(): Observable<any> {
		return this.http.get("/api/contatti/gettipicontatto/" + this.user.uteCliId);
	}

	// Get all titolo/titles.
	// Returns observable of any type.
	getAllTitoli(): Observable<any> {
		return this.http.get("/api/utenti/GetAllTitoli/" + this.user.uteCliId);
	}

	// Get all the users.
	// For a given specific client id, this method retrieves all the users.
	// For optimization purpose only uteId and uteNome property values are loaded.
	getAllTheUsers(): Observable<any> {
		return this.http.get("/api/Utenti/GetOptimizedUtentiList/" + this.user.uteCliId + "/S");
	}

	// Send email.
	// Parameter is an email object.
	// Returns observable of any type.
	sendEmail(email: Email) {
		return this.http.post("/api/contatti/emailcontatti", email);
	}

	getSedeAziende(azId: number): Observable<any> {
		return this.http.get("/api/SediAziende/GetAllSediAziendeByAzSedeAzId/" + azId.toString());
	}
}
