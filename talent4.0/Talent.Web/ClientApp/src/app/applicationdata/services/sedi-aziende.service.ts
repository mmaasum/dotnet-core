import { SediAzienda } from './../../shared/models/sedi-aziende';
import { Injectable } from '@angular/core';
import { CommonServiceOld } from 'shared/services/common.service';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class SediAziendeService extends CommonServiceOld {

	getAll(): Observable<any> {
		return this.http.get("/api/SediAziende/GetAllSediAziende/" + this.user.uteCliId);
	}

	getAllByAzId(azId: number): Observable<any> {
		return this.http.get("/api/SediAziende/GetAllSediAziendeByAzSedeAzId/" + azId.toString());
	}

	// Create new Aziende.
	// Parameter is an aziende/company object.
	// Returns an observable of any type.
	create(newObject: SediAzienda): Observable<any> {
		return this.http.post("/api/SediAziende/InsertSediAziende", newObject);
	}

	// Update an existing aziende.
	// Parameter is an existing aziende.
	// Returns an observable of any type.
	update(newObject: SediAzienda): Observable<any> {
		return this.http.put('/api/SediAziende/UpdateSediAziende/', newObject);
	}

	// Get the detail of a sedi aziende/
	// Parameter is an number.
	// Returns an observable of any type(Sedi Aziede).
	detail(sedeAzId: number): Observable<any> {
		return this.http.get("/api/SediAziende/FindSediAziendeBySedeId/" + sedeAzId.toString());
	}
}
