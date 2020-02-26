import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
	selector: 'app-machine-learning-matching-button',
	template: `<button style="height: 20px" (click)="invokeParentMethod()" class="btn btn-info">
              <i class="fa fa-list"></i> Machine Learning Matching
            </button>`
})
export class MachineLearningMatchingButtonComponent implements ICellRendererAngularComp {

	public params: any;

	agInit(params: any): void {
		this.params = params;
	}

	public invokeParentMethod() {
		this.params.context.componentParent.loadMatchingRecord();
	}

	refresh(): boolean {
		return false;
	}

}
