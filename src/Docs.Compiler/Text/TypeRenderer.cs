using System.Collections.Generic;
using Docs.Compiler.Core.Templating;
using Sparrow.Models.Documentation;
using Sparrow.Reflection.Signatures;
using Sparrow.Utilities;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Text
{
    internal sealed class TypeRenderer
    {
        private readonly DocumentModel _model;

        public TypeRenderer(DocumentModel model)
        {
            _model = model;
        }

        public string Render(
            ILanguageProvider language, 
            TypeSignature signature, 
            TypeRenderOption options)
        {
            var builder = new EncodedStringBuilder();
            Render(builder, language, signature, options, false);
            return builder.ToString();
        }

        private void Render(
            EncodedStringBuilder builder,
            ILanguageProvider language,
            TypeSignature signature,
            TypeRenderOption options,
            bool isWritingLink)
        {
            var needToCloseLink = false;
            var documentedType = _model.FindType(signature.Identity);

            // Writing link?
            if ((options & TypeRenderOption.Link) == TypeRenderOption.Link)
            {
                if (!isWritingLink && documentedType != null)
                {
                    if (signature.Url != null)
                    {
                        isWritingLink = needToCloseLink = true;
                        builder.AppendRaw("<a href=\"{0}\">", signature.Url);
                    }
                }
            }

            // Write type namespace?
            if ((options & TypeRenderOption.Namespace) == TypeRenderOption.Namespace)
            {
                builder.AppendEncoded(signature.Namespace.Name);

                if ((options & TypeRenderOption.Namespace) == TypeRenderOption.Namespace)
                {
                    builder.AppendEncoded(".");
                }
            }

            // Write type name?
            if ((options & TypeRenderOption.Name) == TypeRenderOption.Name)
            {
                var alias = language.GetAlias(signature.Identity);
                var name = alias ?? signature.Name;
                builder.AppendEncoded(name);
            }

            if (signature.GenericArguments.Count != 0)
            {
                // Write generic arguments.
                builder.AppendEncoded("<");
                var result = new List<string>();
                foreach (var argument in signature.GenericArguments)
                {
                    result.Add(argument);
                }
                builder.AppendEncoded(string.Join(", ", result));
                builder.AppendEncoded(">");
            }
            else if (signature.GenericParameters.Count != 0)
            {
                // Write generic parameters.
                builder.AppendEncoded("<");
                var result = new List<string>();
                foreach (var parameter in signature.GenericParameters)
                {
                    Render(builder, language, parameter, options, isWritingLink);
                }
                builder.AppendEncoded(string.Join(", ", result));
                builder.AppendEncoded(">");
            }

            // Writing link?
            if ((options & TypeRenderOption.Link) == TypeRenderOption.Link)
            {
                if (needToCloseLink)
                {
                    builder.AppendRaw("</a>");
                }
            }
        }

    }
}
