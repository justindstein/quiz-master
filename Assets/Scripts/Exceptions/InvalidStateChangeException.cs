using System;

public class InvalidStateChangeException : InvalidOperationException
{
    public InvalidStateChangeException(string message) : base(message)
    {
    }
}