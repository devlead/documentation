using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.Templating;
using Docs.Compiler.Templating;

namespace Docs.Compiler.Generators.Api
{
    internal abstract class ApiContentBuilder<TModel, TViewModel>
        where TViewModel : TemplateViewModel
    {
        private readonly ApiTemplateEngine _engine;

        protected ApiContentBuilder(ApiTemplateEngine engine)
        {
            _engine = engine;
        }

        protected abstract FilePath GetTemplate(ApiContext context, Content parent, TModel model, TViewModel viewModel);
        protected abstract TViewModel CreateViewModel(ApiContext context, Content parent, TModel model);
        protected abstract string GetContentId(ApiContext context, Content parent, TModel model, TViewModel viewModel);
        protected abstract string GetLink(ApiContext context, Content parent, TModel model, TViewModel viewModel);

        protected virtual string GetTitle(ApiContext context, Content parent, TModel model, TViewModel viewModel)
        {
            return viewModel.Title;
        }

        protected virtual string GetMenuTitle(ApiContext context, Content parent, TModel model, TViewModel viewModel)
        {
            return viewModel.Title;
        }

        protected virtual string GetSubTitle(ApiContext context, Content parent, TModel model, TViewModel viewModel)
        {
            return null;
        }

        public Content Create(CompilerConfiguration configuration, ApiContext context, Content parent, TModel model)
        {
            var viewModel = CreateViewModel(context, parent, model);
            var template = GetTemplate(context, parent, model, viewModel);
            var body = _engine.Render(configuration, template, viewModel);

            return new Content(
                GetContentId(context, parent, model, viewModel),
                GetLink(context, parent, model, viewModel),
                GetTitle(context, parent, model, viewModel),
                GetSubTitle(context, parent, model, viewModel),
                GetMenuTitle(context, parent, model, viewModel),
                body);
        }
    }
}
