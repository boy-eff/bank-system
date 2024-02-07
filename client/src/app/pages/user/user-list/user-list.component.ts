import { Component } from '@angular/core';
import {MatListModule} from '@angular/material/list';
import { User } from '../../../interfaces/user';
import { Sex } from '../../../enums/sex';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [MatListModule, CommonModule, RouterModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.less'
})
export class UserListComponent {
  users: User[] = [
    {
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
    },
  ];

  getUserFullName(index: number): string {
    let user = this.users[index];
    if (user === null) {
      return ""
    }

    let userFullName = user.firstName + " " + user.lastName;
    if (user.middleName !== null) {
      userFullName += " " + user.middleName;
    }

    return userFullName;
  }
}
