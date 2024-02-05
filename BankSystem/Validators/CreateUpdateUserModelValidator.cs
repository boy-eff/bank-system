using System.Data;
using System.Text.RegularExpressions;
using BankSystem.Models;
using FluentValidation;

namespace BankSystem.Validators;

public class CreateUpdateUserModelValidator : AbstractValidator<CreateUpdateUserModel>
{
    public CreateUpdateUserModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.MiddleName).NotEmpty();
        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now);
        RuleFor(x => x.SexId).NotEmpty();
        RuleFor(x => x.PassportSeries).NotEmpty();
        RuleFor(x => x.PassportNumber).NotEmpty().Matches(new Regex("\\d{7}"));
        RuleFor(x => x.Issuer).NotEmpty();
        RuleFor(x => x.IssueDate).LessThan(DateTime.Now);
        RuleFor(x => x.IdentificationNumber).Matches(@"\d{7}[a-zA-Z]\d{3}[a-zA-Z]{2}\d$");
        RuleFor(x => x.PlaceOfBirth).NotEmpty();
        RuleFor(x => x.CurrentResidenceCityId).NotEmpty();
        RuleFor(x => x.CurrentResidenceAddress).NotEmpty();
        RuleFor(x => x.HomePhoneNumber).Matches(@"\d{5}");
        RuleFor(x => x.MobilePhoneNumber).Matches(@"\d{12}");
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.RegistrationAddress).NotEmpty();
        RuleFor(x => x.MaritalStatusId).NotEmpty();
        RuleFor(x => x.CitizenshipId).NotEmpty();
        RuleFor(x => x.DisabilityId).NotEmpty();
        RuleFor(x => x.MonthIncome).GreaterThanOrEqualTo(0);
    }
}