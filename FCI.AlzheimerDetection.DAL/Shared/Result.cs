namespace FCI.AlzheimerDetection.DAL.Shared;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    public Result(bool isSuccess, Error? error = null)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TData> Success<TData>(TData data) => new(true, data);

    public static Result<TData> Failure<TData>(Error error) => new(false, default, error);
}