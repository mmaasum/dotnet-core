import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { of, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class TranslateService {

	private language: string = "ENG";
	private languageFiles: string[] = [];
	translate: any = {};

	constructor(private http: HttpClient) { }

	/**
	 * Set the language code that will be used in the page.
	 * Acceptable langugae codes are 'eng', 'ita', 'esp'.
	 * Language code is case insensitive.
	 * @param lang 
	 */
	use(lang: string) {
		this.language = lang.toUpperCase();
		this.clearFileKeyInTranslateObject();
		this.load(this.languageFiles);
	}


	/**
	 * Load translation from files.
	 * @param files 
	 */
	load(files: string[]) {
		this.languageFiles = files;
		this.languageFiles.forEach(lang => {
			this.loadLanguageJsonFile(lang).subscribe(res => this.translate[lang] = res[lang]);
			// this.loadLanguageJsonFile(lang).subscribe(res => {this.translate[lang] = res[lang];console.log(res)});
		})
	}


	/**
	 * Gets the translated value of a key.
	 * If key does not exist, then returns back the key.
	 * Otherwise return the translated value of the key.
	 */
	get(key: string, params?: any): Observable<any> {

		var keyParts = key.split('.');
		var langFile = keyParts[0];

		if (this.translate[langFile] == undefined) {
			return this.loadLanguageJsonFile(keyParts[0])
				.pipe(
					map(
						res => {
							this.translate[langFile] = res[langFile];
							var dt = this.extractValueFromKey(keyParts);
							return (this.replcaeWithParam(dt, params));
						}
					)
				)
		}
		else {
			var dt = this.extractValueFromKey(keyParts);
			return of(this.replcaeWithParam(dt, params));
		}
	}

	/**
	 * Returns a translation instantly from the internal state of loaded translation.
	 * Be careful using this method.
	 * If translation files are not loaded in memory, this will not return the translation.
	 */
	instant(key: string, params?: any): string {
		var keyParts = key.split('.');
		var dt = this.extractValueFromKey(keyParts);
		return this.replcaeWithParam(dt, params);
	}


	private loadLanguageJsonFile(lang: string) {
		return this.http.get<any>(`assets/localization/${lang}_loc_${this.language}.json`);
	}

	private clearFileKeyInTranslateObject() {
		this.translate = {};
	}

	private extractValueFromKey(keyParts: string[]): any {
		var tempData = this.translate;
		keyParts.forEach(a => {
			tempData = tempData[a];
		});
		return tempData ? tempData : keyParts.join('.');
	}

	private replcaeWithParam(source: any, params: any) {
		if (typeof source == "string") {
			for (var k in params) {
				var regEx = new RegExp("{{[ ]*" + k + "[ ]*}}", "gi");
				source = source.replace(regEx, params[k]);
			}
		}
		return source;
	}
}
