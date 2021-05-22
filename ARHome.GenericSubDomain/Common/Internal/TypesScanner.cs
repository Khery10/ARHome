using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ARHome.GenericSubDomain.Common.Internal
{
    public sealed class TypesScanner : ITypesScanner
    {
        private readonly Lazy<Dictionary<string, Type>> _types;

        public TypesScanner(Assembly[] assembliesForScan)
        {
            _types = new Lazy<Dictionary<string, Type>>(() => GetTypes(assembliesForScan));
        }

        private Dictionary<string, Type> GetTypes(Assembly[] assembliesForScan)
        {
            var types = assembliesForScan
                .SelectMany(a => a.GetTypes())
                .Where(t=>t.FullName is {})
                .Where(t => t.FullName.StartsWith(AppConsts.AppNamespacePrefix, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(t => t.FullName);

            return types;
        }

        public Type Find(string typeFullName)
        {
            if (string.IsNullOrWhiteSpace(typeFullName))
                throw new ArgumentException(nameof(typeFullName));

            if (_types.Value.TryGetValue(typeFullName, out Type targetType))
                return targetType;

            throw new KeyNotFoundException($"Type {typeFullName} was not found.");
        }

        public IEnumerable<AssemblyScanResult> Find(Type openGenericType)
        {
            if (!openGenericType.IsGenericType)
                throw new ArgumentException($"Type {openGenericType} is not open generic type");
            return _types.Value.Values.Where(type => !type.IsAbstract && !type.IsGenericTypeDefinition)
                .Select(type => new
                {
                    type,
                    interfaces = type.GetInterfaces()
                }).Select(param1 => new
                {
                    TransparentIdentifier0 = param1,
                    genericInterfaces = param1.interfaces.Where(i =>
                        i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == openGenericType)
                }).Select(param1 => new
                {
                    TransparentIdentifier1 = param1,
                    matchingInterface = param1.genericInterfaces.FirstOrDefault()
                }).Where(param1 => param1.matchingInterface != (Type) null).Select(param1 =>
                    new AssemblyScanResult(param1.matchingInterface,
                        param1.TransparentIdentifier1.TransparentIdentifier0.type))
                .ToArray();
        }
    }
}