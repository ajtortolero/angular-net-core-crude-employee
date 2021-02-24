import { Component, OnInit, AfterViewInit } from '@angular/core';

import { NgForm } from '@angular/forms';

import { EmployeeService } from 'src/app/shared/employee.service';
import { Employee } from 'src/app/models/employee';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
    /** Error Form */
	_Error: any
  
    pageView: Array<Employee>;

  
    constructor(
        public _EmployeeService: EmployeeService,
        private _Toastr: ToastrService,  
        private _Spinner: NgxSpinnerService
        ) {
    }

  ngOnInit() {
    this._EmployeeService.getList();
  }
  populateForm(pEmployee: Employee) {
    console.log(pEmployee);
    this._EmployeeService._EmployeeData = Object.assign({}, pEmployee);
  }
  onDelete(pID: number) {
    if (confirm('Esta seguro de eliminar el Empleado?')) {
        console.log(pID);
        this._EmployeeService.delete(pID).toPromise()
            .then(Result => {
                console.log(Result);
                this._Spinner.hide();
                this._Toastr.success('El empleado fue actualizado correctamente', 'Actualizacion de Empleados');
                this._EmployeeService.getList()
            })
            .catch((Result: HttpErrorResponse) => {
                this._Error = Result.error;

                if (Result.error instanceof Error) {
                    console.error('An error occurred:', Result.error.message);
                } else {
                    console.error(`Backend returned code ${Result.status}, body was: ${Result.error}`);
                }
                this._Spinner.hide();
                this._Toastr.error('No fue posible actualizar el Empleado', 'Empleados');
            });
    }
  }
}