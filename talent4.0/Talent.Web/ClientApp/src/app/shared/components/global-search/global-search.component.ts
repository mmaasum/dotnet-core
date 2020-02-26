import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

import { SearchService } from './../../services/search.service';

@Component({
	selector: 'app-global-search',
	templateUrl: './global-search.component.html',
	styleUrls: ['./global-search.component.css']
})
export class GlobalSearchComponent implements OnInit {

	results: any[] = [];
	searchTerm$ = new Subject<string>();

	constructor(private searchService: SearchService) {
		this.searchService.search(this.searchTerm$)
			.subscribe(
				response => {
					this.results = response;
				}
			);
	}

	ngOnInit() {
	}

}