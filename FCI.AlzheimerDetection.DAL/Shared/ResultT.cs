namespace FCI.AlzheimerDetection.DAL.Shared;

public class Result<TData> : Result
{
    private readonly TData? _data;

    public Result(bool isSuccess, TData? data, Error? error = null) : base(isSuccess, error)
    {
        _data = data;
    }

    public TData Data => _data!;
}