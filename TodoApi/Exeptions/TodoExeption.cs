namespace TodoApi.Exeptions;

public sealed class TodoException : Exception
{
    public TodoException(string? message) : base(message)
    {
    }
}