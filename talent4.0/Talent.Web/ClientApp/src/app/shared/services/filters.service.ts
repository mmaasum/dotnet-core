import { KeyValuePair } from 'shared/models/key-value-pair';
import { Injectable, Injector } from '@angular/core';
import { Observable, of } from 'rxjs';
import { FilterSortingModel } from 'shared/models/filter-sorting-model';
import { MasterFilterCustomTemplate } from 'shared/models/master-filter-custom-temp';
import { MasterFilterFields } from 'shared/models/master-filter-fields';
import { MasterFilterTemplate, DifferentFilterTypeWrapper } from 'shared/models/master-filter-temp';

import { FilterTemplate } from './../models/filter-template';
import { CommonService } from './common-new.service';

@Injectable()
export class FilterService extends CommonService {


	constructor(public injector: Injector) {
		super(injector);
	}

	save(filterModel: MasterFilterTemplate) {
		return this.http.post('/api/GlobalGrid/PostMasterFilter', filterModel);
	}

	update(filterModel: MasterFilterTemplate) {
		return this.http.put('/api/GlobalGrid/UpdateMasterFilter', filterModel);
	}

	delete(filterId: number) {
		return this.http.delete('/api/GlobalGrid/DeleteMasterFilter/' + filterId);
	}

	// Get detail filter string and sorting string of a filter name.
	detail(filterId: number) {
		return this.http.get<MasterFilterTemplate>('/api/globalgrid/GetMasterFilterDetailsById/' + filterId);
	}

	reorder(filters: any[]): Observable<any> {
		return this.http.put("/api/GlobalGrid/SortingSavedSearch", filters);
	}

	getAllFiltersForDdl(pageName: string) {
		var changedGridName = this.fixGridNameFirGridSettings(pageName);
		return this.http.get<MasterFilterTemplate[]>(`/api/GlobalGrid/GetMasterFilterListByUtenti/${this.user.uteId}/${changedGridName}`);
	}

	getAllButtonFilters(pageName: string) {
		var changedGridName = this.fixGridNameFirGridSettings(pageName);
		return this.http.get<MasterFilterCustomTemplate[]>(`/api/GlobalGrid/GetFilterListByUtenti/${this.user.uteId}/${changedGridName}/${this.user.language}`);
	}


	// Get all the data according to filter,pagination,page size and page number.
	getGridDataFromPageModel(tableName: string, pageIndex: number, pageSize: number, filterSortingModel: FilterSortingModel) {
		console.log(filterSortingModel);
		return this.http.post(`/api/GlobalGrid/fetch/${tableName}/${this.user.uteCliId}/${pageIndex}/${pageSize}`, filterSortingModel)
	}


	getGridDataFromFilterIdWithPageModel(filterId: number, pageNumber: number, pageSize: number, forCount: boolean, filterSortingModel: FilterSortingModel) {
		console.log(filterSortingModel);
		return this.http.post(`/api/GlobalGrid/FetchMasterFilterData/${filterId}/${pageSize}/${this.user.language}/${pageNumber}/${forCount}`, filterSortingModel);
	}

	getGridDataFromTestModel(differentFilterTypeWrapper: DifferentFilterTypeWrapper, pageNumber: number, pageSize: number, forCount: boolean) {
		console.log(differentFilterTypeWrapper);
		return this.http.post(`/api/GlobalGrid/FetchMasterFilterDataByObj/${pageSize}/${this.user.language}/${pageNumber}/${forCount}`, differentFilterTypeWrapper);
	}

	getButtonLabelsAndIfFilterIsDefault(filterId: number) {
		return this.http.get<MasterFilterCustomTemplate>(`/api/GlobalGrid/GetMasterFilterUtentiDetailsByUtenti/${filterId}/${this.user.uteId}`);
	}


    /**
     * Get group of first characters of a speceific column of a table.
     * @param tableName 
     */
	getCharacterGroup(tableName: string, pagiIndex: number, pageSize: number, filterSortingModel: FilterSortingModel) {
		return this.http.post<string[]>(`/api/GlobalGrid/GetDynamicGroupButton/${tableName}/${this.user.uteCliId}/${pagiIndex}/${pageSize}`, filterSortingModel);
	}

	// Get all filter names of a access level.
	getAllFilterName(filterTemplate: FilterTemplate): Observable<any> {
		return this.http.post('/api/globalgrid/getsearchnames', filterTemplate);
	}

	getAllPageFields(pageName: string, type: string) {
		var changedGridName = this.fixGridNameFirGridSettings(pageName);
		return this.http.get<MasterFilterFields[]>(`/api/GlobalGrid/GetFieldsByPage/${changedGridName}/${this.user.language}/${type}`);
	}

	getMultiLanguegeData(): Observable<any> {
		return this.http.get('assets/multiLanguage.json');
	}

	getNUmberOfButtonsAssignedWithFilter(filterId: Number) {
		return this.http.get<number>(`/api/GlobalGrid/CountMasterFilterUtentiByFilterId/${filterId}`);
	}

	saveFile(data: any) {
		return this.http.post(`/api/Clienti/GetLogOperazioniExcel/abc`, data, { observe: 'response', responseType: 'blob' });
	}

	saveFileForTermini(data: any) {
		return this.http.post(`/api/Clienti/GetTerminiExcel/termine`, data, { observe: 'response', responseType: 'blob' });
	}
	// Due to changing grid name column in grid settings table
	// We have to statically change grid name before calling grid settings API
	private fixGridNameFirGridSettings(gridName : string) : string {

		var changedGridName = gridName;
		switch(gridName) {
			case "log_operazioni" :
				changedGridName = "visualizza_lista_operazioni";
				break;
			case "azioni" : 
				changedGridName = "azioni";
				break;
			case "termini" : 
				changedGridName = "gestione_termini";
				break;
			default :
				break;
		}
		return changedGridName;

	}




	//===========================================================
	// 		LOAD LIST TYPE FILTER DATA
	//===========================================================

	getAzioniListTypeFilterData() {
		return this.http.get<KeyValuePair[][]>(`/api/ListTypeFilterValue/Azioni/${this.user.language}`);
	}

	getTerminiListTypeFilterData() {
		return this.http.get<KeyValuePair[][]>(`/api/ListTypeFilterValue/Termini/${this.user.language}/${this.user.uteCliId}`);
	}

	getRoleListTypeFilterData() {
		return this.http.get<KeyValuePair[][]>(`/api/ListTypeFilterValue/Role/${this.user.language}/${this.user.uteCliId}`);
	}


	private generateDummyListTypeFilterData() : KeyValuePair[][] {
		var array1 : KeyValuePair[] = [
			{ key : "1", value : "Action_descr_1"},
			{ key : "2", value : "Action_descr_2"},
			{ key : "3", value : "Action_descr_3"}
		];
		var array2 : KeyValuePair[] = [
			{ key : "7", value : "Action_cat_descr_1"},
			{ key : "8", value : "Action_cat_descr_2"},
			{ key : "9", value : "Action_cat_descr_3"}
		];
		return [array1, array2];
	}

}