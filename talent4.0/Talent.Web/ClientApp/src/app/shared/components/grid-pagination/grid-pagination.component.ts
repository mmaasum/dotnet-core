import { Component, OnInit, EventEmitter, Input, Output, OnChanges } from '@angular/core';

@Component({
	selector: 'app-grid-pagination',
	templateUrl: './grid-pagination.component.html'
})
export class GridPaginationComponent implements OnChanges {

	@Input('total-items') totalItems;
	@Input('page-size') pageSize = 20;
	@Output('page-changed') pageChanged = new EventEmitter();

	pages: any[];
	currentPage = 1;
	pagesCount = 1;

	ngOnChanges() {
		this.currentPage = 1;
		var pagesCount = Math.ceil(this.totalItems / this.pageSize);
		this.pagesCount = pagesCount;
		this.pages = [];
		for (var i = 1; i <= pagesCount; i++)
			this.pages.push(i);
	}

	// On page number select in the pagination
	// set currentPage = selected page number,
	// emit the pagination page change event.
	changePage(page) {
		this.currentPage = page;
		this.pageChanged.emit(page);
	}

	// On previous button click in the pagination
	// decrease the current page number and
	// emit the pagination page change event.
	previous() {
		if (this.currentPage == 1)
			return;

		this.currentPage--;
		this.pageChanged.emit(this.currentPage);
	}

	// On next button click in the pagination
	// increase the current page number and
	// emit the pagination page change event.
	fastBackward() {
		if (this.currentPage == 1)
			return;

		this.currentPage = 1;
		this.pageChanged.emit(this.currentPage);
	}

	// On next button click in the pagination
	// increase the current page number and
	// emit the pagination page change event.
	next() {
		if (this.currentPage == this.pagesCount)
			return;

		this.currentPage++;
		this.pageChanged.emit(this.currentPage);
	}

	// On next button click in the pagination
	// increase the current page number and
	// emit the pagination page change event.
	fastForward() {
		if (this.currentPage == this.pagesCount)
			return;

		this.currentPage = this.pagesCount;
		this.pageChanged.emit(this.currentPage);
	}

}
