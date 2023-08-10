namespace Infrastructure.Exceptions;

public class SetupException : Exception
{
    public SetupException(string message) : base(message) { }
}