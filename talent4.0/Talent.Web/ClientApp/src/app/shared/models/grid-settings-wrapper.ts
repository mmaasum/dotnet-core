import { GridSettingsMaster } from 'shared/models/grid-settings-master';
import { GridSettingsDetail } from 'shared/models/grid-settings-detail';


export class GridSettingsWrapper {
	talentGridUser: GridSettingsMaster;
	talentGridFieldsUserList: GridSettingsDetail[];

	constructor() {
		this.talentGridUser = new GridSettingsMaster();
		this.talentGridFieldsUserList = [];
	}
}