import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgSelectModule } from '@ng-select/ng-select';
import { CKEditorModule } from 'ckeditor4-angular';
import { BsDatepickerModule, ModalModule } from 'ngx-bootstrap';
import { ColorPickerModule } from 'ngx-color-picker';

import { TranslatePipe } from './shared/_pipes/translate';

@NgModule({
	declarations: [
		TranslatePipe
	],
	imports: [
		FormsModule,
		BrowserModule,
		BrowserAnimationsModule,
		ReactiveFormsModule,
		NgSelectModule,
		ColorPickerModule,
		CKEditorModule,
		BsDatepickerModule.forRoot(),
		ModalModule.forRoot()
	],
	providers: [

	],
	exports: [
		TranslatePipe,
		FormsModule,
		BrowserModule,
		BrowserAnimationsModule,
		ReactiveFormsModule,
		CKEditorModule,
		ColorPickerModule,
		NgSelectModule,
		BsDatepickerModule,
		ModalModule
	]
})
export class AppCommonModule { }