using Docs.Compiler.Core;
using Docs.Compiler.Core.Templating;

namespace Docs.Compiler.ViewModels
{
    public sealed class LayoutViewModel : TemplateViewModel
    {
        public string CurrentId { get; set; }
        public Content Current { get; set; }
        public Content Root { get; set; }

        public LayoutViewModel(Content parent, string title)
            : base(parent, title)
        {
        }
    }
}
