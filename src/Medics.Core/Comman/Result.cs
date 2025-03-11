namespace Medics.Core.Abstraction;

public class Result
{

    protected internal Result(bool isSuccess, string? message, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();

        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Message = message;
        Error = error;
    }

    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; private set; }

    public static Result Success(string Message) => new Result(true, Message, Error.None);
    public static Result Failure(string failureMessage, Error error) => new Result(false, failureMessage, error);


    public static Result Success() => new Result(true, string.Empty, Error.None);
    public static Result Failure() => new Result(false, string.Empty, Error.None);
    public static Result Failure(Error error) => new Result(false, string.Empty, error);
    public static Result<TValue> Success<TValue>(TValue value, string? Message = null) => new(value, Message, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error, string? Message = null) => new(default, Message, false, error);
    public static Result<TValue> Create<TValue>(TValue value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;
    protected internal Result(TValue? value, string? Message, bool IsSuccess, Error error) : base(IsSuccess, Message, error)
    {
        _value = value;
    }
    public TValue? Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public void Sort(Func<object, object, int> value)
    {
        throw new NotImplementedException();
    }

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
