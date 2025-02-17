﻿namespace ARHome.GenericSubDomain.Middleware
{
    public sealed class ErrorProperty
    {
        public string Key { get; }
        public string Message { get; }

        public ErrorProperty(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}