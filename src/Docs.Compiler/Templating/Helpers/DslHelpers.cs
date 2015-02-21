using System;
using RazorEngine.Text;
using Sparrow.Models.Documentation;
using Sparrow.Reflection;
using Sparrow.Utilities.Rendering;

// ReSharper disable once CheckNamespace
namespace Docs.Compiler.Templating
{
    public partial class DocumentationHelper
    {
        public IEncodedString DslLink(DocumentedMethod method)
        {
            var content = _context.SignatureRenderer.Render(
                _context.Language,
                method.Definition.GetMethodSignature(_context.UrlResolver),
                MethodRenderOption.Name |
                MethodRenderOption.Parameters |
                MethodRenderOption.Link);

            content = content.Replace("(ICakeContext, ", "(");
            content = content.Replace("(ICakeContext)", string.Empty);
            return new RawString(content);
        }

        public IEncodedString DslType(DocumentedMethod method)
        {
            bool isPropertyAlias;
            if (method.IsCakeAlias(out isPropertyAlias))
            {
                return isPropertyAlias
                    ? new HtmlEncodedString("Property")
                    : new HtmlEncodedString("Method");
            }
            throw new InvalidOperationException("Unknown DSL alias type.");
        }
    }
}
