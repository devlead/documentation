using System;
using RazorEngine.Templating;

namespace Docs.Compiler.Core.Templating
{
    public abstract class Template<T> : TemplateBase<T>
        where T : TemplateViewModel
    {
        public override void SetModel(object model)
        {
            var viewModel = model as TemplateViewModel;
            if (viewModel == null)
            {
                throw new InvalidOperationException("Not a proper view model.");
            }
            Content = new TemplateHelper(viewModel);
            base.SetModel(model);
        }

        public TemplateHelper Content { get; private set; }
    }
}