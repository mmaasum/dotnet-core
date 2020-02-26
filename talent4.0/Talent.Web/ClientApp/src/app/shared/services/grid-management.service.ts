import { Injectable, Injector } from '@angular/core';
import { Font, FontSize } from 'shared/models/font';
import { GridSettingsWrapper } from 'shared/models/grid-settings-wrapper';

import { CommonService } from './common-new.service';

@Injectable()
export class GridManagementService extends CommonService {

	constructor(public injector: Injector) {
		super(injector);
	}

	/**
	 * Gets all the fonts available for grid.
	 */
	getFonts() {
		return this.http.get<Font[]>('/api/GlobalGrid/GetAllFontList');
	}

	/**
	 * Gets all the font size available for grid.
	 */
	getFontSize() {
		return this.http.get<FontSize[]>('/api/GlobalGrid/GetAllFontSizeList');
	}

	/**
	 * Gets grid settings for a grid for a logged in user.
	 * If no grid settings is found for the user, a system specific settings will be provided.
	 * @param gridName 
	 */
	getGridSetting(gridName: string) {
		var changedGridName = this.fixGridNameForGridSettings(gridName);
		return this.http.get<GridSettingsWrapper>(
			`/api/GlobalGrid/GetTalentGridUserDetailsWithFields/${this.user.uteId}/${this.user.uteCliId}/${changedGridName}/${this.user.language}`
		);
	}

	/**
	 * Gets grid settings for a grid for a logged in user.
	 * If no grid settings is found for the user, a system specific settings will be provided.
	 * @param gridName 
	 */
	deleteGridSetting(gridName: string) {
		var changedGridName = this.fixGridNameForGridSettings(gridName);
		return this.http.delete<GridSettingsWrapper>(
			`/api/GlobalGrid/DeleteAllCustomGridSettingByUser/${this.user.uteId}/${this.user.uteCliId}/${changedGridName}`
		);
	}

	/**
	 * Gets all the columns of a grid.
	 * @param gridName 
	 */
	getAllGridColumnNames(gridName: string) {
		var changedGridName = this.fixGridNameForGridSettings(gridName);
		return this.http.get<any>(
			`/api/GlobalGrid/GetGridFieldsDescrByPage/${changedGridName}/${this.user.language}`
		);
	}

	/**
	 * Post the grid settings object for saving.
	 * @param settingObj 
	 */
	save(settingObj: GridSettingsWrapper) {
		return this.http.post<any>(
			`/api/GlobalGrid/ManageTalentGridUserWithFields`, settingObj
		);
	}

	// Due to changing grid name column in grid settings table
	// We have to statically change grid name before calling grid settings API
	public fixGridNameForGridSettings(gridName : string) : string {

		var changedGridName = gridName;
		switch(gridName) {
			case "log_operazioni" :
				changedGridName = "grid_visualizza_lista_operazioni";
				break;
			case "azioni" : 
				changedGridName = "grid_" + gridName;
				break;
			case "termini" : 
				changedGridName = "grid_gestione_termini";
				break;
			case "ruoli_utenti" :
				changedGridName = "grid_gestione_ruoli";
				break;
			default :
				break;
		}
		return changedGridName;

	}
}
