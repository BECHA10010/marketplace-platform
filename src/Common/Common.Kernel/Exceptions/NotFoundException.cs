namespace Common.Kernel.Exceptions;

public class NotFoundException : Exception
{
    public string Value { get; }
    public object Key { get; }

    public NotFoundException(string value, object key) 
        : base($"{value} with key '{key}' was not found")
    {
        Value = value;
        Key = key;
    }
}