using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Sparrow.Models.Documentation;
using Sparrow.Reflection;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class MethodContentBuilder : ApiContentBuilder<DocumentedMethod, MethodViewModel>
    {
        public MethodContentBuilder(ApiTemplateEngine engine) 
            : base(engine)
        {
        }

        protected override FilePath GetTemplate(ApiContext context, Content parent, DocumentedMethod model, MethodViewModel viewModel)
        {
            return "templates/api/method.cshtml";
        }

        protected override MethodViewModel CreateViewModel(ApiContext context, Content parent, DocumentedMethod model)
        {
            var signature = model.Definition.GetMethodSignature(context.UrlResolver);
            var title = context.SignatureRenderer.Render(context.Language, signature, MethodRenderOption.Default);

            return new MethodViewModel(context, model, parent, title);
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentedMethod model, MethodViewModel viewModel)
        {
            return model.Identity;
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentedMethod model, MethodViewModel viewModel)
        {
            return context.UrlResolver.GetLinkPart(model);
        }

        protected override string GetSubTitle(ApiContext context, Content parent, DocumentedMethod model, MethodViewModel viewModel)
        {
            return model.GetClassification();
        }
    }
}
