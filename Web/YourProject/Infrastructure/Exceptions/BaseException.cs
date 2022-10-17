namespace YourProject.Server.Infrastructure.Exceptions;

// TODO: Exception OneOf and Logging (possibly Serilog)

public class BaseException : Exception
{
    private string? error;

    public string Error
    {
        get => this.error ?? this.Message;
        set => this.error = value;
    }
}