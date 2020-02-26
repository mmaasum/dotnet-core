import { HttpClient, HttpEvent, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'shared/auth/auth.service';
import { Azioni } from 'shared/models/azioni';
import { ILoggedInUser } from 'shared/models/loggedin-user';


@Injectable()
export class CommonServiceOld {
	user: ILoggedInUser;

	constructor(public http: HttpClient, public auth: AuthService) {
		this.user = auth.currentUserObject;
	}

    /**
        * Log a task into Azioni table.
    */
	log(azioni: Azioni): Observable<any> {
		return this.http.post("/api/Azioni/postAzioni", azioni);
	}


    /**
        * Convert a datetime string to provided format.
    */
	formatDateTimeString(val: any, format: string) {
		var dateTimeVal = new Date(val);
		if (dateTimeVal.toDateString() === "Invalid Date" || val === null) {
			return "";
		}

		// Extracting date portion.
		var dd = dateTimeVal.getDate() < 10 ? "0" : "";
		dd += dateTimeVal.getDate().toString();

		// Extracting month portion.
		var month = dateTimeVal.getMonth() + 1;
		var MM = month <= 10 ? "0" : "";
		MM += month.toString();

		// Extracting year portion.
		var yyyy = dateTimeVal.getFullYear().toString();

		// Extracting hour portion.
		var hh = dateTimeVal.getHours() < 10 ? "0" : "";
		hh += dateTimeVal.getHours().toString();

		// Extracting miniute portion.
		var min = dateTimeVal.getMinutes() < 10 ? "0" : "";
		min += dateTimeVal.getMinutes().toString();

		// Extracting  seconds portion.
		var ss = dateTimeVal.getSeconds() < 10 ? "0" : "";
		ss += dateTimeVal.getSeconds().toString();

		// Extracting miliseconds portion.
		var milSs = dateTimeVal.getMilliseconds().toString();


		var formattedDate: string = "";
		switch (format) {
			case "dd/MM/yyyy hh:mm:ss":
				formattedDate = dd + "/" + MM + "/" + yyyy + " " + hh + ":" + min + ":" + ss + "." + milSs;
				break;
			case "dd-MM-yyyy hh:mm:ss":
				formattedDate = dd + "-" + MM + "-" + yyyy + " " + hh + ":" + min + ":" + ss + "." + milSs;
				break;
			case "dd/MM/yyyy":
				formattedDate = dd + "/" + MM + "/" + yyyy;
				break;
			case "dd-MM-yyyy":
				formattedDate = dd + "-" + MM + "-" + yyyy;
				break;
			case "yyyy/MM/dd":
				formattedDate = yyyy + "/" + MM + "/" + dd;
				break;
			case "yyyy-MM-dd":
				formattedDate = yyyy + "-" + MM + "-" + dd;
				break;
			case "yyyyMMdd":
				formattedDate = yyyy + MM + dd;
				break;

			default:
				break;
		}

		return formattedDate;
	}

	private getEventMessage(event: HttpEvent<any>) {
		console.log(event);
		switch (event.type) {
			case HttpEventType.Sent:
				return `Uploading file .`;

			case HttpEventType.UploadProgress:
				// Compute and show the % done:
				const percentDone = Math.round(100 * event.loaded / event.total);
				console.log("Upload => " + percentDone);
				return ` is ${percentDone}% uploaded.`;

			case HttpEventType.DownloadProgress:
				// Compute and show the % done:
				const percentDones = Math.round(100 * event.loaded / event.total);
				console.log("Download => " + percentDones);
				return ` is ${percentDones}% downloaded.`;

			case HttpEventType.Response:
				console.log("Completed");
				return event.body;

			default:
				return `surprising upload event: ${event.type}.`;
		}
	}
}