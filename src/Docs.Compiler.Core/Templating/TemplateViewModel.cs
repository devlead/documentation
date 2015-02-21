namespace Docs.Compiler.Core.Templating
{
    public abstract class TemplateViewModel
    {        
        public Content Parent { get; set; }
        public string Title { get; set; }

        protected TemplateViewModel(Content parent, string title)
        {
            Parent = parent;
            Title = title;
        }
    }
}
