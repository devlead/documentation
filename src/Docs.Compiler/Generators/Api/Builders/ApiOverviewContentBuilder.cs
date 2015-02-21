using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class ApiOverviewContentBuilder : ApiContentBuilder<DocumentModel, ApiOverviewViewModel>
    {
        public ApiOverviewContentBuilder(ApiTemplateEngine engine) 
            : base(engine)
        {
        }

        protected override FilePath GetTemplate()
        {
            return "templates/api/overview.cshtml";
        }

        protected override ApiOverviewViewModel CreateViewModel(ApiContext context, Content parent, DocumentModel model)
        {
            return new ApiOverviewViewModel(context, parent, "API reference");
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentModel model, ApiOverviewViewModel viewModel)
        {
            return "api-reference";
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentModel model, ApiOverviewViewModel viewModel)
        {
            return "api";
        }
    }
}
