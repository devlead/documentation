using Docs.Compiler.Text;
using Sparrow.Models.Documentation;
using Sparrow.Utilities;
using Sparrow.Utilities.Language;
using Sparrow.Utilities.Rendering;
using Sparrow.Utilities.Resolvers;

namespace Docs.Compiler.Generators.Api
{
    public sealed class ApiContext
    {
        private readonly DocumentModel _documentModel;        
        private readonly ApiUrlResolver _urlResolver;
        private readonly CommentRenderer _commentCommentRenderer;

        private readonly ISignatureRenderer _signatureSignatureRenderer;
        private readonly ISyntaxRenderer _syntaxRenderer;
        private readonly IDocumentationResolver _resolver;
        private readonly ILanguageProvider _language;

        public DocumentModel DocumentModel
        {
            get { return _documentModel; }
        }

        public ApiUrlResolver UrlResolver
        {
            get { return _urlResolver; }
        }

        public CommentRenderer CommentRenderer
        {
            get { return _commentCommentRenderer; }
        }

        public ISyntaxRenderer SyntaxRenderer
        {
            get { return _syntaxRenderer; }
        }

        public ISignatureRenderer SignatureRenderer
        {
            get { return _signatureSignatureRenderer; }
        }

        public IDocumentationResolver Resolver
        {
            get { return _resolver; }
        }

        public ILanguageProvider Language
        {
            get { return _language; }
        }

        public ApiContext(DocumentModel documentModel, CommentRenderer commentCommentRenderer, 
            ApiUrlResolver urlResolver)
        {
            _documentModel = documentModel;
            _commentCommentRenderer = commentCommentRenderer;
            _urlResolver = urlResolver;
            _resolver = new DefaultDocumentationResolver(_documentModel);

            _signatureSignatureRenderer = new SignatureRenderer(_documentModel);
            
            _syntaxRenderer = new CSharpSyntaxRenderer(
                new DefaultDocumentationResolver(_documentModel),
                new SignatureRenderer(_documentModel));

            _language = new CSharpLanguageProvider();
        }
    }
}
