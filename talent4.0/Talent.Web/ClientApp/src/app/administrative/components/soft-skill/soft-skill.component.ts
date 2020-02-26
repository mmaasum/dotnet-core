import { SoftskillsCompetenzeDescr } from 'shared/models/softskills-comoetenze-descr';
import { SoftSkillService } from '../../services/soft-skill.service';
import { Component, Input, OnChanges, ViewChild, EventEmitter, Output, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-richieste-job-offer',
	templateUrl: './soft-skill.component.html',
	styleUrls: ['./soft-skill.component.css']
})
export class SoftSkillComponent implements OnInit, OnChanges {

	// Input and output variables.
	@Input() richId: string;
	@Input() showModal: boolean;
	@Output() modalCloseEvent = new EventEmitter<string>();

	@ViewChild('jobOfferModal', { static: false }) jobOfferModal: ModalDirective;
	@ViewChild('softSkillsAddForm', { static: false }) softSkillsAddForm: HTMLFormElement;

	// Local variables.
	allSkills: SoftskillsCompetenzeDescr[] = [];
	selectedSkills: string[] = [];
	richDetail: string = "";

	constructor(
		private jobOfferService: SoftSkillService,
		private toastrService: ToastrService) { }

	// On init load all the soft skills.
	ngOnInit() {
		this.jobOfferService.getAllSkills()
			.subscribe(
				response => {
					this.allSkills = response;
				},
				error => {
					console.log(error);
				}
			);
	}

	// On input variable change
	// load the profile detail against a rich id,
	// show or hide job offer modal.
	ngOnChanges() {
		// If rich id is set, get the profile detail of the rich id.
		if (this.richId) {
			this.jobOfferService.getProfileDescription(this.richId)
				.subscribe(
					response => {
						this.richDetail = response;
					}
				);
		}
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    
		if (this.showModal) {
			this.jobOfferModal.show();
		}
		else {
			this.jobOfferModal.hide();
		}
	}

	// On close button click og the job offer modal
	// call the modal close function of the parent component.
	onModalClose() {
		this.jobOfferModal.hide();
		this.modalCloseEvent.emit("closed")
	}

	// On soft skill form submit 
	// check how many soft skills have been checked.
	// If exactly 6 skills are checked, then submit the form.
	// Otherwise show a warning message.
	onSoftSkillsAddFormSubmit(form) {
		// If more or less than 6 skills are checked, show warning message.
		if (this.selectedSkills.length != 6) {
			this.toastrService.warning("6 required. " + this.selectedSkills.length + " selected!!");
		}
		// Else submit the selected skill array.
		else {
			this.jobOfferService.saveJobSkill(this.richId, this.selectedSkills)
				.subscribe(
					response => {
						this.toastrService.success("Skills saved successfully!");
						this.jobOfferModal.hide();
						this.selectedSkills.splice(0, this.selectedSkills.length);
					},
					error => {
						console.log(error);
						this.toastrService.error(error.error.message, error.error.error);
					}
				);
		}
	}

	// On change event of the skill checkbox.
	// If a skill is checked, add it to the selectedSkills array.
	// If a skill is unchecked, remove it from selectedSkills array.
	onSkillCheck(event) {
		if (event.target.checked) {
			this.selectedSkills.push(event.target.defaultValue);
		}
		else {
			let indexOfElement = this.selectedSkills.indexOf(event.target.defaultValue);
			this.selectedSkills.splice(indexOfElement, 1);
		}
	}
}
