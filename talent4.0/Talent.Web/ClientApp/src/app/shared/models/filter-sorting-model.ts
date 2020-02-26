export class Filter {
	columnName: string;
	dataType: string;
	filterType: string;
	option1: string;
	option2: string;
}

export class Sorting {
	columnName: string;
	type: string;
}

export class FilterSortingModel {
	filters?: Filter[];
	sorting?: Sorting;
	clientColumn: string;
	joinTableQueryDto?: JoinTableQueryDto;
}


export class JoinTableQueryDto {
	joinTable: JoinTable[];
	joinTableRetreivedFields: string[];
}

export class JoinTable {
	joinTableName: string;
	joinFields: JoinTableField[];
}

export class JoinTableField {
	baseTableJoinFieldName: string;
	joinTableJoinFieldName: string;
}