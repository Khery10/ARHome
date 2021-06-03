using System;

namespace ARHome.GenericSubDomain.Exceptions
{
    public class ARHomeInvalidOperationException : Exception
    {
        public ARHomeInvalidOperationException(string message) : base(message)
        {
        }
    }
}