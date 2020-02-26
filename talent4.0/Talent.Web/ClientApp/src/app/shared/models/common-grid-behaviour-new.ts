import { TranslateService } from './../services/translate.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from 'shared/auth/auth.service';
import { CustomLoadingOverlay } from 'shared/components/custom-loading-overlay/custom-loading-overlay.component';
import { FilterService } from 'shared/services/filters.service';

import { Azioni } from './azioni';
import { FilterSortingModel, Filter, Sorting, JoinTable } from './filter-sorting-model';
import { ILoggedInUser } from './loggedin-user';
import { MasterFilterTemplate, DifferentFilterTypeWrapper } from './master-filter-temp';
import { ValueGetterParams, Grid } from 'ag-grid-community';
import { GridSettingsWrapper } from './grid-settings-wrapper';
import { GridManagementService } from 'shared/services/grid-management.service';
import { GridSettingsMaster } from './grid-settings-master';

export abstract class CommonGridBehaviourNew {

    bsDateConfig = {
        dateInputFormat: 'DD/MM/YYYY',
        useUtc : true,
        showWeekNumbers  : false,
        isAnimated : true,
        containerClass : 'theme-default',
        customTodayClass: 'custom-today-class'
    };
    
    pageSizeOptions = [20, 50, 100, 200, 300, 500, 1000];

    tableName : string;
    loggedInUser : ILoggedInUser;
    // appliedFilterInGrid : string = "";
    // appliedSortingInGrid : string = "";

    // Grid total recrds count related objects.
    pageIndex : number = 1;
    pageSize : number = 100;
    totalGridRecords : number = 0;
    totalDbRecords : number = 0;
    appliedFilterIdInGrid : number = 0;

    allRadioValues : string[] = [];

    // Grid related objects.
    gridApi;
    gridColumnApi;
    gridOptions:any = {};
    paginationPageSize = 5000;
    autoGroupColumnDef;    
    rowSelection;
    rowGroupPanelShow;
    pivotPanelShow;
    rowData: any;
    frameworkComponents;
    loadingOverlayComponent;
	loadingOverlayComponentParams;
	columnDefs = [];
    defaultColDef = {
        sortable: true, 
        filter: true, 
        resizable: true
    };

	logAzioni : Azioni = new Azioni("", "", "", "");
	
	// PAGE FILTER RELATED VARIABLES..
	allFilters : Filter[] = [];
	sorting : Sorting = new Sorting();
	joinTables: JoinTable[];
	filterSortingModel : FilterSortingModel = new FilterSortingModel();
	isFilterCleared : boolean = true;
	isFilterSaveable : boolean = true;


	
	// GRID SETTINGS RELATED VARIABLES...
	gridSettings: GridSettingsWrapper = new GridSettingsWrapper();
	showCloseGridSettingsDialog : boolean = false;

    constructor( 
        public filterService : FilterService,
        public authService : AuthService,
        public toastrService : ToastrService,
		public translate : TranslateService,		
		public gridService : GridManagementService,
		public tblName : string
    ){
        this.loggedInUser = this.authService.currentUserObject;
        this.tableName = tblName;
        this.logAzioni = new Azioni(this.loggedInUser.uteId, "open", this.loggedInUser.uteCliId, this.tableName);        
        
        
        this.translate.use(this.loggedInUser.language);
		this.translate.load(['common']);
		
		this.frameworkComponents = {
			customLoadingOverlay: CustomLoadingOverlay
		};
		this.loadingOverlayComponent = "customLoadingOverlay";
    }
	// gridOptionsDoubleClicked() {
	// 	console.log('aaa');
	// 	// onRowDoubleClicked: this.doSomething
	// }
   	// doSomething() {
	// 	alert('I did something');
	// }
    // On page open log page open task.
    logPageOpenTask() {
        this.logAzioni.azioneTipo = "open";
        this.logTask();
    }

    // On page leave log page close task.
    logPageCloseTask() {
        this.logAzioni.azioneTipo = "close";
        this.logTask();
    }

    // Log task.
    logTask() {
        this.filterService.log(this.logAzioni)
        .subscribe(
            response => {
                // console.log(response);
            },
            error => {
                console.log(error);
            }
        );
	}


	
	public abstract setColumnDefinations() : void; 

	// ============================================
	// 		GRID SETTINGS SPECIFIC LOGICS BEGIN
	// ============================================

	// Load user specific grid settin gs information.
	// If no information is found set some default values.
	loadGridSettingsInformation() {
		this.gridService.getGridSetting(this.tblName)
			.subscribe(
				response => {
					this.gridSettings = response;
					console.log("Loaded grin in common grid settings => ");
					console.log(this.gridSettings);
					this.setGridCustomSettings();
					this.setColumnDefinations();
					this.addRemoveRowIndexToGrid();
				},
				error => {
					console.log(error);
					this.setDefaultGridSettingsMasterPropertyOfGridSettingsObject();
					this.setGridCustomSettings();
					this.setColumnDefinations();
					this.addRemoveRowIndexToGrid();
				}
			);
	}

	// Set defaulkt grid settings.
	private setDefaultGridSettingsMasterPropertyOfGridSettingsObject() {
		var talentGridUser : GridSettingsMaster = {
			tntgruId : 0,
			tntgruGridName : this.gridService.fixGridNameForGridSettings(this.tblName) ,
			tntgruUteId : "",
			tntgruCliId : "",
			tntgruFontName : "Arial",
			tntgruFontSize : 12,
			tntgruShowRowNumber : "N",
			tntgruEvenRowsColor : "#cccccc",
			tntgruOddRowsColor : "#ffffff",
		};
		this.gridSettings.talentGridUser = talentGridUser;
	}

	// Open grid settings modal.
	openGridSettings() {
		this.showCloseGridSettingsDialog = true;
	}

	// Close grid settings modal.
	onGridSettingsClosed(choice: boolean) {
		this.showCloseGridSettingsDialog = false;		
	}



	// Set grid settings information into grid.
	setGridCustomSettings() {

		// Set all row font size, font family.
		// Set all row background color as odd row color.
		this.gridOptions.rowStyle = {
			background: this.gridSettings.talentGridUser.tntgruOddRowsColor,
			'font-family': this.gridSettings.talentGridUser.tntgruFontName,
			'font-size': this.gridSettings.talentGridUser.tntgruFontSize.toString() + 'px!important'
		};

		// Set only the even rows background color.
		this.gridOptions.getRowStyle = (params) => {
			if (params.node.rowIndex % 2 != 0) {
				var cl = this.gridSettings.talentGridUser.tntgruEvenRowsColor;
				return { background: cl }
			}
		}

	}


	// Add or remove row index into grid columns array.
	addRemoveRowIndexToGrid() {

		if (this.gridSettings.talentGridUser.tntgruShowRowNumber == "S") {
			var indexCol = {
				headerName: "Row #",
				valueGetter: (args) => this._getIndexValue(args),
				rowDrag: false
			};
			var indexColExisting = this.columnDefs.findIndex(a => a.headerName == "Row #");
			if (indexColExisting < 0) {
				this.columnDefs.splice(0, 0, indexCol);
			}

		}
		else {
			var indexColExisting = this.columnDefs.findIndex(a => a.headerName == "Row #");
			if (indexColExisting >= 0) {
				this.columnDefs.splice(indexColExisting, 1);
			}
		}

	}

	// Output event of grid settings component settings object emit.
	// Apply grid settings into grid.
	onGridSettingsApplied(settings: GridSettingsWrapper) {
		this.gridSettings = settings;
		this.setGridCustomSettings();
		this.setColumnDefinations();
		this.addRemoveRowIndexToGrid();
	}

	// ============================================
	// 		GRID SETTINGS SPECIFIC LOGICS END
	// ============================================	





	

	//===============================================
	//			PAGE FILTER RELATED LOGICS BEGIN
	//===============================================


	public abstract setPageFilterInputsFromFilterObject(filter: MasterFilterTemplate) : void;
	public abstract resetPageSpecificFilterDefaultValues() : void;	
	public abstract pageSpecificFilterClearTask() : void;
	public abstract pageSpecificPreApplyFilterTasks() : void;

	// Set filter array of FilterSortingModel to allFilter array
	// and sorting model to sorting object.
	setfilterSortingModelData() {
		this.filterSortingModel.filters = this.allFilters;
		this.filterSortingModel.sorting = this.sorting;
	}

	// On page size dropdown value change, reload the grid.
	// Set pageindex=1 so that grid data starts from begining.
	onPageSizeChanged() {
		this.pageIndex = 1;
		if (this.appliedFilterIdInGrid > 0) {
			this.loadGridDataFromFilterID(this.filterSortingModel);
		} else {
			this.setfilterSortingModelData();
			this.loadGridDataFromFilterModel(this.filterSortingModel);
		}
	}

	// On filter management child component allFilter dropdown value change 
	// 
	filterChange(filter: MasterFilterTemplate) {

		var tempPageFilter = JSON.parse(JSON.stringify(this.filterSortingModel));

		// If clear all filter is true in global component filter template, 
		// 
		if (filter.tntfilFiltropagPulisciPrecedenti == "S") {
			this.clearAllFilters();
			this.setPageFilterInputsFromFilterObject(filter);
		}

		this.appliedFilterIdInGrid = filter.tntfilFiltropagId;
		this.loadGridDataFromFilterID(tempPageFilter);
	}

	// Clear all page filters.
	clearAllFilters() {
		this.allFilters.forEach(filter => {
			filter.option1 = '';
			filter.option2 = '';
		});

		this.resetPageSpecificFilterDefaultValues();

		this.filterSortingModel.filters = this.allFilters;
		if (this.gridColumnApi) {
			this.gridColumnApi.resetColumnState();
		}
		this.pageIndex = 1;
		this.pageSpecificFilterClearTask();
	}

	differentFilterTypeWrapper: DifferentFilterTypeWrapper = new DifferentFilterTypeWrapper();

	// Create page filter and external filter wrapper object.
	createDifferentFilterWrapperObject(testFilter: MasterFilterTemplate) {
		this.differentFilterTypeWrapper.filterSortingDto = this.filterSortingModel;
		this.differentFilterTypeWrapper.masterFilterDto = testFilter;
	}

	// Output event of Filter management test filter apply click event.
	onTestFilterApply(testFilter: MasterFilterTemplate) {
		// If clear all filter is true in global component filter template, 
		// Clear all page filters
		// And set page filters value from external filter..
		if (testFilter.tntfilFiltropagPulisciPrecedenti == "S") {
			this.clearAllFilters();
			this.setPageFilterInputsFromFilterObject(testFilter);
		}
		this.createDifferentFilterWrapperObject(testFilter);
		this.loadGridDataFromTestFilterModel(this.differentFilterTypeWrapper, false);
	}

	// Output event of filter management component filter clear button click.
	filterClear($event) {
		this.clearAllFilters();
		this.onApplyFilter();
	}

	// Apply page filters.
	onApplyFilter() {
		this.appliedFilterIdInGrid = 0;
		this.pageSpecificPreApplyFilterTasks();
		this.setfilterSortingModelData();
		this.loadGridDataFromFilterModel(this.filterSortingModel);
	}

	// on grid-pagination child component pagination change
	// reinitialize the grid according to selected page number of child component.
	onPaginationPageChanged(page) {
		this.pageIndex = page;
		if (this.appliedFilterIdInGrid > 0) {
			this.loadGridDataFromFilterID(this.filterSortingModel);
		} else {
			this.onApplyFilter();
		}
	}

	//==============================================
	//			PAGE FILTER RELATED LOGICS END
	//==============================================






	

	// Load radio buttons for page quick filters.
    loadRadioButtons(filterSortingModel : FilterSortingModel) {
        this.filterService.getCharacterGroup(this.tableName, this.pageIndex, this.pageSize, filterSortingModel)
            .subscribe(
                response => {
                    this.allRadioValues = response;
                },
                error => {
                    console.log(error);
                }
            );
    }

    // Change grid records on records count dropdown list value change.
    paginationNumberFormatter = function (params) {
        return "[" + params.value.toLocaleString() + "]";
	};
	




      
    // Executes on grid ready.
    // Initialize grid api and grid column api.
    // Increment page index to mark page number.
    // If table has many columns that can not be fitted into screen, then isFatTable = true.
    // if isFateTable==true, then set autoSizeColumns that will set column width according to content width.
    // Otherwise all the columns will be adjusted to fit in the screen.     
    onGridReadyCommonTasks(filterSortingModel : FilterSortingModel, params, isFatTable : boolean, isColumnWidthSet : boolean) {
        this.gridApi = params.api;
        this.gridColumnApi = params.columnApi;
        this.loadGridDataFromFilterModel(filterSortingModel);
       
        // this.pageIndex++;
        // if(!isColumnWidthSet) {
        //     this.setGridColumnWidth(isFatTable);   
        // }             
    }

    // if isFateTable==true, then set autoSizeColumns that will set column width according to content width.
    // Otherwise all the columns will be adjusted to fit in the screen. 
    setGridColumnWidth(isFatTable : boolean) {
        this.gridApi.sizeColumnsToFit();
        if(isFatTable) {
            this.gridApi.suppressColumnVirtualisation=true;
            var allColumnIds = [];
            this.gridColumnApi.getAllColumns().forEach(function(column) {
                allColumnIds.push(column.colId);
            });
            this.gridColumnApi.autoSizeColumns(allColumnIds);
        }
    }

    // Set column width based on content inside the column within viewport.
    colunmsWidthBasedContent() {
        var allColumnIds = [];
        this.gridColumnApi.getAllColumns().forEach(function(column) {
            allColumnIds.push(column.colId);
        });
        this.gridColumnApi.autoSizeColumns(allColumnIds);
    }

	// Get index value of a row of grid data set.
    _getIndexValue(args: ValueGetterParams): any {
        return (args.node.rowIndex + 1);
    }

    // Load grid data and set total records count using the filter model.
    loadGridDataFromFilterModel(filterSortingModel : FilterSortingModel) {
        let observable = this.filterService.getGridDataFromPageModel(this.tableName, this.pageIndex, this.pageSize, filterSortingModel);
        this.loadGridDataAndSetTotalRecords(observable);
    }

    // Load grid data and set total records count using the filter id.
    loadGridDataFromFilterID(filterSortingModel : FilterSortingModel) {
        let observable = this.filterService.getGridDataFromFilterIdWithPageModel(this.appliedFilterIdInGrid, this.pageIndex, this.pageSize, false, filterSortingModel);
        this.loadGridDataAndSetTotalRecords(observable);
    }

    // Load grid data and set total records count using the filter model.
    loadGridDataFromTestFilterModel(differentFilterTypeWrapper : DifferentFilterTypeWrapper, forRowCount : boolean) {
        let observable = this.filterService.getGridDataFromTestModel(differentFilterTypeWrapper, this.pageIndex, this.pageSize, forRowCount );
        this.loadGridDataAndSetTotalRecords(observable);
    }

	// Returns all the grid data.
    getCurrentRowData() {
        let rowData = [];
		this.gridApi.forEachNode(node => rowData.push(node.data));
		//console.log(rowData);
        return rowData;
	}
	

	// Returns all the grid data.
    getCurrentRowDataForTermini() {
        let rowData = [];
		this.gridApi.forEachNode(node => rowData.push(node.data));
		console.log(rowData);
        return rowData;
	}
	// Convert a date range string to date array.
	public stringToDateRange(dateRangeString : string): Date[] {
		var dates = dateRangeString.split(' - ');
		var dateRange : Date[] = [dates[0].toCustomDate(), dates[1].toCustomDate()];
		return dateRange;
	}


	public abstract afterGridDataLoadExecutePageSpecificTasks(response : any) : void;

	// Set total record, db record and grid data set.
    private loadGridDataAndSetTotalRecords(observable : Observable<any>) {
        this.totalGridRecords = 0;
        this.totalDbRecords = 0;
        this.rowData = observable.pipe(
            map(
                (response : any) => {
					console.log('aa');
					console.log(response);
                    this.totalGridRecords = response.data.length;
					this.totalDbRecords = response.totalRecords;
					this.afterGridDataLoadExecutePageSpecificTasks(response);
                    return response.data;
                },
                error => {
                    this.toastrService.error(this.translate.instant('common.usrmsg_err.L0204_unexpecteddErrorMsg'));
                }
            )
        );
    }

    
    // Custom date time formating.
    formatDateTimeString(val? : any) {
        var dateTimeVal = new Date(val);
        if(dateTimeVal.toDateString() === "Invalid Date"  || val === null) {
            return "";       
        }
        
        // Extracting date portion.
        var dd = dateTimeVal.getDate() < 10  ?  "0" : "";
        dd += dateTimeVal.getDate().toString();
        
        // Extracting month portion.
        var month = dateTimeVal.getMonth() + 1;        
        var MM = month < 10  ?  "0" : "";
        MM += month.toString(); 

        // Extracting year portion.
        var yyyy = dateTimeVal.getFullYear().toString();

        // Extracting hour portion.
        var hh = dateTimeVal.getHours() < 10 ? "0" : "";
        hh += dateTimeVal.getHours().toString();

        // Extracting miniute portion.
        var min = dateTimeVal.getMinutes() < 10 ? "0" : "";
        min += dateTimeVal.getMinutes().toString();

        // Extracting  seconds portion.
        var ss = dateTimeVal.getSeconds() < 10 ? "0" : "";
        ss += dateTimeVal.getSeconds().toString();

        // Extracting miliseconds portion.
        var milSs = dateTimeVal.getMilliseconds().toString();

        return dd + "/" + MM + "/" + yyyy + " " + hh + ":" + min + ":" + ss + "." + milSs; 
    }

    // Custom date time formating.
    formatDateTimeToCalendar(val? : Date) {
        var dateTimeVal = val;
        if(dateTimeVal.toDateString() === "Invalid Date"  || val === null) {
            return "";       
        }
        
        // Extracting date portion.
        var dd = dateTimeVal.getDate() < 10  ?  "0" : "";
        dd += dateTimeVal.getDate().toString();
        
        // Extracting month portion.
        var month = dateTimeVal.getMonth() + 1;        
        var MM = month < 10  ?  "0" : "";
        MM += month.toString(); 

        // Extracting year portion.
        var yyyy = dateTimeVal.getFullYear().toString();

        // Extracting hour portion.
        var hh = dateTimeVal.getHours() < 10 ? "0" : "";
        hh += dateTimeVal.getHours().toString();

        // Extracting miniute portion.
        var min = dateTimeVal.getMinutes() < 10 ? "0" : "";
        min += dateTimeVal.getMinutes().toString();

        // Extracting  seconds portion.
        var ss = dateTimeVal.getSeconds() < 10 ? "0" : "";
        ss += dateTimeVal.getSeconds().toString();

        // Extracting miliseconds portion.
        var milSs = dateTimeVal.getMilliseconds().toString();

        // return yyyy + "-" + MM + "-" + dd ; 
        return dd + "/" + MM + "/" + yyyy ; 
    }

	
}
