using System.Text.RegularExpressions;

namespace BankSystem.Utils;

public static partial class RegexProvider
{
    public static Regex IdentificationNumber => _identificationNumber();

    public static Regex OnlyLetters => _onlyLetters();

    public static Regex PassportSeries { get; set; } = _passportSeries();
    
    public static Regex PassportNumber => _passportNumber();

    public static Regex HomePhoneNumber => _homePhoneNumber();

    public static Regex MobilePhoneNumber => _mobilePhoneNumber();

    [GeneratedRegex(@"^\d{7}[a-zA-Z]\d{3}[a-zA-Z]{2}\d$")]
    private static partial Regex _identificationNumber();
    [GeneratedRegex("^[a-zA-Z]+$")]
    private static partial Regex _onlyLetters();
    [GeneratedRegex("^\\d{7}$")]
    private static partial Regex _passportNumber();
    [GeneratedRegex(@"^\d{5}$")]
    private static partial Regex _homePhoneNumber();
    [GeneratedRegex(@"^\d{12}$")]
    private static partial Regex _mobilePhoneNumber();
    [GeneratedRegex(@"^[a-zA-Z]{2}$")]
    private static partial Regex _passportSeries();
}