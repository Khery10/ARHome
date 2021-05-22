using System;

namespace ARHome.GenericSubDomain.Exceptions
{
    public class ARHomeException : ApplicationException
    {
        public ARHomeException(string message)
            : base(message)
        {
        }

        public ARHomeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }  
    }
}