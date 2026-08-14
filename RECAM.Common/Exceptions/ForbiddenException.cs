using System;

namespace RECAM.Common.Exceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException(string message) : base(403, message)
    {
    }
}
