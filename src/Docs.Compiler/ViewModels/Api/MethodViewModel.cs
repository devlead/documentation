using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Sparrow.Models.Comments;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public class MethodViewModel : ApiViewModel
    {
        private readonly DocumentedMethod _method;

        public DocumentedMethod Method
        {
            get { return _method; }
        }

        public SummaryComment Summary
        {
            get { return _method.Summary; }
        }

        public ExampleComment Example
        {
            get { return _method.Example; }
        }

        public MethodViewModel(ApiContext context, DocumentedMethod method, Content parent, string title)
            : base(context, parent, title)
        {
            _method = method;
        }
    }
}
