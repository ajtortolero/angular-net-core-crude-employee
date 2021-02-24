import { Directive } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, NG_VALIDATORS, ValidationErrors, Validator, ValidatorFn } from '@angular/forms';

export const EmployeeValidator: ValidatorFn = (pControl: FormGroup): ValidationErrors | null => {
	const _DocumentTypeID = pControl.get('DocumentTypeID');
    const _DocumentNumber = pControl.get('DocumentNumber');
	const _Name = pControl.get('Name');
	const _LastName = pControl.get('LastName');
	const _BirthDate = pControl.get('BirthDate');
	const _AreaID = pControl.get('AreaID');

  return _DocumentTypeID?.invalid || _DocumentNumber?.invalid || _Name?.invalid || _LastName?.invalid || _BirthDate?.invalid || _AreaID?.invalid ? { 'employee-form-validator': true } : null;	
};

@Directive({
	selector: '[employee-form-validator]',
	providers: [{ provide: NG_VALIDATORS, useExisting: EmployeeDirective, multi: true }]
})
export class EmployeeDirective implements Validator {
	validate(pControl: AbstractControl): ValidationErrors {
		return EmployeeValidator(pControl)
	}
}