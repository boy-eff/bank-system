import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatStepperModule} from '@angular/material/stepper';
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import { Sex } from '../../../enums/sex';
import { EnumPipe } from "../../../pipes/enum.pipe";
import {MatCheckboxModule} from '@angular/material/checkbox';

@Component({
    selector: 'app-create-user',
    standalone: true,
    templateUrl: './create-user.component.html',
    styleUrl: './create-user.component.less',
    imports: [
      CommonModule, 
      FormsModule, 
      ReactiveFormsModule, 
      MatFormFieldModule, 
      MatInputModule, 
      MatButtonModule, 
      MatStepperModule, 
      MatDatepickerModule, 
      MatNativeDateModule, 
      MatRadioModule, 
      MatCheckboxModule,
      EnumPipe]
})
export class CreateUserComponent {
  sexEnum = Sex;
  userForm: FormGroup = this._formBuilder.group({
    stepsArray: this._formBuilder.array(
      [
        this._formBuilder.group({
          firstName: this._formBuilder.control('', Validators.required),
          lastName: this._formBuilder.control('', Validators.required),
          middleName: this._formBuilder.control('', Validators.required),
          dateOfBirth: this._formBuilder.control('', Validators.required),
          sex: this._formBuilder.control('', Validators.required),
          maritalStatus: this._formBuilder.control('', Validators.required),
        }),
        this._formBuilder.group({
          passportSeries: this._formBuilder.control('', Validators.required),
          passportNumber: this._formBuilder.control('', [Validators.required, Validators.pattern(/^\d{7}$/)]),
          issuer: this._formBuilder.control('', Validators.required),
          issueDate: this._formBuilder.control('', Validators.required),
          identityNumber: this._formBuilder.control('', [Validators.required, Validators.pattern(/^\d{7}[A-Z]\d{3}[A-Z]{2}\d$/)]),
          placeOfBirth: this._formBuilder.control('', Validators.required),
          registrationAddress: this._formBuilder.control('', Validators.required),
        }),
        this._formBuilder.group({
          actualResidenceCity: this._formBuilder.control('', Validators.required),
          actualResidenceAddress: this._formBuilder.control('', Validators.required),
          homePhone: this._formBuilder.control('', Validators.pattern(/^\d{5}$/)),
          mobilePhone: this._formBuilder.control('', Validators.pattern(/^\d{9}$/)),
          email: this._formBuilder.control('')
        }),
        this._formBuilder.group({
          isRetiree: this._formBuilder.control('', Validators.required),
          disability: this._formBuilder.control('', Validators.required),
          monthIncome: this._formBuilder.control('')
        })
      ])
  });

  get stepsArray(): AbstractControl { return this.userForm.get('stepsArray'); }
  
  constructor(private _formBuilder: FormBuilder) {
  }
}
