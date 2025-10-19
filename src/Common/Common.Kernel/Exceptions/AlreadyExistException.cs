namespace Common.Kernel.Exceptions;

public class AlreadyExistException : Exception
{
    public string Value { get; }
    public object Key { get; }

    public AlreadyExistException(string value, object key) 
        : base($"{value} with key '{key}' already exists")
    {
        Value = value;
        Key = key;
    }
}