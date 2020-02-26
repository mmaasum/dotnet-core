import { Component, OnInit } from '@angular/core';
import { version } from '../../../../assets/settings.json';

@Component({
	selector: 'app-footer',
	templateUrl: './footer.component.html',
	styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

	public version: string = version;

	ngOnInit() {

	}

}
