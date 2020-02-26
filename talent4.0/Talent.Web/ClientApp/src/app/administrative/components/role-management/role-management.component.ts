import { RuoloService } from './../../services/ruolo.service';
import { UtentiService } from './../../services/user-create.service';
import { Roles } from 'shared/models/roles';
import { RoleManagementService } from './../../services/role-management.service';
import { Component, OnInit } from '@angular/core';
import { CommonGridBehaviourNew } from 'shared/models/common-grid-behaviour-new';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'shared/auth/auth.service';
import { FilterService } from 'shared/services/filters.service';
import { TranslateService } from 'shared/services/translate.service';
import { GridManagementService } from 'shared/services/grid-management.service';
import { MasterFilterTemplate } from 'shared/models/master-filter-temp';
import { Utenti } from 'shared/models/utenti';


@Component({
	selector: 'role-management',
	styleUrls: ['./role-management.component.css'],
	templateUrl: './role-management.component.html',
	providers: [GridManagementService, FilterService, RuoloService, UtentiService]
})
export class RoleManagementComponent extends CommonGridBehaviourNew implements OnInit {
	
	
	private freeSearchFieldExtraColumns = "ruolodescr_descrizione;ruolodescr_descrizione_breve;ruolodescr_descrizione_estesa";

	columnName: string = 'ruoli_utenti';
	staticOptionChoser : string;
	isNewRowAdding: boolean = true;
	selectedRole: Roles = new Roles();
	utenti: Utenti = new Utenti();

	constructor(
		public toastrService: ToastrService,
		public authService: AuthService,
		public filterService: FilterService,
		public translate: TranslateService,
		public gridManagementService: GridManagementService,
		private ruoloService: RuoloService,
		private utentiService: UtentiService
	) {
		super(filterService, authService, toastrService, translate, gridManagementService, 'ruoli_utenti');
		this.translate.use(this.loggedInUser.language);
		this.translate.load(['common', 'filter', 'ruoli']);
		this.setPageFilterVariableDatas();
	}

	ngOnInit() {
		this.loadGridSettingsInformation();
		this.loadInternalFilterDropdownLists();
		this.utentiService.getUser(this.loggedInUser.uteId)
			.subscribe(
				response => {
					console.log(response);
					this.utenti = response;
				},
				error => {
					console.log(error);
				}
			)
	}


	private loadInternalFilterDropdownLists() {
		
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
					case "ruoli_utenti.ruolo":
						colDef.field = 'ruolo';
						break;
					case "ruolo_abilitato":
						colDef.valueGetter = (param => {
							return (param.data.ruoloAbilitato == "S" ? "Enabled" : "Disabled");
						});
						break;
					case "ruolo_system":
						colDef.valueGetter = (param => {
							return (param.data.ruoloSystem == "S" ? "Yes" : "No");
						});
						break;					
					case "ruolodescr_descrizione":
						colDef.field = 'ruolodescrDescrizione';
						break;	
					case "ruolodescr_descrizione_breve":
						colDef.field = 'ruolodescrDescrizioneBreve';
						break;
					case "ruolodescr_descrizione_estesa":
						colDef.field = 'ruolodescrDescrizioneEstesa';
						break;
					case "ruolodescr_lingua":
						colDef.field = 'ruolodescrLingua';
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

		var colDef1: any = {
			headerName : this.translate.instant('ruoli.usrmsg_info.L07360_noOfPermissions'),
			field: "noOfPermission"
		};
		var colDef2: any = {
			headerName : this.translate.instant('ruoli.usrmsg_info.L07361_noOfActiveUsers'),
			field: "noOfActiveUser"
		};
		this.columnDefs.push(colDef1);
		this.columnDefs.push(colDef2);

		this.gridOptions.api.setColumnDefs(this.columnDefs);

	}

	//#region External Filter

	// all the Declaration(variable/method) will appeare here.

	//#endregion

	//#region Internal Filter

	setPageFilterVariableDatas() {
		// Filters and sorting data variables
		this.allFilters = [
			{
				columnName: "ruolo_abilitato",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "ruolo_ins_ute_id",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "ruolo",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: this.freeSearchFieldExtraColumns
			},
			{
				columnName: "ruolo_system",
				dataType: "text",
				filterType: "like",
				option1: "",
				option2: ""
			},
			{
				columnName: "ruolodescr_lingua",
				dataType: "text",
				filterType: "equal",
				option1: this.loggedInUser.language,
				option2: ""
			}
		];

		this.sorting = {
			columnName: 'ruolo_mod_timestamp DESC',
			type: ''
		};

		this.joinTables = [
			{
				joinTableName: "ruoli_utenti_descr",
				joinFields: [
					{ baseTableJoinFieldName: "ruolo", joinTableJoinFieldName: "ruolodescr_ruolo" },
					{ baseTableJoinFieldName: "ruolo_cli_id", joinTableJoinFieldName: "ruolodescr_cli_id" }
				]
			}
		];
		this.filterSortingModel = {
			filters: [],
			clientColumn: 'ruolo_cli_id',
			joinTableQueryDto: {
				joinTable: this.joinTables,
				joinTableRetreivedFields: [
					"( Select Count (*) As NoOfPermission from talent_ruoli_tipi_abilitazione Where ruoltipab_ruolo = ruoli_utenti.ruolo AND ruoltipab_uteab_abilitato = 'S' and ruoltipab_cli_id = ruoli_utenti.ruolo_cli_id) as NoOfPermission",
					"(SELECT COUNT(DISTINCT(uteab_ute_id)) FROM utenti_abilitazioni LEFT JOIN utenti ON utenti_abilitazioni.uteab_ute_id = utenti.ute_id WHERE utenti.ute_attivo = 'S' and uteab_abilitato = 'S' and uteab_procedura IN (SELECT [ruoltipab_uteab_procedura] FROM [talent_ruoli_tipi_abilitazione] WHERE [ruoltipab_ruolo] = ruoli_utenti.ruolo and [ruoltipab_uteab_abilitato] = 'n' and [ruoltipab_cli_id] = ruoli_utenti.ruolo_cli_id)) As NoOfActiveUser",
					"ruolodescr_cli_id", "ruolodescr_ins_timestamp", "ruolodescr_mod_timestamp", 
					"ruolodescr_ins_ute_id", "ruolodescr_mod_ute_id", "ruolodescr_ruolo", 
					"ruolodescr_descrizione", "ruolodescr_descrizione_breve",
					"ruolodescr_descrizione_estesa", "ruolodescr_lingua"
				]
			}
		};
	}
	
	//"ruolodescr_cli_id", "ruolodescr_ins_timestamp", "ruolodescr_mod_timestamp", "ruolodescr_ins_ute_id", "ruolodescr_mod_ute_id", "ruolodescr_ruolo", 
	
	public resetPageSpecificFilterDefaultValues(): void {
		this.allFilters[0].filterType = "like";
		this.allFilters[1].filterType = "like";
		this.allFilters[2].filterType = "like";
		this.allFilters[2].option2 = this.freeSearchFieldExtraColumns;
		this.allFilters[4].option1 = this.loggedInUser.language;

		// this.allFilters[4].option1 = this.loggedInUser.language;
		// this.allFilters[5].option1 = this.loggedInUser.language;
	}

	public pageSpecificFilterClearTask(): void {
		this.staticOptionChoser = '';
		this.allFilters[2].filterType = "like";
	}
	public pageSpecificPreApplyFilterTasks(): void {

	}

	//#endregion


	//#region Common Grid

	onGridReady(params) {
		this.setfilterSortingModelData();
		this.onGridReadyCommonTasks(this.filterSortingModel, params, false, false);
	}

	onRowDoubleClicked(event) {
		console.log(event);
		this.selectedRole = event.data;
		this.isNewRowAdding = false;
	}

	public afterGridDataLoadExecutePageSpecificTasks(response): void {

	}

	//#endregion
	



	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION BEGIN
	//========================================================================


	// Implement abstract method..
	// Set page filters from external filter object.
	setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) {

		// Mapping first filter from filterTemplate to pageFilter
		var f1 = filter.tntfilFiltropagSelect1FiltropagcampoCodice;
		if (f1 == "ruolo_abilitato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if (f1 == "ruoli_utenti.ruolo" || f1 == "ruolodescr_descrizione" ) {
			this.resolveListToFreeSearchFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}
		else if (f1 == "ruolodescr_descrizione_breve" || f1 == "ruolodescr_descrizione_estesa" ) {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect1Filtrocond, filter.tntfilFiltropagSelect1Valore);
		}



		// Mapping second filter from filterTemplate to pageFilter
		var f2 = filter.tntfilFiltropagSelect2FiltropagcampoCodice;
		if (f2 == "ruolo_abilitato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if (f2 == "ruoli_utenti.ruolo" || f2 == "ruolodescr_descrizione") {
			this.resolveListToFreeSearchFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}
		else if (f2 == "ruolodescr_descrizione_breve" || f2 == "ruolodescr_descrizione_estesa" ) {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect2Filtrocond, filter.tntfilFiltropagSelect2Valore);
		}

		// Mapping third filter from filterTemplate to pageFilter
		var f3 = filter.tntfilFiltropagSelect3FiltropagcampoCodice;
		if (f3 == "ruolo_abilitato") {
			this.resolveStateFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if (f3 == "ruoli_utenti.ruolo" || f3 == "ruolodescr_descrizione" ) {
			this.resolveListToFreeSearchFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}
		else if (f3 == "ruolodescr_descrizione_breve" || f3 == "ruolodescr_descrizione_estesa" ) {
			this.resolveFreeSearchFilter(filter.tntfilFiltropagSelect3Filtrocond, filter.tntfilFiltropagSelect3Valore);
		}

	}

	
	private resolveStateFilter(condition: string, value: string) {
		if (condition == "equal") {
			this.allFilters[0].option1 = value;
		}
	}

	private resolveListToFreeSearchFilter(condition: string, value: string) {
		if (condition == "equal") {
			this.allFilters[2].option1 = value;
		}
		else {
			this.allFilters[2].option1 = "";
		}
	}

	private resolveFreeSearchFilter(condition: string, value: string) {

		if ((condition == "contains" || condition == "begins") && value) {
			this.allFilters[2].option1 = value;
		}
		else {
			this.allFilters[2].option1 = "";
		}

	}



	//========================================================================
	//			SET PAGE FILTERS BASED ON EXTERNAL FILTER SECTION END
	//========================================================================




	//==================================================================
	//					QUICK FILTER LOGIC BEGIN
	//==================================================================

	onStaticOptionChange() {
		this.allFilters[0].option1 = "";
		this.allFilters[1].option1 = "";
		this.allFilters[2].option1 = "";
		this.allFilters[3].option1 = "";
		this.allFilters[2].filterType = "like";

		switch (this.staticOptionChoser) {
			case 'me':
				this.getMyRole();
				break;
			case 'enabledRoles':
				this.getEnabledPermissions();
				break;
			case 'system':
				this.getSystemRoles();
				break;
			default:
				break;
		}
	}

	private getMyRole() {
		this.allFilters[2].option1 = this.utenti.uteRuolo;
		this.allFilters[2].filterType = "equal";
		this.onApplyFilter();
	}
	private getEnabledPermissions() {
		this.allFilters[0].option1 = "S";
		this.onApplyFilter();
	}

	private getSystemRoles() {
		this.allFilters[3].option1 = "S";
		this.onApplyFilter();
	}

	//==================================================================
	//					QUICK FILTER LOGIC END
	//==================================================================

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

	onFilterStateChange() {
		if (this.allFilters[0].option1) {
			this.allFilters[0].filterType = "equal";
		}
		else {
			this.allFilters[0].filterType = "like";
		}

		this.onApplyFilter();
	}

	onPermissionChange() {
		if (this.allFilters[1].option1) {
			this.allFilters[1].filterType = "equal";
		}
		else {
			this.allFilters[1].filterType = "like";
		}

		this.onApplyFilter();
	}



	//======================================================================
	//					TERMINI ADD/EDIT LOGIC BEGIN
	//======================================================================

	onAddNewRole() {
		this.isNewRowAdding = true;
	}

	onRoleAddEditComplete($event) {
		this.onApplyFilter();
	}

	//======================================================================
	//					TERMINI ADD/EDIT LOGIC END
	//======================================================================
	
}
