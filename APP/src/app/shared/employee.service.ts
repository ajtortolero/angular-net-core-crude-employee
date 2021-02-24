import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Environment } from 'src/environments/environment';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable({
	providedIn: 'root'
})
export class EmployeeService {
	_Error: any
	_EmployeeData: Employee;
	_EmployeeList: Employee[];

	readonly _ApiUri = Environment.api.uri;

	constructor(
		private pHttpClient: HttpClient
	) {

	}
	getList() {
		this.pHttpClient.get(this._ApiUri + '/Employee/Employees/GetList').toPromise()
			.then(Result => this._EmployeeList = Result as Employee[])
			.catch((ResultError: HttpErrorResponse) => {
				this._Error = ResultError.error;
				if (ResultError.error instanceof Error) {
					console.error('An error occurred:', ResultError.error.message);
				} else {
					console.error(`Backend returned code ${ResultError.status}, body was: ${ResultError.error}`);
				}
				this._EmployeeList = null;
			});
	}
	getByDocumentNumber(pDocumentNumberode: String) {
		this.pHttpClient.get(this._ApiUri + '/Employee/Employees/GetByDocumentNumber/' + pDocumentNumberode).toPromise()
			.then(Result => { 
				var varEmployee = Result as Employee;
				if(varEmployee.DocumentNumber !== null) {
					this._EmployeeList == [];
					this._EmployeeList.push(Result as Employee);
					//console.log(Result as Employee); this._EmployeeList.push(Result as Employee) 
				}				
			})
			.catch((ResultError: HttpErrorResponse) => {
				this._Error = ResultError.error;
				if (ResultError.error instanceof Error) {
					console.error('An error occurred:', ResultError.error.message);
				} else {
					console.error(`Backend returned code ${ResultError.status}, body was: ${ResultError.error}`);
				}
				this._EmployeeList = null;
			});
	}
	post(pData: Employee) {
		pData.EmployeeID = 0;
		return  this.pHttpClient.post(this._ApiUri + '/Employee/Employees/Create', pData);
	}
	put(pData: Employee) {
		return this.pHttpClient.put(this._ApiUri + '/Employee/Employees/Update/' + pData.EmployeeID, pData);
	}
	delete(pEmployeeID: number) {
		return this.pHttpClient.delete(this._ApiUri + '/Employee/Employees/Delete/' + pEmployeeID);
	}
}