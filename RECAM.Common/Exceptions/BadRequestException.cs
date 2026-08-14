using System;

namespace RECAM.Common.Exceptions;

public class BadRequestException : AppException
{
    public BadRequestException(string message) : base(400, message)
    {
        // StatusCode = 400; // alreadt set by :base(400, message)
    }

    // public int StatusCode { get; } // parent class AppException already has
}
