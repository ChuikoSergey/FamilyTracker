using System;
namespace FamilyTracker.Business.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base()
        { }

        public ValidationException(string message)
            : base(message)
        { }

        public ValidationException(string messageToFormat, params object[] parameters)
            : base(string.Format(messageToFormat, parameters))
        { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
