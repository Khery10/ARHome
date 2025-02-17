﻿namespace ARHome.GenericSubDomain.Middleware
{
    public sealed class ErrorResult
    {
        public bool Ok { get; }
        public ErrorProperty[] Errors { get; }

        public ErrorResult(ErrorProperty[] errors)
        {
            Ok = false;
            Errors = errors;
        }
    }
}