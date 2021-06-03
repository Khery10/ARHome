using System;
using System.Net;

namespace ARHome.GenericSubDomain.Middleware
{
    public interface IExceptionDescriptor
    {
        bool CanHandle(Exception ex);

        HttpStatusCode StatusCode { get; }

        ErrorResult Handle(Exception ex);
    }
}