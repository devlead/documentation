using RazorEngine.Text;
using Sparrow.Models.Documentation;
using Sparrow.Utilities.Rendering;

// ReSharper disable once CheckNamespace
namespace Docs.Compiler.Templating
{
    public partial class DocumentationHelper
    {
        public IEncodedString Syntax(DocumentedMethod method)
        {
            return new RawString(_context.SyntaxRenderer.Render(method));
        }

        public IEncodedString Syntax(DocumentedType type)
        {
            return new RawString(_context.SyntaxRenderer.Render(type));
        }
    }
}
