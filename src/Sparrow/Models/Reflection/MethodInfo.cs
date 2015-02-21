using Mono.Cecil;
using Sparrow.Identity;

namespace Sparrow.Models.Reflection
{
    internal sealed class MethodInfo : IMethodInfo
    {
        private readonly MethodDefinition _definition;
        private readonly string _identity;

        public string Identity
        {
            get { return _identity; }
        }

        public MethodDefinition Definition
        {
            get { return _definition; }
        }

        public MethodInfo(MethodDefinition definition)
        {
            _definition = definition;
            _identity = CRefGenerator.GetMethodCRef(definition);
        }
    }
}
