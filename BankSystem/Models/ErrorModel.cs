namespace BankSystem.Models;

public class ErrorModel
{
    //1 - database exception, message contain constraint failure
    public int ErrorCode { get; set; }
    public string Message { get; set; }
}