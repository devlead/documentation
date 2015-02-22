using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class PropertyContentBuilder : ApiContentBuilder<DocumentedProperty, PropertyViewModel>
    {
        public PropertyContentBuilder(ApiTemplateEngine engine) 
            : base(engine)
        {
        }

        protected override FilePath GetTemplate(ApiContext context, Content parent, DocumentedProperty model, PropertyViewModel viewModel)
        {
            return "templates/api/property.cshtml";
        }

        protected override PropertyViewModel CreateViewModel(ApiContext context, Content parent, DocumentedProperty model)
        {
            var title = model.Definition.Name;
            return new PropertyViewModel(context, model, parent, title);
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentedProperty model, PropertyViewModel viewModel)
        {
            return model.Identity;
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentedProperty model, PropertyViewModel viewModel)
        {
            return context.UrlResolver.GetLinkPart(model);
        }

        protected override string GetSubTitle(ApiContext context, Content parent, DocumentedProperty model, PropertyViewModel viewModel)
        {
            return model.GetClassification();
        }
    }
}
