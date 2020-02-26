import { ILoggedInUser } from 'shared/models/loggedin-user';
import { TranslateService } from 'shared/services/translate.service';
import { TerminiService } from 'app/administrative/services/termini.service';
import { Component, OnInit, ViewChild, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
	selector: 'app-termini-all-stats',
	templateUrl: './termini-all-stats.component.html',
	styleUrls: ['./termini-all-stats.component.css']
})
export class TerminiAllStatsComponent implements OnChanges, OnInit {


	@Input() showModal: boolean;

	@Output() modalCloseEvent = new EventEmitter<boolean>();


	@ViewChild('allStatsModal', { static: true }) allStatsModal: ModalDirective;

	user:ILoggedInUser;

	constructor(
		private terminiService : TerminiService,
		private translate: TranslateService
	) {
		this.user = this.terminiService.user;
		console.log(this.user);
		this.translate.use(this.user.language);
		this.translate.load(['termini']);
	 }

	ngOnChanges() {
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    

		if (this.showModal) {
			this.allStatsModal.show();
		}
		else {
			this.allStatsModal.hide();
		}
	}

	ngOnInit() {
		this.setColumnDefinition();
	}



	//==================================================
	//				FIRST TABLE BEGIN
	//==================================================
	colDefFirstTable : any;
	colDefSecondTable : any;
	defaultColDef = {      
		sortable: true,
		filter: true
	};

	group1 : any;
	group2 : any;

	private setColumnDefinition() {
		this.translate.get('termini.usrmsg_info')
		.subscribe(
			tra => {
				this.colDefFirstTable = [
					{ headerName: tra.L07152_state, field: "groupByFieldName" },
					{ headerName: tra.L07153_language, field: "groupByCount" },
					{ headerName: tra.L07182_noOfWords, field: "groupByCount" }
				];
				this.colDefSecondTable = [
					{ headerName: tra.L07184_last6Analysis, field: "groupByFieldName" },
					{ headerName: tra.L07153_language, field: "groupByCount" },
					{ headerName: "# CV", field: "groupByCount" },
					{ headerName: tra.L07182_noOfWords, field: "groupByCount" },
					{ headerName: tra.L07183_totalWords, field: "groupByCount" }
				];
			}
		);
		
	}
	


	//==================================================
	//				FIRST TABLE END
	//==================================================



	/**
	 * Close the modal
	 */
	onCloseAllStatsModal() {
		this.allStatsModal.hide();
		this.modalCloseEvent.emit(true);
	}

}
