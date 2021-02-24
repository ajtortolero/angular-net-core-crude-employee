import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { AreaService } from 'src/app/shared/area.service';
import { DocumentTypeService } from '../../../shared/document-type.service';
import { Employee } from '../../../models/employee';

import { NgForm } from '@angular/forms';

import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { AlertComponent } from 'src/app/components/alert/alert.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpErrorResponse } from "@angular/common/http";

@Component({
	selector: 'app-employee-form',
	templateUrl: './employee-form.component.html',
	styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit 
{   
    /** Error Form */
	_Error: any

    /** Employee Data */
	_EmployeeData: Employee;

    /** Employee List */
	_EmployeeList: Employee[];

	/** Switch To form submitted */
	_FormSubmitted = false;

	/** Class form constructor */
	constructor(
		public _EmployeeService: EmployeeService,
		public _AreaService: AreaService,
        public _DocumentTypeService: DocumentTypeService,
		private _Dialog: MatDialog,
		private _Toastr: ToastrService,
		private _Spinner: NgxSpinnerService
	) {

	}

	/** Init form */
	ngOnInit() {
		this.resetForm();
		this._AreaService.refreshList();
        this._DocumentTypeService.refreshList();
	}

	/** On reset form */
	resetForm(pForm?: NgForm) {
		if (pForm != null)
			pForm.resetForm();

		this._FormSubmitted = false;
		this._EmployeeService._EmployeeData = {
			EmployeeID: null,
            DocumentTypeID: 0,
			DocumentNumber: '',
			Name: '',
			LastName: '',
            BirthDate: null,
			AreaID: 0
		};
	}

	/** On Submit form */
	onSubmit(pForm: NgForm) {
		this._FormSubmitted = true;
		if (!pForm.invalid) {
			if (pForm.value.EmployeeID == null) {
				this.createdEmployee(pForm);
			}
			else {
				this.updateEmployee(pForm);
			}
		}
	}

	/** Method to create a employee */
	createdEmployee(pForm: NgForm) {
		try {
			this._Spinner.show();
            this._EmployeeService.post(pForm.value).toPromise()
                .then(Result => {
                    this._EmployeeData = Result as Employee;
                    this._Spinner.hide();
                    this._Toastr.success('El empleado fue creado correctamente', 'Creación de Empleados');
                    this.resetForm(pForm);
                    this._EmployeeService.getList()
                })
                .catch((Result: HttpErrorResponse) => {
                    this._Error = Result.error;

                    if (Result.error instanceof Error) {
                        console.error('An error occurred:', Result.error.message);
                    } else {
                        console.error(`Backend returned code ${Result.status}, body was: ${Result.error}`);
                    }
                    this._EmployeeData = null;

                    this._Spinner.hide();
                    this._Toastr.error('No fue posible crear el Empleado', 'Empleados');
                });
		} catch (error) {
			this._Spinner.hide();
		}
	}

	/** Method to update a employee */
	updateEmployee(pForm: NgForm) {
		try {
			this._Spinner.show();
            this._EmployeeService.put(pForm.value).toPromise()
                .then(Result => {
                    this._EmployeeData = Result as Employee;
                    this._Spinner.hide();
                    this._Toastr.success('El empleado fue actualizado correctamente', 'Actualizacion de Empleados');
                    this.resetForm(pForm);
                    this._EmployeeService.getList()
                })
                .catch((Result: HttpErrorResponse) => {
                    this._Error = Result.error;

                    if (Result.error instanceof Error) {
                        console.error('An error occurred:', Result.error.message);
                    } else {
                        console.error(`Backend returned code ${Result.status}, body was: ${Result.error}`);
                    }
                    this._EmployeeData = null;

                    this._Spinner.hide();
                    this._Toastr.error('No fue posible actualizar el Empleado', 'Empleados');
                });
		} catch (error) {
			this._Spinner.hide();
		}
	}
}