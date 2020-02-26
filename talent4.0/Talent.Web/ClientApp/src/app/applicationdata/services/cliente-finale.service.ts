import { Injectable } from '@angular/core';
import { CommonServiceOld } from 'shared/services/common.service';
import { Observable } from 'rxjs';
import { AziendeClientiFinale } from 'shared/models/aziende-clienti-finale';

@Injectable({
	providedIn: 'root'
})
export class ClienteFinaleService extends CommonServiceOld {

	// Post the new client finale.
	// Parameter is AziendeClientFinale object.
	// Returns observable of any type.
	saveClienteFinale(clienteFinale: AziendeClientiFinale): Observable<any> {
		return this.http.post('/api/ClientFinale/InsertAziendeClientiFinale', clienteFinale);
	}

	// Post the client finale object to edit.
	// Parameter is AziendeClientFinale object.
	// Returns observable of any type.
	updateClienteFinale(clienteFinale: AziendeClientiFinale): Observable<any> {
		return this.http.put('/api/ClientFinale/UpdateAziendeClientiFinale', clienteFinale);
	}

	// Get the detail of a Cliente finale
	// Parameter is an number.
	// Returns an observable of any type(Cliente finale).
	detail(clienteFinaleId: number): Observable<any> {
		return this.http.get("/api/ClientFinale/FindAziendeClienteFinaleByClifinId/" + clienteFinaleId.toString());
	}

	getAllByAzId(azId: number): Observable<any> {
		return this.http.get("/api/ClientFinale/GetAllAziendeClientiFinaleByAzId/" + azId.toString());
	}
}
