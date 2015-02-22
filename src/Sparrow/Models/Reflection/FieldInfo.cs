using Mono.Cecil;
using Sparrow.Identity;

namespace Sparrow.Models.Reflection
{
    internal sealed class FieldInfo : IFieldInfo
    {
                private readonly FieldDefinition _definition;
        private readonly string _identity;

        public string Identity
        {
            get { return _identity; }
        }

        public FieldDefinition Definition
        {
            get { return _definition; }
        }

        public FieldInfo(FieldDefinition definition)
        {
            _definition = definition;
            _identity = CRefGenerator.GetFieldCRef(definition);
        }
    }
}
