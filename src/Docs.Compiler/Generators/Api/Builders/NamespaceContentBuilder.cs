using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class NamespaceContentBuilder : ApiContentBuilder<DocumentedNamespace, NamespaceViewModel>
    {
        public NamespaceContentBuilder(ApiTemplateEngine engine)
            : base(engine)
        {
        }

        protected override FilePath GetTemplate(ApiContext context, Content parent, DocumentedNamespace model, NamespaceViewModel viewModel)
        {
            return "templates/api/namespace.cshtml";
        }

        protected override NamespaceViewModel CreateViewModel(ApiContext context, Content parent, DocumentedNamespace model)
        {
            return new NamespaceViewModel(context, model, parent, model.Identity);
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentedNamespace model, NamespaceViewModel viewModel)
        {
            return model.Identity;
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentedNamespace model, NamespaceViewModel viewModel)
        {
            return context.UrlResolver.GetLinkPart(model);
        }

        protected override string GetSubTitle(ApiContext context, Content parent, DocumentedNamespace model, NamespaceViewModel viewModel)
        {
            return "Namespace";
        }
    }
}