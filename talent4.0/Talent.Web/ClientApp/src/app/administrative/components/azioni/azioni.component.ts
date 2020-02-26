import { KeyValuePair } from 'shared/models/key-value-pair';
import { AzioniService } from './../../services/azioni.service';
import { UtentiService } from './../../services/user-create.service';
import { TranslateService } from 'shared/services/translate.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { FilterService } from 'shared/services/filters.service';
import { CommonGridBehaviourNew } from 'shared/models/common-grid-behaviour-new';
import { MasterFilterTemplate } from 'shared/models/master-filter-temp';
import { GridManagementService } from 'shared/services/grid-management.service';
import { UtentiOptimized } from 'shared/models/utenti-optimized';



@Component({
	selector: 'azioni',
	templateUrl: './azioni.component.html',
	providers: [GridManagementService, FilterService, AzioniService]
})

export class AzioniComponent extends CommonGridBehaviourNew implements OnInit {
	

	
	public resetPageSpecificFilterDefaultValues(): void {
		this.allFilters[0].filterType = "like";
		this.allFilters[2].filterType = "like";
		this.allFilters[3].option2 = this.freeSearchFieldExtraColumns;
			
		this.allFilters[4].option1 = this.loggedInUser.language;
		this.allFilters[5].option1 = this.loggedInUser.language;
	}

	public pageSpecificFilterClearTask(): void {
		this.staticOptionChoser = '';
		this.clearFilterDates();
	}
	public pageSpecificPreApplyFilterTasks(): void {
		this.setFilterDates();
	}
	

	columnName : string = 'azioni';
	allUsers : UtentiOptimized[] = [];
	allAzioniTypes : KeyValuePair[] = [];

	fromDate : Date;
	toDate : Date;
	selectedAction : string = '';
	staticOptionChoser : string;


	// Right group by table variables..
	tipiAzioniDescr : any;
	tipiAzioniCategoryDescr : any;

	private freeSearchFieldExtraColumns = "azione_ute_id;azione_dettaglio_01;azione_dettaglio_02;azione_dettaglio_03;azione_dettaglio_04;azione_dettaglio_05;azione_dettaglio_06;ris_nome;ris_cognome;cont_nome;cont_cognome;az_rag_sociale;azione_tipo;rich_descrizione;rich_citta;rich_comp_principale;tipazionecat_descrizione;tpazcatdescr_descrizione";


	constructor( 
		public toastrService: ToastrService,
		public authService: AuthService,
		public filterService: FilterService,
		public translate: TranslateService,
		public gridService: GridManagementService,
		private utenteService: UtentiService,
		private azioniService : AzioniService
	) {
		super(filterService, authService, toastrService, translate, gridService, 'azioni');
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'azioni', 'filter']);
		this.setPageFilterVariableDatas();		
	}

	
	ngOnInit() {
		this.loadUsersList();
		this.loadTipoAzioniList();

		this.loadGridSettingsInformation();

		this.loadColumnDefinationForRightGroupTables();
	}

	setPageFilterVariableDatas() {
		// Filters and sorting data variables
		this.allFilters = [
			{
				columnName: "azione_ute_id",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "azione_ins_timestamp",
				dataType: "datetime",
				filterType: "range",
				option1: "",
				option2: ""
			},
			{
				columnName: "tpazdescr_tipazione_tipo_azione",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "azione_descrizione",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: this.freeSearchFieldExtraColumns
			},
			{
				columnName: "tpazcatdescr_lingua",
				dataType: "text",
				filterType: "equal",
				option1: this.loggedInUser.language,
				option2: ""
			},
			{
				columnName: "tpazdescr_lingua",
				dataType: "text",
				filterType: "equal",
				option1: this.loggedInUser.language,
				option2: ""
			}
		];
		//option2: "azione_ute_id;azione_dettaglio_01;azione_dettaglio_02;azione_dettaglio_03;azione_dettaglio_04;azione_dettaglio_05;azione_dettaglio_06;ris_nome;ris_cognome;cont_nome;cont_cognome;az_rag_sociale;azione_tipo;rich_descrizione;rich_citta;rich_comp_principale;tipazionecat_descrizione;tpazcatdescr_descrizione"
		
		this.sorting = {
			columnName: 'azione_ins_timestamp DESC',
			type: ''
		};
		this.joinTables = [
			{
				joinTableName: "tipi_azione",
				joinFields: [
					{ baseTableJoinFieldName: "azione_tipo", joinTableJoinFieldName: "tipazione_tipo_azione" }
				]
			},
			{
				joinTableName: "tipi_azione_categoria",
				joinFields: [
					{ baseTableJoinFieldName: "tipazione_tipazionecat_codice", joinTableJoinFieldName: "tipazionecat_codice" }
				]
			},
			{
				joinTableName: "tipi_azione_categoria_descr",
				joinFields: [
					{ baseTableJoinFieldName: "tipazionecat_codice", joinTableJoinFieldName: "tpazcatdescr_tipazionecat_codice" }
				]
			},
			{
				joinTableName: "tipi_azione_descr",
				joinFields: [
					{ baseTableJoinFieldName: "tipazione_tipo_azione", joinTableJoinFieldName: "tpazdescr_tipazione_tipo_azione" }
				]
			},
			{
				joinTableName: "risorse",
				joinFields: [
					{ baseTableJoinFieldName: "azione_ris_id", joinTableJoinFieldName: "ris_id" }
				]
			},
			{
				joinTableName: "richieste",
				joinFields: [
					{ baseTableJoinFieldName: "azione_rich_id", joinTableJoinFieldName: "rich_id" }
				]
			},
			{
				joinTableName: "utenti",
				joinFields: [
					{ baseTableJoinFieldName: "azione_ute_id", joinTableJoinFieldName: "ute_id" },
					{ baseTableJoinFieldName: "azione_cli_id", joinTableJoinFieldName: "ute_cli_id" }
				]
			},
			{
				joinTableName: "contatti",
				joinFields: [
					{ baseTableJoinFieldName: "azione_cont_id", joinTableJoinFieldName: "cont_id" }
				]
			},
			{
				joinTableName: "aziende",
				joinFields: [
					{ baseTableJoinFieldName: "cont_az_id", joinTableJoinFieldName: "az_id" }
				]
			},
		];
		this.filterSortingModel = {
			filters: [],
			clientColumn: 'azione_cli_id',
			joinTableQueryDto: {
				joinTable: this.joinTables,
				joinTableRetreivedFields: [
					"ris_nome", "ris_cognome", "cont_nome", "cont_cognome", "rich_descrizione", 
					"rich_citta", "rich_comp_principale", "ute_nome", "az_rag_sociale",
					"tipazionecat_descrizione", "tpazcatdescr_descrizione", "tpazdescr_descrizione",
                    "tpazdescr_tipazione_tipo_azione"
				]
			}
		};		
	}


	// Implement abstract method...
	setColumnDefinations() {
		this.columnDefs = [];
		this.addRemoveRowIndexToGrid();

		this.gridSettings.talentGridFieldsUserList
			.forEach(element => {
				var colDef: any = {
					headerName : element.tntgcuFieldLabelDescription
				};
				//colDef.headerName = element.tntgcuFieldLabelDescription;
				switch (element.tntgcuFieldName) {
					case "id":
						colDef.field = 'azioneId';
						break;
					case "user_id":
						colDef.field = 'azioneUteId';
						break;
					case "user_name":
						colDef.field = 'uteNome';
						break;					
					case "action_description":
						colDef.field = 'azioneDescrizione';
						break;	
					case "action_detail_01":
						colDef.field = 'azioneDettaglio01';
						break;
					case "action_detail_02":
						colDef.field = 'azioneDettaglio02';
						break;
					case "action_detail_03":
						colDef.field = 'azioneDettaglio03';
						break;
					case "action_detail_04":
						colDef.field = 'azioneDettaglio04';
						break;
					case "action_detail_05":
						colDef.field = 'azioneDettaglio05';
						break;
					case "action_detail_06":
						colDef.field = 'azioneDettaglio06';
						break;				
					case "action_insert_date":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.azioneInsTimestamp);
						});
						break;
					case "action_insert_user":
						colDef.field = 'azioneInsUteId';
						break;
					case "exec_time_begin":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.azioneInizio);
						});
						break;
					case "exec_time_fine":
						colDef.valueGetter = (param => {
							return this.formatDateTimeString(param.data.azioneFine);
						});
						break;
					case "contact_id":
						colDef.field = 'azioneContId';
						break;
					case "contact_name":
						colDef.valueGetter = (param => {
								return (param.data.contNome ? param.data.contNome : "")
									+ " "
									+ (param.data.contCognome ? param.data.contCognome : "")
									;
							});
						break;
					case "contact_company_name":
						colDef.field = 'azRagSociale';
						break;
					case "resource_id":
						colDef.field = 'azioneRisId';
						break;
					case "resource_name":
						colDef.valueGetter = (param => {
								return (param.data.risNome ? param.data.risNome : "")
									+ " "
									+ (param.data.risCognome ? param.data.risCognome : "");
							});
						break;
					case "action_place":
						colDef.field = 'azioneLuogo';
						break;
					case "action_type_id":
						colDef.field = 'azioneTipo';
						break;
					case "research_id":
						colDef.field = 'azioneRichId';
						break;


					// =============================================
					// Need to verify from backend....
						
					case "action_type_descr":
						colDef.field = 'tipi_azione_descr_OF_tpazdescr_descrizione';
						break;
					case "action_type_category_descr":
						colDef.field = 'tipi_azione_categoria_descr_OF_tpazcatdescr_descrizione';
						break;					
					case "research_city":
						colDef.field = 'richieste_OF_rich_citta';
						break;
					case "research_competence":
						colDef.field = 'richieste_OF_rich_comp_principale';
						break;
					default:
						break;
				}

				//colDef.width = 250;
				if(element.tntgcuMinSize) {
					colDef.minWidth = element.tntgcuMinSize;
				}
				if(element.tntgcuMaxSize) {
					colDef.maxWidth = element.tntgcuMaxSize;
				}

				var style: any = {};
				if (element.tntgcuFieldTextAlign) {
					style['text-align'] = element.tntgcuFieldTextAlign.toLowerCase();
				}
				if (element.tntgcuFieldFontName) {
					style['font-family'] = element.tntgcuFieldFontName.toLowerCase();
				}
				if (element.tntgcuFieldFontSize) {
					style['font-size'] = element.tntgcuFieldFontSize.toString() + "px!important";
				}
				colDef.cellStyle = style;

				this.columnDefs.push(colDef);
			});


		this.gridOptions.api.setColumnDefs(this.columnDefs);

	}



	loadUsersList() {
		this.utenteService.getOptimizedUsersList("A")
			.subscribe(
				response => {
					this.allUsers = response;
				}
			)
	}

	loadTipoAzioniList() {
		this.azioniService.getAllTipoAzione()
			.subscribe(
				response => {
					this.allAzioniTypes = response;
					console.log("All azioni types => ");
					console.log(this.allAzioniTypes);
				}
			)
	}


	onUserListChange() {
		if(this.allFilters[0].option1) {
			this.allFilters[0].filterType = "equal";
		}
		else{
			this.allFilters[0].filterType = "like";
		}

		this.onApplyFilter();
	}


	onActionTypeChange() {
		if(this.allFilters[2].option1) {
			this.allFilters[2].filterType = "equal";
		}
		else{
			this.allFilters[2].filterType = "like";
		}

		this.onApplyFilter();
	}



	// Initializing the grid.
	// Set filter sorting model properties.
	// Set grid data.
	// Set total records count.
	// Set column width according to column data.
	onGridReady(params) {
		this.setfilterSortingModelData();
		this.fromDate = null;
		this.toDate = null;
		this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
	}



	onRowClicked($event) {
		// console.log($event);
	}




	//========================================================================
	//				RIGHT GROUP TABLE LOGIC SECTION BEGIN
	//========================================================================

	colDefActionType : any;
	colDefActionCategory : any;
	defaultColDefActionType = {      
		sortable: true,
		filter: true
	};
	
	private loadColumnDefinationForRightGroupTables() {
		this.translate.get('azioni.usrmsg_info')
		.subscribe(
			tra => {
				this.colDefActionType = [
					{ headerName: tra.L7125_actionTypeDescr,field: "groupByFieldName" },
					{ headerName: tra.L7127_noOfRecords, field: "groupByCount" }
				];
				this.colDefActionCategory = [
					{ headerName: tra.L7126_actionCategoryDescr,field: "groupByFieldName" },
					{ headerName: tra.L7127_noOfRecords, field: "groupByCount" }
				];
			}
		)
	}
	
	group1 : any;
	group2 : any;
	
	public afterGridDataLoadExecutePageSpecificTasks(response): void {
		if(response.groupData1) {
			this.group1 = response.groupData1;
		}
		if(response.groupData2) {						
			this.group2 = response.groupData2;
		}
	}

	//========================================================================
	//				RIGHT GROUP TABLE LOGIC SECTION END
	//========================================================================






	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION BEGIN
	//========================================================================


	// Implement abstract method..
	// Set page filters from external filter object.
	setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) {
		
		// Mapping first filter from filterTemplate to pageFilter
		var f1 = filter.tntfilFiltropagSelect1FiltropagcampoCodice;
		if(f1 == "user_id") {
			this.resolveUserFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if(f1 == "action_insert_date") {
			this.resolveDateFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if(f1 == "action_type_descr") {
			this.resolveActionTypeFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		

		// Mapping second filter from filterTemplate to pageFilter
		var f2 = filter.tntfilFiltropagSelect2FiltropagcampoCodice;
		if(f2 == "user_id") {
			this.resolveUserFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if(f2 == "action_insert_date") {
			this.resolveDateFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if(f2 == "action_type_descr") {
			this.resolveActionTypeFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}		

		// Mapping third filter from filterTemplate to pageFilter
		var f3 = filter.tntfilFiltropagSelect3FiltropagcampoCodice;
		if(f3 == "user_id") {
			this.resolveUserFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if(f3 == "action_insert_date") {
			this.resolveDateFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if(f3 == "action_type_descr") {
			this.resolveActionTypeFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		
	}

	// Need to implement this function based on 
	// action_type_id filter type and condition.
	// 
	private resolveActionTypeFilter(condition : string, value : string) {
		if(condition == "equal") {
			this.allFilters[2].option1 = value;
		}
	}

	private resolveDescriptionDetailFilter(condition : string, value : string) {

		if((condition == "contains" || condition == "begins") && value) {
			this.allFilters[3].option1 = value;
		}
		else {
			this.allFilters[3].option1 = "";
		}

	}

	private resolveUserFilter(condition : string, value : string) {

		if(condition == "me") {
			this.allFilters[0].option1 = this.loggedInUser.uteId;
		}
		else if(condition == "equal") {
			this.allFilters[0].option1 = value;
		}
		else {
			this.allFilters[0].option1 = "";
		}

	}

	// Set page filters date.
	// If external filter type is date and the condition is range, set both from date and to date.
	// If otherwise, set only from date.
	private resolveDateFilter(condition : string, value : string) {

		if((condition == "before" ||condition == "sameorbefore")
			&& value
			&& value.length == 10
		) {
			this.toDate = value.toCustomDate();
		}
		else if((condition == "after" || condition == "sameorafter")
			&& value
			&& value.length == 10
		) {
			this.fromDate = value.toCustomDate();
		}
		else if(condition == "range" && value && value.length == 23) {
			this.setDateRange(value);
		}
		else {
			this.fromDate = null;
			this.toDate = null;
		}
		
	}

	// Set both from date and to date.
	private setDateRange(dateStringRange : string) {
		var dates = this.stringToDateRange(dateStringRange);
		if(dates.length == 2) {
			this.fromDate = dates[0];
			this.toDate = dates[1];
		}

	}

	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION END
	//========================================================================






	onStaticOptionChange() {
		switch (this.staticOptionChoser) {
			case 'me':
				this.getOwnLog();
				break;
			case 'system':
				this.getSystemLog();
				break;
			case 'yesterday':
				this.getYesterdayLog();
				break;
			case 'today':
				this.getTodayLog();
				break;
			case 'lastWeek':
				this.getLastWeekLog();
				break;
			default:
				break;
		}
	}

	getOwnLog() {
		this.allFilters[0].option1 = this.loggedInUser.uteId;
		this.onApplyFilter();
	}
	getSystemLog() {
		this.allFilters[0].option1 = "system";
		this.onApplyFilter();
	}
	getYesterdayLog() {
		this.setYesterdayDate();
		this.onApplyFilter();
	}
	getTodayLog() {
		this.setTodayDate();
		this.onApplyFilter();
	}
	getLastWeekLog() {
		this.setLastWeekyDate();
		this.onApplyFilter();
	}

	private setTodayDate() {
		this.toDate = new Date();
		this.fromDate = new Date();
	}

	private setYesterdayDate() {
		var refDate = new Date();
		var dt = refDate.addDays(-1);
		this.toDate = dt;
		this.fromDate = dt;
	}

	private setLastWeekyDate() {
		var refDate = new Date();
		var dt = refDate.addDays(-7);
		this.toDate = refDate;
		this.fromDate = dt;
	}

	private clearFilterDates() {
		this.fromDate = null;
		this.toDate = null;
	}

	private setFilterDates() {
		this.allFilters[1].option1 = this.fromDate == null ? '' : this.fromDate.getDatePortion();
		this.allFilters[1].option2 = this.toDate == null ? '' : this.toDate.getDatePortion();
	}



	onExcelClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

	onPdfClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

	onPrintClick() {
		this.toastrService.warning(
			this.translate.instant('common.usrmsg_warn.L3003_notImplemented')
		);
	}

}
