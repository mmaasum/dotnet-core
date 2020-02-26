import { Injectable } from '@angular/core';
import { Clienti } from 'shared/models/clienti';
import { MLModels } from 'shared/models/ML-models';
import { CommonServiceOld } from 'shared/services/common.service';

@Injectable({
	providedIn: 'root'
})
export class MachineLearningService extends CommonServiceOld {

	/**
	  * Gets the client list.
	  * Returns Observable<Clienti[]>.
	*/
	getAllClients() {
		return this.http.get<Clienti[]>('/api/Clienti/GetAllClienti');
	}

	/**
	  * Update keyword. 
	  * Parameter is { "param" : MLKeyword }.
	*/
	updateKeyword(param: any) {
		return this.http.put('http://192.168.1.135:5000/api/tables/unipi_risorse_keywords', param);
	}

	/**
	  * Post model. 
	  * Parameters are id : string, mlModel : MLModels.
	*/
	postModel(id: string, mlModel: MLModels) {
		return this.http.post('http://192.168.1.135:5000/api/models/' + id, mlModel);
	}
}
