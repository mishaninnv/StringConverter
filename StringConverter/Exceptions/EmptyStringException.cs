namespace StringConverter.Exceptions;

public class EmptyStringException : Exception
{
    public EmptyStringException(string message) : base(message) { }
}
