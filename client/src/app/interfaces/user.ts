import { Sex } from "../enums/sex";
import { City } from "./city";
import { Disability } from "./disability";
import { MaritalStatus } from "./marital-status";

export interface User {
  lastName: string;
  firstName: string;
  middleName: string;
  dateOfBirth: Date;
  sex: Sex;
  passportSeries: string;
  passportNumber: string;
  issuer: string;
  issueDate: Date;
  identityNumber: string;
  placeOfBirth: string;
  actualResidenceCity: City;
  actualResidenceAddress: string;
  homePhone: string;
  mobilePhone: string;
  email: string;
  registrationAddress: string;
  maritalStatus: MaritalStatus;
  isRetiree: boolean;
  disability: Disability;
  monthIncome: number;
}