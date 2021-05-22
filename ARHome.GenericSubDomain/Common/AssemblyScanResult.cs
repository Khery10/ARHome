using System;

namespace ARHome.GenericSubDomain.Common
{
    public sealed class AssemblyScanResult
    {
        public AssemblyScanResult(Type interfaceType, Type implementationType)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
        }

        public Type InterfaceType { get; }

        public Type ImplementationType { get; }
    }
}