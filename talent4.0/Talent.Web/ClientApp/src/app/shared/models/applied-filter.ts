export class AppliedFilter {
	field: string;
	condition: string;
	value: string;
	date?: Date;
	dateRangeValue?: Date[];
	type: string;
	rowCount: number;
}