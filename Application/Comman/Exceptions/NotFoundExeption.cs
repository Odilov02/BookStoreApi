﻿namespace Application.Comman.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException() : base("Not Found")
    {
    }
    public NotFoundException(string message)
        : base(message)
    {
    }
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
