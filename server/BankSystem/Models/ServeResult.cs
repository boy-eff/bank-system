namespace BankSystem.Models;

public class ServeResult<T>
{
    public ServeResult(T result)
    {
        Result = result;
        Success = true;
    }

    public ServeResult(int errorCode, string errorMessage)
    {
        Success = false;
        Error = new ErrorModel() { ErrorCode = errorCode, Message = errorMessage };
    }
    
    public ServeResult(ErrorModel error)
    {
        Success = false;
        Error = error;
    }

    public bool Success { get; set; }
    public T? Result { get; set; }
    public ErrorModel? Error { get; set; }
}