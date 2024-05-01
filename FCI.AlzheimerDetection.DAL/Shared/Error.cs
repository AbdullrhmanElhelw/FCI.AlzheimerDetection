namespace FCI.AlzheimerDetection.DAL.Shared;

public class Error
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }

    public static implicit operator Error(string message) => new(message);

    public static implicit operator string(Error error) => error.Message;
}