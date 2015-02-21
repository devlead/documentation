using Sparrow.Models.Documentation;
using Sparrow.Reflection.Signatures;
using Sparrow.Utilities;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Text
{
    internal sealed class SignatureRenderer : ISignatureRenderer
    {
        private readonly TypeRenderer _typeRenderer;
        private readonly MethodRenderer _methodRenderer;

        public SignatureRenderer(DocumentModel model)
        {
            _typeRenderer = new TypeRenderer(model);
            _methodRenderer = new MethodRenderer(_typeRenderer);
        }

        public string Render(ILanguageProvider language, TypeSignature signature, TypeRenderOption options)
        {
            return _typeRenderer.Render(language, signature, options);
        }

        public string Render(ILanguageProvider language, MethodSignature signature, MethodRenderOption options)
        {
            return _methodRenderer.Render(language, signature, options);
        }
    }
}
