using Docs.Compiler.Core.Templating;
using Mono.Cecil;
using RazorEngine.Text;
using Sparrow.Models.Documentation;
using Sparrow.Reflection;
using Sparrow.Utilities.Rendering;

// ReSharper disable once CheckNamespace
namespace Docs.Compiler.Templating
{
    public partial class DocumentationHelper
    {
        public IEncodedString Link(DocumentedNamespace @namespace)
        {
            var builder = new EncodedStringBuilder();
            var url = _context.UrlResolver.GetUrl(@namespace.Identity);
            builder.AppendRaw(@"<a href=""{0}"">", url);
            builder.AppendEncoded(@namespace.Identity);
            builder.AppendRaw("</a>");
            return builder.ToRaw();
        }

        public IEncodedString Link(DocumentedType type)
        {
            return Link(type.Definition);
        }

        public IEncodedString Link(TypeReference type)
        {
            return new RawString(_context.SignatureRenderer.Render(
                _context.Language,
                type.GetTypeSignature(_context.UrlResolver),
                TypeRenderOption.Link | TypeRenderOption.Name));
        }

        public IEncodedString Link(DocumentedMethod method)
        {
            return Link(method.Definition);
        }

        public IEncodedString Link(MethodReference method)
        {
            return new RawString(_context.SignatureRenderer.Render(
                _context.Language,
                method.GetMethodSignature(_context.UrlResolver),
                MethodRenderOption.Link | MethodRenderOption.Name | MethodRenderOption.Parameters));
        }

        public IEncodedString Link(DocumentedProperty property)
        {
            return Link(property.Definition);
        }

        public IEncodedString Link(PropertyReference property)
        {
            var signature = property.GetPropertySignature(_context.UrlResolver);
            var builder = new EncodedStringBuilder();
            builder.AppendRaw(@"<a href=""{0}"">", _context.UrlResolver.GetUrl(signature.Identity));
            builder.AppendEncoded(signature.Name);
            builder.AppendRaw("</a>");
            return builder.ForceRaw();
        }
    }
}
