import { KeyValuePair } from 'shared/models/key-value-pair';
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";
import { CommonServiceOld } from "shared/services/common.service";

@Injectable()
export class AzioniService extends CommonServiceOld {
	getAllTipoAzione()  {
		return this.http.get<KeyValuePair[]>(`/api/Azioni/getallazionitype/${this.user.language}`);
	}
}