declare global {
	interface Date {
		getDatePortion(): string;
		addDays(days: number): Date;
		addMonths(months: number): Date;
		addHours(hours: number): Date;
		addMinutes(minutes: number): Date;
	}
}

Date.prototype.getDatePortion = function (): string {
	if (this == null || this == undefined)
		return "";
	// Extracting date portion.
	var dd = this.getDate() < 10 ? "0" : "";
	dd += this.getDate().toString();

	// Extracting month portion.
	var month = this.getMonth() + 1;
	var MM = month < 10 ? "0" : "";
	MM += month.toString();

	// Extracting year portion.
	var yyyy = this.getFullYear().toString();

	// Extracting hour portion.
	var hh = this.getHours() < 10 ? "0" : "";
	hh += this.getHours().toString();

	// Extracting miniute portion.
	var min = this.getMinutes() < 10 ? "0" : "";
	min += this.getMinutes().toString();

	// Extracting  seconds portion.
	var ss = this.getSeconds() < 10 ? "0" : "";
	ss += this.getSeconds().toString();

	// Extracting miliseconds portion.
	var milSs = this.getMilliseconds().toString();

	// return yyyy + "-" + MM + "-" + dd ; 
	return dd + "/" + MM + "/" + yyyy;
}

Date.prototype.addMonths = function (months: number): Date {
	var dt = new Date(this.getTime() + (months * 30 * 24 * 60 * 60 * 1000));
	return dt;
}

Date.prototype.addDays = function (days: number): Date {
	var dt = new Date(this.getTime() + (days * 24 * 60 * 60 * 1000));
	return dt;
}

Date.prototype.addHours = function (hours: number): Date {
	var dt = new Date(this.getTime() + (hours * 60 * 60 * 1000));
	return dt;
}

Date.prototype.addMinutes = function (minutes: number): Date {
	var dt = new Date(this.getTime() + (minutes * 60 * 1000));
	return dt;
}

export { };   