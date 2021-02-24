import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { MatDialogModule } from "@angular/material/dialog";

import { AppComponent } from './app.component';

import { EmployeeComponent } from './components/employee/employee.component';
import { EmployeeFormComponent } from './components/employee/employee-form/employee-form.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeService } from './shared/employee.service';
import { AreaService } from './shared/area.service';
import { DocumentTypeService } from './shared/document-type.service';
import { DialogComponent } from './components/dialog/dialog.component';
import { AlertComponent } from './components/alert/alert.component';

import { EmployeeDirective } from './directives/employee.directive';
import { CustomMinDirective, CustomMaxDirective } from './directives/global.directive';

@NgModule({
	declarations: [
		AppComponent,
		EmployeeComponent,
		EmployeeFormComponent,
		EmployeeListComponent,
		EmployeeDirective,
		CustomMinDirective,
		CustomMaxDirective,
		DialogComponent,
		AlertComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		ReactiveFormsModule,
		HttpClientModule,
		BrowserAnimationsModule,
		MatDialogModule,
		NgxSpinnerModule,
		ToastrModule.forRoot()
	],
	providers: [EmployeeService, AreaService, DocumentTypeService, DialogComponent, AlertComponent],
	bootstrap: [AppComponent]
})
export class AppModule { }