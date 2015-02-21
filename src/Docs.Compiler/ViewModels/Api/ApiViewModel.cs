using Docs.Compiler.Core;
using Docs.Compiler.Core.Templating;
using Docs.Compiler.Generators.Api;

namespace Docs.Compiler.ViewModels.Api
{
    public abstract class ApiViewModel : TemplateViewModel
    {
        private readonly ApiContext _context;

        protected ApiViewModel(ApiContext context, Content parent, string title)
            : base(parent, title)
        {
            _context = context;
        }

        public ApiContext Context
        {
            get { return _context; }
        }
    }
}
