using System.Collections.Generic;
using Mono.Cecil;

namespace Sparrow.Models.Reflection
{
    internal sealed class AssemblyInfo : IAssemblyInfo
    {
        private readonly AssemblyDefinition _definition;
        private readonly string _identity;
        private readonly List<ITypeInfo> _types;

        public string Identity
        {
            get { return _identity; }
        }

        public AssemblyDefinition Definition
        {
            get { return _definition; }
        }

        public IReadOnlyList<ITypeInfo> Types
        {
            get { return _types; }
        }

        public AssemblyInfo(AssemblyDefinition definition, IEnumerable<ITypeInfo> types)
        {
            _definition = definition;
            _identity = definition.FullName;
            _types = new List<ITypeInfo>(types);
        }
    }
}
