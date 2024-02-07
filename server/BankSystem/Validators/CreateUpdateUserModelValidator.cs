using System.Data;
using System.Text.RegularExpressions;
using BankSystem.Models;
using BankSystem.Utils;
using FluentValidation;

namespace BankSystem.Validators;

public class CreateUpdateUserModelValidator : AbstractValidator<CreateUpdateUserModel>
{
    public CreateUpdateUserModelValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().Matches(RegexProvider.OnlyLetters);
        RuleFor(x => x.LastName).NotEmpty().Matches(RegexProvider.OnlyLetters);
        RuleFor(x => x.MiddleName).NotEmpty().Matches(RegexProvider.OnlyLetters);
        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now);
        RuleFor(x => x.SexId).NotEmpty();
        RuleFor(x => x.PassportSeries).NotEmpty().Matches(RegexProvider.PassportSeries);
        RuleFor(x => x.PassportNumber).NotEmpty().Matches(RegexProvider.PassportNumber);
        RuleFor(x => x.Issuer).NotEmpty();
        RuleFor(x => x.IssueDate).LessThan(DateTime.Now);
        RuleFor(x => x.IdentificationNumber).Matches(RegexProvider.IdentificationNumber);
        RuleFor(x => x.PlaceOfBirth).NotEmpty();
        RuleFor(x => x.CurrentResidenceCityId).NotEmpty();
        RuleFor(x => x.CurrentResidenceAddress).NotEmpty();
        RuleFor(x => x.HomePhoneNumber).Matches(RegexProvider.HomePhoneNumber);
        RuleFor(x => x.MobilePhoneNumber).Matches(RegexProvider.MobilePhoneNumber);
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.RegistrationAddress).NotEmpty();
        RuleFor(x => x.MaritalStatusId).NotEmpty();
        RuleFor(x => x.CitizenshipId).NotEmpty();
        RuleFor(x => x.DisabilityId).NotEmpty();
        RuleFor(x => x.MonthIncome).GreaterThanOrEqualTo(0);
    }
}