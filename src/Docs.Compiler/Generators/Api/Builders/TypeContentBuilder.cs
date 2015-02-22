using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Sparrow.Models.Documentation;
using Sparrow.Reflection;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class TypeContentBuilder : ApiContentBuilder<DocumentedType, TypeViewModel>
    {
        public TypeContentBuilder(ApiTemplateEngine engine) 
            : base(engine)
        {
        }

        protected override FilePath GetTemplate(ApiContext context, Content parent, DocumentedType model, TypeViewModel viewModel)
        {
            if (model.Definition.IsEnum)
            {
                return "templates/api/enum.cshtml";    
            }
            return "templates/api/type.cshtml";
        }

        protected override TypeViewModel CreateViewModel(ApiContext context, Content parent, DocumentedType model)
        {
            var signature = model.Definition.GetTypeSignature(context.UrlResolver);
            var title = context.SignatureRenderer.Render(context.Language, signature, TypeRenderOption.Name);

            return new TypeViewModel(context, model, parent, title);
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentedType model, TypeViewModel viewModel)
        {
            return model.Identity;
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentedType model, TypeViewModel viewModel)
        {
            return context.UrlResolver.GetLinkPart(model);
        }

        protected override string GetSubTitle(ApiContext context, Content parent, DocumentedType model, TypeViewModel viewModel)
        {
            return model.TypeClassification.ToString();
        }
    }
}
