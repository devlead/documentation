using System;
using Docs.Compiler.Core.Templating;
using Docs.Compiler.ViewModels.Api;

namespace Docs.Compiler.Templating
{
    public abstract class ApiTemplate<T> : Template<T>
        where T : TemplateViewModel
    {
        public override void SetModel(object model)
        {
            var viewModel = model as ApiViewModel;
            if (viewModel == null)
            {
                throw new InvalidOperationException("Not an API view model.");
            }
            Documentation = new DocumentationHelper(viewModel.Context);
            base.SetModel(model);
        }

        public DocumentationHelper Documentation { get; private set; }
    }
}