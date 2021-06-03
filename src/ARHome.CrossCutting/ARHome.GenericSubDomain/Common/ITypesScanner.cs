using System;
using System.Collections.Generic;

namespace ARHome.GenericSubDomain.Common
{
    public interface ITypesScanner
    {
        Type Find(string typeFullName);
        IEnumerable<AssemblyScanResult> Find(Type openGenericType);
    }
}