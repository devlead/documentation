using Docs.Compiler.Core.Templating;
using Docs.Compiler.Generators.Api;

namespace Docs.Compiler.Text
{
    public sealed class CommentRendererContext
    {
        private readonly ApiContext _apiContext;
        private readonly EncodedStringBuilder _builder;

        public ApiContext ApiContext
        {
            get { return _apiContext; }
        }

        public EncodedStringBuilder Builder
        {
            get { return _builder; }
        }

        public CommentRendererContext(ApiContext apiContext, EncodedStringBuilder builder)
        {
            _apiContext = apiContext;
            _builder = builder;
        }
    }
}
