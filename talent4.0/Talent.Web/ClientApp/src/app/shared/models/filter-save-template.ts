import { FilterTemplate } from "./filter-template";

export class FilterSaveTemplate extends FilterTemplate {
	searchName: string;
	searchDesciption: string;
	pageURL: string = "";
	filterData: string;
	sortingData: string;
}