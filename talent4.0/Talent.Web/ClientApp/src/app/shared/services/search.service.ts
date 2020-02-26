import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { GenericSearchedData } from 'shared/models/generic-searched-data';

import { CommonServiceOld } from './common.service';

@Injectable({
	providedIn: 'root'
})
export class SearchService extends CommonServiceOld {

	search(term: Observable<string>) {
		return term.pipe(
			debounceTime(400),
			distinctUntilChanged(),
			switchMap(q => this.searchTerm(q))
		)
	}

	searchTerm(term: string) {
		if (term) {
			return this.http.get<GenericSearchedData[]>(`/api/GlobalGrid/GetGenericSearch/contatti/${this.user.uteCliId}?search=` + term);
		}
		else {
			var emptyList: GenericSearchedData[] = [];
			return of(emptyList);
		}
	}


}
