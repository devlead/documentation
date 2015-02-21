using System.Collections.Generic;
using Mono.Cecil;
using Sparrow.Identity;

namespace Sparrow.Models.Reflection
{
    internal sealed class TypeInfo : ITypeInfo
    {
        private readonly TypeDefinition _type;
        private readonly List<IMethodInfo> _methods;
        private readonly List<IPropertyInfo> _properties;
        private readonly string _identity;

        public string Identity
        {
            get { return _identity; }
        }

        public TypeDefinition Definition
        {
            get { return _type; }
        }

        public IReadOnlyList<IMethodInfo> Methods
        {
            get { return _methods; }
        }

        public IReadOnlyList<IPropertyInfo> Properties
        {
            get { return _properties; }
        }

        public TypeInfo(TypeDefinition type, IEnumerable<IMethodInfo> methods, IEnumerable<IPropertyInfo> properties)
        {
            _type = type;
            _methods = new List<IMethodInfo>(methods);
            _properties = new List<IPropertyInfo>(properties);
            _identity = CRefGenerator.GetTypeCRef(type);
        }
    }
}