import { Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective, SortableComponent } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { forkJoin } from 'rxjs';
import { Font, FontSize } from 'shared/models/font';
import { GridSettingsDetail } from 'shared/models/grid-settings-detail';
import { GridSettingsMaster } from 'shared/models/grid-settings-master';
import { GridSettingsWrapper } from 'shared/models/grid-settings-wrapper';
import { GridManagementService } from 'shared/services/grid-management.service';
import { TranslateService } from 'shared/services/translate.service';

@Component({
	selector: 'app-grid-management',
	templateUrl: './grid-management.component.html',
	styleUrls: ['./grid-management.component.css']
})
export class GridManagementComponent implements OnInit, OnChanges {

	@Input() show: boolean;
	@Input() grid: string; settings
	@Input('settings') gridSettings: GridSettingsWrapper;

	@Output() onSettingsEmit = new EventEmitter<GridSettingsWrapper>();
	@Output() onClose = new EventEmitter<boolean>();

	@ViewChild('gridSettingsModal', { static: false }) gridSettingsModal: ModalDirective;
	@ViewChild("leftList", { static: false }) leftList: SortableComponent;
	@ViewChild("rightList", { static: false }) rightList: SortableComponent;

	fonts: Font[] = [];
	fontSizes: FontSize[] = [];
	showRowNumber: boolean = false;
	showColRowNumber: boolean = false;


	initialGridSettings: GridSettingsWrapper = new GridSettingsWrapper();
	master: GridSettingsMaster = new GridSettingsMaster();
	detail: GridSettingsDetail = new GridSettingsDetail();

	allColumns: GridSettingsDetail[] = [];
	assignedColumns: GridSettingsDetail[] = [];
	unassignedColumns: GridSettingsDetail[] = [];

	constructor(
		private gridService: GridManagementService,
		private toastrService: ToastrService,
		private translate: TranslateService
	) { }

	
	/**
	 * When grid setting change occurred the
	 * method call
	 */
	ngOnChanges() {

		if (this.gridSettingsModal != undefined) {

			if (this.show) {
				this.loadGridSettingsInformation();
				this.clearSelection();
				this.selectedItem = new GridSettingsDetail()
				this.gridSettingsModal.show();
			}
			else {
				this.gridSettingsModal.hide();
			}
		}
	}

	/**
	 * Azioni form initialization. 
	 * When first time load.
	 */
	ngOnInit() {
		let user = this.gridService.user;
		this.translate.use(user.language);
		this.translate.load(['common', 'grid']);

		this.loadInitialData();
	}

	/**
	 * Initial data gathering for ngOnInit() method.
	 */
	private loadInitialData() {
		forkJoin(
			this.gridService.getFonts(),
			this.gridService.getFontSize(),
			this.gridService.getAllGridColumnNames(this.grid)
		).subscribe(
			response => {
				this.fonts = response[0];
				this.fontSizes = response[1];
				this.allColumns = response[2];
				console.log("All columns => ");
				console.log(this.allColumns);				
			},
			error => {
				console.log(error);
			}
		)
	}


	/**
	 * prepare setting of the grid with default filters
	 */
	private loadGridSettingsInformation() {
		this.master = this.gridSettings.talentGridUser;
		this.assignedColumns = this.gridSettings.talentGridFieldsUserList
			.sort((a, b) => a.tntgcuOrderPosition - b.tntgcuOrderPosition);

		this.initialGridSettings = JSON.parse(JSON.stringify(this.gridSettings));
		this.setDefaults();
		this.populateUnassignedColumnsList();
	}
	/**
	 * initialized UteId and CliId
	 */
	private setDefaults() {
		this.master.tntgruUteId = this.gridService.user.uteId;
		this.master.tntgruCliId = this.gridService.user.uteCliId;
		this.showRowNumber = this.master.tntgruShowRowNumber == "S" ? true : false;
	}


	/**
	 * Populate unassigned column array by removing assigned columns from all columns array.
	 *  First set unassigned column array = all column array.
	 * Then remove the assigned column from unassigned columns array.
	 */
	private populateUnassignedColumnsList() {
		this.unassignedColumns = JSON.parse(JSON.stringify(this.allColumns));
		this.assignedColumns.forEach(element => {
			var matchedIndex = this.unassignedColumns.findIndex(a => a.tntgcuFieldName == element.tntgcuFieldName);
			if (matchedIndex >= 0) {
				this.unassignedColumns.splice(matchedIndex, 1);
			}
		});
	}


	/**
	 * Pull user's grid settings from server.
	 */
	private pullGridSettingsFromServer() {
		this.gridService.getGridSetting(this.grid)
			.subscribe(
				response => {
					this.gridSettings = JSON.parse(JSON.stringify(response));
					this.loadGridSettingsInformation();
					this.onCloseGridSettingsModal();
				},
				error => {
					console.log(error);
					this.toastrService.error(this.translate.instant('grid.usrmsg_err.L1552_errResetting'));
					this.gridSettings = JSON.parse(JSON.stringify(this.initialGridSettings));
					this.onCloseGridSettingsModal();
				}
			);
	}


	/**
	 * Just to show the settings and 
	 * don't make any change on database.
	 */
	onDiscardGridChanges() {
		this.pullGridSettingsFromServer();
	}

	



	/**
	 * Set grid settings object property.
	 */
	private setGridSettingObjProperty() {

		this.master.tntgruShowRowNumber = this.showRowNumber ? "S" : "N";
		this.gridSettings.talentGridUser = this.master;

		var allColumns: GridSettingsDetail[] = [];

		// Push all assigned colmns to allColumns variable after setting isActive = true.
		this.assignedColumns.forEach(element => {
			element.tntgcuUteId = this.gridService.user.uteId;
			element.tntgcuCliId = this.gridService.user.uteCliId;
			element.isActive = true;
			allColumns.push(element);
		});


		// Push all assigned colmns to allColumns variable after setting isActive = false.
		this.unassignedColumns.forEach(element => {
			element.tntgcuUteId = this.gridService.user.uteId;
			element.tntgcuCliId = this.gridService.user.uteCliId;
			element.isActive = false;
			allColumns.push(element);
		});

		this.gridSettings.talentGridFieldsUserList = allColumns;

	}

	/**
	 * Delete all user settings and 
	 * apply system settings
	 */
	onResetSystemValues() {
		this.gridService.deleteGridSetting(this.grid)
			.subscribe(
				response => {
					this.pullGridSettingsFromServer();
				},
				error => {
					console.log(error);
				}
			);
	}

	/**
	 * Apply the desired setting on popup.
	 */
	onApplySettings() {
		this.setGridSettingObjProperty();
		if(this.isGridSettingsObjectValid()) {
			this.resetToActualColumn();
			this.onSettingsEmit.emit(this.gridSettings);
		}
		
	}

	onGridSettingsSave() {

		this.setGridSettingObjProperty();

		console.log("Grid settings before save =>");
		console.log(this.gridSettings);

		if(this.isGridSettingsObjectValid()) {
			this.gridService.save(this.gridSettings)
				.subscribe(
					response => {
						this.resetToActualColumn();
						this.onCloseGridSettingsModal();
					},
					error => {
						console.log(error);
						this.toastrService.error(
							this.translate.instant('grid.usrmsg_err.L1551_errSaving')
						);
						this.gridSettings = JSON.parse(JSON.stringify(this.initialGridSettings));
						this.onCloseGridSettingsModal();
					}
				);
		}

		
	}

	/**
	 * Reset gridSettings object assigned columns list to actuaaly assigned columns
	 * And close grid settings modal.
	 */
	private resetToActualColumn() {
		//this.gridSettings.talentGridFieldsUserList = this.actualAssignedColumns;		
		this.gridSettings.talentGridFieldsUserList = this.assignedColumns;
	}


	private isGridSettingsObjectValid(): boolean {
		var isValid = true;
		this.gridSettings.talentGridFieldsUserList.forEach(col => {
			if(col.isActive && col.tntgcuMinSize > col.tntgcuMaxSize) {
				this.toastrService.warning(
					this.translate.instant('grid.usrmsg_warn.L4553_minGreaterMax', {col : col.tntgcuFieldLabelDescription})
				);
				isValid = false;
			}
		});
		return isValid;
	}
	/**
	 * 
	 */
	onCloseGridSettingsModal() {
		this.gridSettingsModal.hide();
		this.onSettingsEmit.emit(this.gridSettings);
		this.onClose.emit(true);
	}

	/**
	 * On master font change override font  
	 * of all assigned and unassigned columns font.
	 */
	onMasterFontChange() {
		var font = this.master.tntgruFontName;
		this.unassignedColumns.forEach(element => {
			element.tntgcuFieldFontName = font;
		});
		this.assignedColumns.forEach(element => {
			element.tntgcuFieldFontName = font;
		});
	}

	/**
	 * On master font size change override font size 
	 * of all assigned and unassigned columns font size.
	 */
	onMasterFontSizeChange() {
		var fontSize = this.master.tntgruFontSize;
		this.unassignedColumns.forEach(element => {
			element.tntgcuFieldFontSize = fontSize;
		});
		this.assignedColumns.forEach(element => {
			element.tntgcuFieldFontSize = fontSize;
		});
	}


	//================================================================//
	//                SORTABLE LIST FUNCTIONALITIES BEGIN             //
	//================================================================//

	/**
	 *  Variables required to implement functionalities.
	 */
	leftSelected: boolean = false;
	rightSelected: boolean = false;
	selectedItem: GridSettingsDetail = new GridSettingsDetail();

	/**
	 * Clicked on selected item of 
	 * popup
	 * @param item 
	 */
	itemClick(item) {
		this.selectedItem = item.initData;
		this.leftSelected = this.unassignedColumns.some(a => a.tntgcuFieldName == this.selectedItem.tntgcuFieldName);
		this.rightSelected = this.assignedColumns.some(a => a.tntgcuFieldName == this.selectedItem.tntgcuFieldName);
		this.loadDetailPaneData();
	}

		/**
	 * Move the selected database field
	 * to right
	 */
	moveLeftToRight() {
		if (this.leftSelected) {
			var index = this.unassignedColumns.indexOf(this.selectedItem);
			this.unassignedColumns.splice(index, 1);
			this.assignedColumns.push(this.selectedItem);
			this.reInitializeSortableSource();
			this.clearSelection();
		}
	}

		/**
	 * Move the selected database field
	 * to left
	 */
	moveRightToLeft() {
		if (this.rightSelected) {
			var index = this.assignedColumns.indexOf(this.selectedItem);
			this.assignedColumns.splice(index, 1);
			this.unassignedColumns.push(this.selectedItem);
			this.reInitializeSortableSource();
			this.clearSelection();
		}
	}

		/**
	 * Move the selected database field
	 * to up
	 */
	moveUp() {
		if (this.rightSelected) {
			var index = this.assignedColumns.indexOf(this.selectedItem);
			if (index == 0) {
				this.toastrService.warning(this.translate.instant('grid.usrmsg_warn.L4551_reachedTop'));
			}
			else {
				this.assignedColumns.splice(index, 1);
				this.assignedColumns.splice(index - 1, 0, this.selectedItem);
				this.reInitializeSortableSource();
			}

		}
	}

	/**
	 * Move the selected database field
	 * to down
	 */
	moveDown() {
		if (this.rightSelected) {
			var index = this.assignedColumns.indexOf(this.selectedItem);
			if (index == this.assignedColumns.length - 1) {
				this.toastrService.warning(this.translate.instant('grid.usrmsg_warn.L4552_reachedBottom'));
			}
			else {
				this.assignedColumns.splice(index, 1);
				this.assignedColumns.splice(index + 1, 0, this.selectedItem);
				this.reInitializeSortableSource();
			}
		}
	}

	/**
	 * For column order initialization
	 */
	private reInitializeSortableSource() {
		this.leftList.writeValue(this.unassignedColumns);
		this.rightList.writeValue(this.assignedColumns);
		this.resetAssignedColumnsOrder();
	}

	/**
	 * Clear the popup.
	 */
	private clearSelection() {
		this.leftSelected = false;
		this.rightSelected = false;
		this.loadDetailPaneData();
	}

	tempDetail: any;
	/**
	 * Popup visiable
	 */
	private loadDetailPaneData() {
		if (this.rightSelected) {
			this.detail = this.selectedItem;
			this.tempDetail = this.detail;
		}
		else {
			this.detail = new GridSettingsDetail();
		}
		this.setColumnAutoSizeProperty();
	}

	isColumnAutoSize: boolean = false;

	private setColumnAutoSizeProperty() {
		this.isColumnAutoSize = this.detail.tntgcuAutoSize == "S" ? true : false;
	}

	onColumnAutoWidthChange() {		
		this.isColumnAutoSize = !this.isColumnAutoSize;
		this.detail.tntgcuAutoSize = this.isColumnAutoSize ? "S" : "N";
	}

	/**
	 * Used for fileld changed
	 */
	onDiscardFieldChanges() {
		console.log(this.tempDetail);
		this.detail.tntgcuFieldTextAlign = this.tempDetail.tntgcuFieldTextAlign;
	}

	/**
	 * Column order defing.
	 */
	resetAssignedColumnsOrder() {
		this.assignedColumns.forEach((element, index) => {
			element.tntgcuOrderPosition = index + 1;
		});
	}

	/**
	 * For column order changing.
	 * @param $event 
	 */
	changed($event) {
		this.resetAssignedColumnsOrder();
	}

	//================================================================//
	//                SORTABLE LIST FUNCTIONALITIES END               //
	//================================================================//

}
