import { Pipe, PipeTransform } from '@angular/core';
import { map } from 'rxjs/operators';

@Pipe({ name: 'translate' })
export class TranslatePipe implements PipeTransform {
	// transform(value: any, ...args: any[]) {
	//     throw new Error("Method not implemented.");
	// }
	transform(value: any, ...args: any): string {
		if (args[0].length > 0) {
			var params: any;
			if (args[0].length > 1) {
				params = args[0][1];
			}
			return args[0][0].get(value, params).pipe(
				map(
					(res: any) => {
						if (typeof res == "object") {
							return JSON.stringify(res);
						}
						else {
							return res;
						}

					}
				)
			);
		}

		//return value.value;
	}
}