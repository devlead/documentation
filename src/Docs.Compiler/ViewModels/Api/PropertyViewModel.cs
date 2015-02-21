using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Mono.Cecil;
using Sparrow.Models.Comments;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public class PropertyViewModel : ApiViewModel
    {
        private readonly DocumentedProperty _property;

        public DocumentedProperty Property
        {
            get { return _property; }
        }

        public TypeReference PropertyType
        {
            get { return _property.Definition.PropertyType; }
        }

        public SummaryComment Summary
        {
            get { return _property.Summary; }
        }

        public ValueComment Value
        {
            get { return _property.Value; }
        }

        public PropertyViewModel(ApiContext context, DocumentedProperty property, Content parent, string title)
            : base(context, parent, title)
        {
            _property = property;
        }
    }
}
