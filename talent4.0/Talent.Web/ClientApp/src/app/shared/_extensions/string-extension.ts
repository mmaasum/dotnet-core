declare global {
	interface String {
        /**
         * Convert 'dd/MM/yyyy' format string to date object.
         */
		toCustomDate(): Date;
	}
}

String.prototype.toCustomDate = function (): Date {
	var dd = Number(this.substr(0, 2));
	var mm = Number(this.substr(3, 2)) - 1;
	var yy = Number(this.substr(6, 4));
	return new Date(yy, mm, dd, 12, 0, 0);
}


export { };   