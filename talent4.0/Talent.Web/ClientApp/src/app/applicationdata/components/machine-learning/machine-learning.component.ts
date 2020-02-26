import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Clienti } from 'shared/models/clienti';
import { MLKeywords } from 'shared/models/ML-keywords';
import { MLModels } from 'shared/models/ML-models';

import { MachineLearningService } from './../../services/machine-learning.service';

@Component({
	selector: 'app-machine-learning',
	templateUrl: './machine-learning.component.html',
	styleUrls: ['./machine-learning.component.css']
})
export class MachineLearningComponent implements OnInit {

	@ViewChild('keywordsManagementModal', { static: false }) keywordsManagementModal: ModalDirective;
	@ViewChild('keywordsManagementForm', { static: false }) keywordsManagementForm: HTMLFormElement;

	@ViewChild('modelsManagementModal', { static: false }) modelsManagementModal: ModalDirective;
	@ViewChild('modelsManagementForm', { static: false }) modelsManagementForm: HTMLFormElement;


	// Keyword mangement related properties.
	mlKeyword: MLKeywords = new MLKeywords();
	keywordStartDate: string = "";
	wrappedObject: any;


	// <odel magement related properties.
	mlModel: MLModels = new MLModels();
	modelId: string = "";
	modelStartDate: string = "";
	modelEndDate: string = "";


	allClients: Clienti[] = [];


	constructor(
		private machineLearningService: MachineLearningService,
		private toastrService: ToastrService
	) { }


	// On initialization, get all clients list.
	ngOnInit() {
		this.machineLearningService.getAllClients()
			.subscribe(
				response => {
					this.allClients = response;
				}
			);
	}


	// Open keyword management form modal.
	openKeywordsManagement() {
		this.mlKeyword = new MLKeywords();
		this.keywordsManagementModal.show();
	}

	// Close keyword management form modal.
	onCloseKeywordsManagementModal() {
		this.keywordsManagementModal.hide();
	}

	// Validate and submit keyword management form.
	onKeywordsManagementFormSubmit(form) {
		if (form.valid) {
			if (this.validateKeywordManagementForm()) {

				this.mlKeyword.start_date = this.machineLearningService.formatDateTimeString(this.keywordStartDate, "dd-MM-yyyy");
				this.wrappedObject = {
					params: this.mlKeyword
				}

				this.machineLearningService.updateKeyword(this.wrappedObject)
					.subscribe(
						response => {
							console.log(response);
							this.toastrService.success("Keyword extracted successfully!");
							this.keywordsManagementForm.submitted = true;
							this.keywordsManagementModal.hide();
						},
						error => {
							console.log(error);
							this.toastrService.error("Unexpected error occured!");
						}
					);

			}
		}
		else {
			this.toastrService.error("Invalid form data!!");
		}
	}

	// Validate keyword management form.
	private validateKeywordManagementForm() {
		var isValid: boolean = true;

		if (this.mlKeyword.min_freq_ngrams < 1 || this.mlKeyword.min_freq_ngrams > 5) {
			this.toastrService.error("Min frequency must be between 1-5");
			isValid = false;
		}
		if (this.mlKeyword.entropy_threshold < 0 || this.mlKeyword.entropy_threshold > 1) {
			this.toastrService.error("Entropy threshold must be between 0-1");
			isValid = false;
		}

		return isValid;
	}



	// Open model management form modal.
	openModelsManagement() {
		this.mlModel = new MLModels();
		this.mlModel.customer = this.allClients.length > 0 ? this.allClients[0].cliId : "";
		this.modelsManagementModal.show();
	}

	// Close model management form modal.
	onCloseModelsManagementModal() {
		this.modelsManagementModal.hide();
	}

	// Validate and submit model management form.
	onModelsManagementFormSubmit(form) {
		if (form.valid) {

			this.mlModel.start_date = this.machineLearningService.formatDateTimeString(this.modelStartDate, "yyyyMMdd");
			this.mlModel.end_date = this.machineLearningService.formatDateTimeString(this.modelEndDate, "yyyyMMdd");

			this.machineLearningService.postModel(this.modelId, this.mlModel)
				.subscribe(
					response => {
						console.log(response);
						this.toastrService.success("Model created successfully!");
						this.modelsManagementForm.submitted = true;
						this.modelsManagementModal.hide();
					},
					error => {
						console.log(error);
						this.toastrService.error("Unexpected error occured!");
					}
				);

		}
		else {
			this.toastrService.error("Invalid form data!!");
		}

	}
}
