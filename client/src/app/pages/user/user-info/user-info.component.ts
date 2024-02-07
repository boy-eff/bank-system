import { Component } from '@angular/core';
import { User } from '../../../interfaces/user';
import { Sex } from '../../../enums/sex';
import { CommonModule } from '@angular/common';
import {MatDividerModule} from '@angular/material/divider';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [CommonModule, MatDividerModule],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.less'
})
export class UserInfoComponent {
  user: User = {
    lastName: 'Doe',
    firstName: 'John',
    middleName: 'Smith',
    dateOfBirth: new Date('1990-01-01'),
    sex: Sex.Male,
    passportSeries: 'ABC',
    passportNumber: '123456',
    issuer: 'Government',
    issueDate: new Date('2010-01-01'),
    identityNumber: 'ID123',
    placeOfBirth: 'CityX',
    actualResidenceCity: { id: 1, name: "Minsk" },
    actualResidenceAddress: '123 Main St',
    homePhone: '123-456-7890',
    mobilePhone: '987-654-3210',
    email: 'john.doe@example.com',
    registrationAddress: '456 Second St',
    maritalStatus: { id: 1, name: "Married" },
    isRetiree: false,
    disability: { id: 1, name: "Doter"},
    monthIncome: 5000
  }

  getSexAsString(sex: Sex) {
    return Sex[sex];
  }
}
