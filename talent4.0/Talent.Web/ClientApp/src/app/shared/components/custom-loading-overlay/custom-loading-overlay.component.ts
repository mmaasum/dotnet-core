import { ILoggedInUser } from './../../models/loggedin-user';
import { TranslateService } from './../../services/translate.service';
import { Component, Input } from '@angular/core';
import { ILoadingOverlayAngularComp } from "ag-grid-angular";

@Component({
	selector: 'app-loading-overlay',
	templateUrl: './custom-loading-overlay.component.html',
	styleUrls: ['./custom-loading-overlay.component.css']
})

export class CustomLoadingOverlay implements ILoadingOverlayAngularComp {

	private params: any;
	private msg : string = "";

	constructor(public translate : TranslateService) {
		this.msg = localStorage.getItem('grid-wait-msg');
	}

	agInit(params): void {
		this.params = params;
	}
}