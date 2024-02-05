namespace BankSystem.Models;

public class CreateUpdateUserModel
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int SexId { get; set; }
    public string PassportSeries { get; set; }
    public string PassportNumber { get; set; }
    public string Issuer { get; set; }
    public DateTime IssueDate { get; set; }
    public string IdentificationNumber { get; set; }
    public string PlaceOfBirth { get; set; }
    public int CurrentResidenceCityId { get; set; }
    public string CurrentResidenceAddress { get; set; }
    public string? HomePhoneNumber { get; set; }
    public string? MobilePhoneNumber { get; set; }
    public string? Email { get; set; }
    public string RegistrationAddress { get; set; }
    public int MaritalStatusId { get; set; }
    public int CitizenshipId { get; set; }
    public int DisabilityId { get; set; }
    public bool IsRetiree { get; set; }
    public decimal MonthIncome { get; set; }
}