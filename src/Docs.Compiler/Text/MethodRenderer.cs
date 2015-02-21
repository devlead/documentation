using System.Collections.Generic;
using System.Text;
using Sparrow.Reflection.Signatures;
using Sparrow.Utilities;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Text
{
    internal sealed class MethodRenderer
    {
        private readonly TypeRenderer _renderer;

        public MethodRenderer(TypeRenderer renderer)
        {
            _renderer = renderer;
        }

        public string Render(
            ILanguageProvider language, 
            MethodSignature signature, 
            MethodRenderOption options)
        {
            var builder = new StringBuilder();

            // Add link.
            if ((options & MethodRenderOption.Link) == MethodRenderOption.Link)
            {
                builder.AppendFormat(@"<a href=""{0}"">", signature.Url);
            }

            if ((options & MethodRenderOption.Name) == MethodRenderOption.Name)
            {
                builder.Append(signature.Name);
            }

            if ((options & MethodRenderOption.Parameters) == MethodRenderOption.Parameters)
            {
                builder.Append("(");
                var parameterResult = new List<string>();
                foreach (var parameter in signature.Parameters)
                {
                    var parameterBuilder = new StringBuilder();
                    if (parameter.IsOutParameter)
                    {
                        parameterBuilder.Append("out ");
                    }
                    else if (parameter.IsRefParameter)
                    {
                        parameterBuilder.Append("ref ");
                    }

                    var paramType = _renderer.Render(language, parameter.ParameterType, TypeRenderOption.Name);
                    parameterBuilder.Append(paramType);
                    parameterResult.Add(parameterBuilder.ToString());
                }
                if (parameterResult.Count > 0)
                {
                    builder.Append(string.Join(", ", parameterResult));
                }
                builder.Append(")");
            }

            if ((options & MethodRenderOption.Link) == MethodRenderOption.Link)
            {
                builder.Append(@"</a>");
            }

            return builder.ToString();
        }
    }
}
