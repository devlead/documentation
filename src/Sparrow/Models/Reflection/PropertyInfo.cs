using Mono.Cecil;
using Sparrow.Identity;

namespace Sparrow.Models.Reflection
{
    internal sealed class PropertyInfo : IPropertyInfo
    {
        private readonly string _identity;
        private readonly PropertyDefinition _definition;

        public string Identity
        {
            get { return _identity; }
        }

        public PropertyDefinition Definition
        {
            get { return _definition; }
        }

        public PropertyInfo(PropertyDefinition definition)
        {
            _definition = definition;
            _identity = CRefGenerator.GetProprtyCRef(definition);
        }
    }
}
