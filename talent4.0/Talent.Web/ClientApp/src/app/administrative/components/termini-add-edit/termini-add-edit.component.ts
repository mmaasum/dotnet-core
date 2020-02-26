import { ILoggedInUser } from 'shared/models/loggedin-user';
import { FilterService } from 'shared/services/filters.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { Termini } from 'shared/models/termini';
import { KeyValuePair } from 'shared/models/key-value-pair';
import { TranslateService } from 'shared/services/translate.service';
import { TerminiService } from 'app/administrative/services/termini.service';

@Component({
	selector: 'app-termini-add-edit',
	templateUrl: './termini-add-edit.component.html',
	styleUrls: ['./termini-add-edit.component.css']
})
export class TerminiAddEditComponent implements OnChanges, OnInit {

	@Input() isNewRowAdding: boolean;
	@Input() showModal: boolean;
	@Input() selectedTermini: Termini;
	
	@Output() modalCloseEvent = new EventEmitter<boolean>();

	@ViewChild('newObjectAddModal', { static: false }) newObjectAddModal: ModalDirective;
	@ViewChild('newObjectAddForm', { static: false }) newObjectAddForm: HTMLFormElement;
	@ViewChild('existingRecordShowModal', { static: false }) existingRecordShowModal: ModalDirective;

	loggedInUser : ILoggedInUser;
	selectedObject: Termini = new Termini();

	allTerminiStates: KeyValuePair[] = [];
	allTerminiLanguage: KeyValuePair[] = [];
	allTerminiTypes: KeyValuePair[] = [];

	existingTermini: Termini[] = [];
	matchedSinonimi: string[] = [];
	matchedKeywords: string;
	
	tempTerminiForNext: Termini = new Termini();
	isFormSubmitted: boolean = false;
	willOpenWikiOnNext: boolean = false;

	constructor( 
		private toastrService: ToastrService,
		private filterService: FilterService,
		private terminiService: TerminiService,
		private translate: TranslateService,
	) { 
		this.loggedInUser = this.filterService.user;		
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'filter', 'termini']);
	}

	ngOnInit() {
		this.loadInternalFilterDropdownLists();
	}

	

	ngOnChanges() {
		// If showModal=true is setted by the parent component, open the modal
		// else close the modal.    
		if (this.newObjectAddModal != undefined) {
			if (this.showModal) {
				if (this.isNewRowAdding) {
					this.onAdd();
				}
				else {
					this.onEdit();
				}
				this.newObjectAddModal.show();
			}
			else {
				this.newObjectAddModal.hide();
			}
		}
	}

	private loadInternalFilterDropdownLists() {
		this.filterService.getTerminiListTypeFilterData()
			.subscribe(
				response => {
					this.allTerminiStates = response[0];
					this.allTerminiLanguage = response[1];
					this.allTerminiTypes = response[2];
				},
				error => {
					console.log(error);
				}
			)
	}

	// Open the modal with input form when user clicks on ADD NEW COMPANY button.
	onAdd() {
		// Reinitiate newObject.        
		this.selectedObject = null;
		this.selectedObject = new Termini();
		this.setDefaultPropertty();
		this.isFormSubmitted = false;
		this.willOpenWikiOnNext = false;

		this.newObjectAddModal.show();
		
		this.onResetClock();
		// Set submitted property of the form to submitted.
		// So that when user reopen the modal,
		// default validation message of previous form submit is not shown.
		this.newObjectAddForm.submitted = false;
	}

	// Click event of the Edit button
	onEdit() {
		this.selectedObject.terModUteId = this.loggedInUser.uteId;
		this.selectedObject.terTipoTermine = this.selectedObject.terTipoTermine == null ? "" : this.selectedObject.terTipoTermine;
		this.selectedObject.terLingua = this.selectedObject.terLingua == null ? "" : this.selectedObject.terLingua;
		this.selectedObject.terStato = this.selectedObject.terStato == null ? "" : this.selectedObject.terStato;
		this.selectedObject = this.selectedTermini;
		this.newObjectAddModal.show();
		this.onResetClock();
	}


	// Post the form data to server.
	async onNewObjectAddFormSubmit(isDuplicating: boolean = false) {

		// Set object property based on dropdown lists.
		this.fixTerminiObjectBeforeAddOrEdit();
		this.isFormSubmitted = true;

		// Check if form is in valid state or not.
		if (this.newObjectAddForm.valid) {

			if (this.isNewRowAdding || isDuplicating) {
				if(isDuplicating) {
					await this.postOrPutTerminiToDatabase("duplicate");
				}
				else if(!await this.doesTerminiExistsInDb()) {
					await this.postOrPutTerminiToDatabase("save");
				}
			}
			else {
				await this.postOrPutTerminiToDatabase("update");
			}

		}
		else {
			this.toastrService.error(
				this.translate.instant('common.usrmsg_err.L0203_invalidFormData')
			);
		}
	}


	/**
	 * Check if keyword already exists in the database or not.
	 * If exist, show a toast message and return true.
	 * If does not exist(404 error) return false.
	 */
	private async doesTerminiExistsInDb() {
		var errorCode = 0;
		var existingTerminiInDb = await this.terminiService.getTerminiDetails(this.selectedObject.termine).toPromise()
			.catch(
				error => {
					console.log(error);
					errorCode = error.status;
				}
			);
		
		// If response is 404 not found or returned data is undefined,
		// return false.
		// Otherwise return true.
		if((existingTerminiInDb == undefined || existingTerminiInDb == null) && errorCode == 404) {
			return false;
		}		
		else if(errorCode == 0) {
			this.toastrService.error(
				this.translate.instant('termini.usrmsg_warn.L04151_keywordExist', {term : this.selectedObject.termine })
			);
			return true;
		}
	}

	/**
	 * Determine whether to save/update the keyword.
	 * First check if all the synonyms are valid(no duplicate or matched with other keywords)
	 * Then based on type, call either post/put method.
	 * Then if post/put method return true(succeeded), show success toast message
	 * And close/ remain open add/edit modal
	 * @param type 
	 */
	private async postOrPutTerminiToDatabase(type: string) {

		var areSynonymsValid = true;

		// If duplicating a keyword, no need to check synonym validation.
		// Otherwise check if synonyms are valid or not.
		if(type != "duplicate") {			
			areSynonymsValid = await this.areSynonymsAreValid();
		}

		if(areSynonymsValid) {
			var isOperationSuccessfull = false;

			// Adding/Updating new record begin.
			if(type == "save" || type == "duplicate") {
				isOperationSuccessfull = await this.postNew();
			}
			else if(type == "update" || type == "rejectOrReviewed") {
				isOperationSuccessfull = await this.putExisting();
			}
			// Adding/Updating new record end.


			if(isOperationSuccessfull) {

				this.toastrService.success(
					this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg' , {term : this.translate.instant('termini.usrmsg_info.L07160_keyword') })
				);					
				this.newObjectAddForm.submitted = false;
				this.onResetClock();
				// If "Reject & Next"/"Reviewed & Next" button is clicked,
				// Keep add/edit modal open.
				// Otherwise close the modal and call modalClose event handling method.
				if(type != "rejectOrReviewed") {
					//this.onStopWatch();
					this.newObjectAddModal.hide();
					this.onCloseAddEditModal(true);						
				}


			}
			
		}
		
	}



	/**
	 * Check if this termini synonyms are valid or not.
	 * First check if there are any duplicate synonyms in this termini.
	 * If no duplicate, Then check if any synonym of this termini 
	 * match with synonyms/termini of other keywords.
	 * If match found, show matched keywords in a new modal.
	 * Return true, if no duplicate or match found.
	 * Otherwise return false.
	 */
	private async areSynonymsAreValid() {
		var isAllRight = true;
		var synonimoArray: string[] = this.generateSynonimoArray();
		if (!this.hasDuplicateSynonym(synonimoArray)) {
			var matchedTerminis = await this.terminiService.getTerminBySynonym(synonimoArray, this.selectedObject.termine).toPromise();
			
			if (matchedTerminis.length > 0) {
				this.showMatchedKeywords(synonimoArray, matchedTerminis);
				isAllRight = false;
			}
		}
		else {
			isAllRight = false;
		}
		return isAllRight;
	}


	/**
	 * Post new Keyword(Termini) to server for add
	 * Returns true, if successfully added
	 * Otherwise returns false.
	 */
	private async postNew() {
		var isSucceed = true;
		await this.terminiService.saveTermineRecord(this.selectedObject).toPromise()
				.catch(
					error => {
						this.toastrService.error(this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg'));
						console.log(error);
						isSucceed = false; 
					}
				)
		return isSucceed;
	}


	/**
	 * Put existing Keyword(Termini) to server for update
	 * Returns true, if successfully updated
	 * Otherwise returns false.
	 */
	private async putExisting() {
		var isSucceed = true;
		await this.terminiService.updateTermineRecord(this.selectedObject).toPromise()
				.catch(
					error => {
						this.toastrService.error(this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg'));
						console.log(error);
						isSucceed = false; 
					}
				)
		return isSucceed;
	}



	/**
	 * Click event handler of Duplicate button.
	 * Just append "Clone-" at the beginning of keyword,
	 * And set insert/update user as current user
	 */
	onDuplicateClicked() {
		this.selectedObject.termine = "Clone- " + this.selectedObject.termine;
		this.selectedObject.terInsUteId = this.loggedInUser.uteId;
		this.selectedObject.terModUteId = this.loggedInUser.uteId;

		this.onNewObjectAddFormSubmit(true);
	}

	/**
	 * Click event handler of "Set rejected and go next" button.
	 * Store the existing keyword to temp variable.
	 * This temp variable's property(lang, state) will be used for pull next keyword(termini)
	 * Then call the rejectOrReviewAndGoNext method for update the existing keyword.
	 */
	onRejectNextClicked() {
		this.fixTerminiObjectBeforeAddOrEdit();
		this.tempTerminiForNext = Object.assign({}, this.selectedObject);

		this.selectedObject.terStato = "scartato";

		this.rejectOrReviewAndGoNext();
	}


	/**
	 * Click event handler of "Set reviewed and go next" button.
	 * Store the existing keyword to temp variable.
	 * This temp variable's property(lang, state) will be used for pull next keyword(termini)
	 * Then call the rejectOrReviewAndGoNext method for update the existing keyword.
	 */
	onReviewedNextClicked() {
		this.fixTerminiObjectBeforeAddOrEdit();
		this.tempTerminiForNext = Object.assign({}, this.selectedObject);

		this.selectedObject.terStato = "revisionato";

		this.rejectOrReviewAndGoNext();
	}




	private async rejectOrReviewAndGoNext() {

		if (this.newObjectAddForm.valid) {

			var isExist = false;
			if(this.isNewRowAdding) {
				isExist = await this.doesTerminiExistsInDb();
			}

			if(!isExist && (await this.areSynonymsAreValid())) {
				
				var isOperationSuccessfull = false;

				if(this.isNewRowAdding) {
					isOperationSuccessfull = await this.postNew();
				}
				else {
					isOperationSuccessfull = await this.putExisting();
				}
				
				if(isOperationSuccessfull) {
					this.toastrService.success(
						this.translate.instant('common.usrmsg_info.L7011_saveSuccessMsg' , {term : this.translate.instant('termini.usrmsg_info.L07160_keyword') })
					);
					this.onResetClock();
					this.newObjectAddForm.submitted = false;
					this.selectedObject = await this.terminiService.getNextTermini(this.tempTerminiForNext)
													.toPromise()
													.catch(
														error => {
															console.log(error);
															if(error.status == 404) {
																this.toastrService.warning(
																	this.translate.instant('termini.usrmsg_warn.L04154_noKeywordFound')
																);
																this.onCloseAddEditModal(true);
															}
															return new Termini();
														}
													);
					if(this.selectedObject.termine) {
						this.isNewRowAdding = false;
					}
				}
				
			}
			
		}
		else {
			this.toastrService.error(this.translate.instant('common.usrmsg_err.L0203_invalidFormData'));
		}
	}


	private fixTerminiObjectBeforeAddOrEdit() {
		this.selectedObject.terSinonimo1 = this.selectedObject.terSinonimo1 == "" ? null : this.selectedObject.terSinonimo1;
		this.selectedObject.terSinonimo2 = this.selectedObject.terSinonimo2 == "" ? null : this.selectedObject.terSinonimo2;
		this.selectedObject.terSinonimo3 = this.selectedObject.terSinonimo3 == "" ? null : this.selectedObject.terSinonimo3;
		this.selectedObject.terSinonimo4 = this.selectedObject.terSinonimo4 == "" ? null : this.selectedObject.terSinonimo4;
		this.selectedObject.terSinonimo5 = this.selectedObject.terSinonimo5 == "" ? null : this.selectedObject.terSinonimo5;
		this.selectedObject.terSinonimo6 = this.selectedObject.terSinonimo6 == "" ? null : this.selectedObject.terSinonimo6;
		this.selectedObject.terSinonimo7 = this.selectedObject.terSinonimo7 == "" ? null : this.selectedObject.terSinonimo7;
		this.selectedObject.terSinonimo8 = this.selectedObject.terSinonimo8 == "" ? null : this.selectedObject.terSinonimo8;

		this.selectedObject.terStato = this.selectedObject.terStato == "" ? null : this.selectedObject.terStato;
		this.selectedObject.terTipoTermine = this.selectedObject.terTipoTermine == "" ? null : this.selectedObject.terTipoTermine;
		this.selectedObject.terLingua = this.selectedObject.terLingua == "" ? null : this.selectedObject.terLingua;
	}


	// Show Matched keywords in a modal.
	private showMatchedKeywords(synonymArray: string[], existingTermini: Termini[]) {

		var matchedKeywords: string = "";
		var matchedSynonym: string[] = [];
		var showableTermini: Termini[] = [];
		

		// Loop through all synonym array.
		synonymArray.forEach(function (synonym) {
			
			// Loop through all keyword matched termini array.
			existingTermini.forEach(function (termini) {
				
				var thisTermini = new Termini()

				// Check if synonym match with any synonym of current termini.
				if (termini.termine && termini.termine.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo1 && termini.terSinonimo1.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo2 && termini.terSinonimo2.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo3 && termini.terSinonimo3.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo4 && termini.terSinonimo4.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo5 && termini.terSinonimo5.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo6 && termini.terSinonimo6.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo7 && termini.terSinonimo7.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				else if (termini.terSinonimo8 && termini.terSinonimo8.toLowerCase() == synonym.toLowerCase()) {
					thisTermini.terSinonimo1 = synonym;
				}
				

				// if this synonym matched with any termini of Matched Termini list,
				// then push the termini into showable termini array
				// and push the synonym into matched synonym array.
				// append the synonym with matched keyword variable seperated by comma.
				if (thisTermini.terSinonimo1 != null && !showableTermini.some(a => a.termine == termini.termine)) {
					thisTermini.termine = termini.termine;
					thisTermini.terTipoTermine = termini.terTipoTermine;
					thisTermini.terStato = termini.terStato;
					thisTermini.terLingua = termini.terLingua;
					matchedSynonym.push(synonym);
					showableTermini.push(thisTermini);
					matchedKeywords += synonym + ", ";
				}
			});
		});

		
		
		// Remove the last comma from matched keyword string.
		this.matchedKeywords = matchedKeywords.substring(0, (matchedKeywords.length - 2));
		this.matchedSinonimi = matchedSynonym;
		this.existingTermini = showableTermini;
		// Open the matched keywords showing modal.
		this.existingRecordShowModal.show();
	}

	// Generate an array with all the synonym inserted in the add/edit termini form.
	private generateSynonimoArray() {
		var sinonimoArray = [];
		if (this.selectedObject.terSinonimo1 != null) sinonimoArray.push(this.selectedObject.terSinonimo1);
		if (this.selectedObject.terSinonimo2 != null) sinonimoArray.push(this.selectedObject.terSinonimo2);
		if (this.selectedObject.terSinonimo3 != null) sinonimoArray.push(this.selectedObject.terSinonimo3);
		if (this.selectedObject.terSinonimo4 != null) sinonimoArray.push(this.selectedObject.terSinonimo4);
		if (this.selectedObject.terSinonimo5 != null) sinonimoArray.push(this.selectedObject.terSinonimo5);
		if (this.selectedObject.terSinonimo6 != null) sinonimoArray.push(this.selectedObject.terSinonimo6);
		if (this.selectedObject.terSinonimo7 != null) sinonimoArray.push(this.selectedObject.terSinonimo7);
		if (this.selectedObject.terSinonimo8 != null) sinonimoArray.push(this.selectedObject.terSinonimo8);
		return sinonimoArray;
	}

	// Check if there are anym duplicate synonym.
	// If found, show an warning message and return true.
	// Else return false.
	private hasDuplicateSynonym(sinonimoArray: string[]) {
		var length = sinonimoArray.length;
		if (length < 2) return false;
		var matchFound = false;
		var errorMsg = "";

		for (let i = 0; i < (length - 1); i++) {
			for (let j = (i + 1); j < length; j++) {
				if (sinonimoArray[i].toLowerCase() == sinonimoArray[j].toLowerCase()) {
					errorMsg += this.translate.instant('termini.usrmsg_warn.L04152_sameSynonym', {syn1 : (i + 1), syn2 : (j + 1) } );
					matchFound = true
				}
			}
		}
		if (matchFound) {
			this.toastrService.warning(errorMsg);
		}
		return matchFound;
	}

	private setDefaultPropertty() {
		this.selectedObject.terInsUteId = this.loggedInUser.uteId;
		this.selectedObject.terModUteId = this.loggedInUser.uteId;
		this.selectedObject.terCliId = this.loggedInUser.uteCliId;
		this.selectedObject.terLingua = this.loggedInUser.language;
		this.selectedObject.terInsTimestamp = new Date();
		this.selectedObject.terTipoTermine = "";
		this.selectedObject.terStato = "";
	}

	onCloseAddEditModal(choice) {
		this.onStopWatch();
		this.modalCloseEvent.emit(choice);
	}




	/**
	 * On Open Wikipedia button click,
	 * Open a wikipedia link in new tab with sear query of given keyword
	 */
	onOpenWikipedia() {
		if(this.selectedObject.termine) {
			var lang = "en";
			switch(this.selectedObject.terLingua) {
				case "ITA" :
					lang = "it";
					break;
				case "ESP" :
					lang = "es";
					break;
				default :
					break;
			}
			var link = `https://${lang}.wikipedia.org/w/index.php?search=${encodeURI(this.selectedObject.termine)}`;
			window.open(link, "_blank");
		}
		else {
			this.toastrService.warning(
				this.translate.instant('termini.usrmsg_warn.L04153_provideKeyword')
			);
		}

	}

	/**
	 * On Open useful synonym websites button click,
	 * Open a google search link in new tab with sear query of given keyword
	 */
	onOpenUsefulSites() {
		if(this.selectedObject.termine) {
			var link = "https://www.google.com/search?q=" + encodeURI(this.selectedObject.termine + " synonym");
			window.open(link, "_blank");
		}
		else {
			this.toastrService.warning(
				this.translate.instant('termini.usrmsg_warn.L04153_provideKeyword')
			);
		}

	}


	onNotImplementedClicked() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}




	//==================================================================
	//					STOPWATCH LOGIC BEGIN
	//==================================================================

	watchString: string = "00:00:00";
	timerRef: any;
	counterWatch: number = 0;

	private startWatch() {
		this.timerRef = setInterval(() => {
			this.counterWatch++;
			this.setWatchString();
		}, 1000);
	}

	private setWatchString() {
		var hh = 0;
		var mm = 0;
		var ss = 0;

		mm = parseInt((this.counterWatch / 60).toString());

		hh = parseInt((mm / 60).toString());

		mm = mm % 60;
		ss = this.counterWatch % 60;

		var hhS = hh > 9 ? hh.toString() : ('0'+hh.toString());
		var mmS = mm > 9 ? mm.toString() : ('0'+mm.toString());
		var ssS = ss > 9 ? ss.toString() : ('0'+ss.toString());
		this.watchString = `${hhS}:${mmS}:${ssS}`;
	}

	onResetClock() {
		this.counterWatch = 0;
		clearInterval(this.timerRef);
		this.startWatch();
	}

	onStopWatch() {
		clearInterval(this.timerRef);
		this.watchString = "00:00:00";
	}

	//==================================================================
	//					STOPWATCH LOGIC END
	//==================================================================

}
