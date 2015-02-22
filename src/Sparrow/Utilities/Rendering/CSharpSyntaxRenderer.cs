using System.Text;
using Mono.Cecil;
using Sparrow.Reflection;
using Sparrow.Reflection.Signatures;
using Sparrow.Utilities.Language;

namespace Sparrow.Utilities.Rendering
{
    /// <summary>
    /// Implementation of the <see cref="ISyntaxRenderer"/> interface
    /// that renders C# syntax.
    /// </summary>
    public sealed class CSharpSyntaxRenderer : ISyntaxRenderer
    {
        private readonly IDocumentationResolver _resolver;
        private readonly ISignatureRenderer _renderer;
        private readonly ILanguageProvider _language;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpSyntaxRenderer"/> class.
        /// </summary>
        /// <param name="resolver">The resolver.</param>
        /// <param name="renderer">The renderer.</param>
        public CSharpSyntaxRenderer(
            IDocumentationResolver resolver, 
            ISignatureRenderer renderer)
        {
            _resolver = resolver;
            _renderer = renderer;
            _language = new CSharpLanguageProvider();
        }

        /// <summary>
        /// Renders the syntax for a type.
        /// </summary>
        /// <param name="signature">The type signature.</param>
        /// <returns>The rendered syntax.</returns>
        public string Render(TypeSignature signature)
        {
            var builder = new StringBuilder();

            var type = _resolver.FindType(signature.Identity);
            if (type == null)
            {
                throw new SparrowException("Could not find type.");
            }

            if (type.Definition.IsPublic)
            {
                builder.Append("public");
            }

            if (!type.Definition.IsEnum)
            {
                if (type.Definition.IsAbstract && type.Definition.IsSealed)
                {
                    builder.Append(" ");
                    builder.Append("static");
                }
                else
                {
                    if (type.TypeClassification != TypeClassification.Interface)
                    {
                        if (type.Definition.IsAbstract)
                        {
                            builder.Append(" ");
                            builder.Append("abstract");
                        }
                        else if (type.Definition.IsSealed)
                        {
                            builder.Append(" ");
                            builder.Append("sealed");
                        }
                    }
                }
            }

            builder.Append(" ");
            builder.Append(type.TypeClassification.ToString().ToLowerInvariant());

            builder.Append(" ");
            builder.Append(_renderer.Render(_language, type.Definition.GetTypeSignature(null), TypeRenderOption.Name));

            return builder.ToString();
        }

        /// <summary>
        /// Renders the syntax for a method.
        /// </summary>
        /// <param name="signature">The method signature.</param>
        /// <returns>The rendered syntax.</returns>
        /// <exception cref="SparrowException">Could not find method.</exception>
        public string Render(MethodSignature signature)
        {
            var builder = new StringBuilder();

            var method = _resolver.FindMethod(signature.Identity);
            if (method == null)
            {
                throw new SparrowException("Could not find method.");
            }

            if (method.Definition.IsPublic)
            {
                builder.Append("public");
            }
            else if (method.Definition.IsFamily)
            {
                builder.Append("protected");
            }
            else if (method.Definition.IsFamilyOrAssembly)
            {
                builder.Append("protected internal");
            }

            if (method.Definition.IsAbstract)
            {
                builder.Append(" ");
                builder.Append("abstract");
            }

            if (method.Definition.IsStatic)
            {
                builder.Append(" ");
                builder.Append("static");
            }

            if (!method.Definition.IsConstructor)
            {                
                var declaringType = method.Definition.ReturnType.GetTypeSignature(null);
                builder.Append(" ");
                builder.Append(_renderer.Render(_language, declaringType, TypeRenderOption.Name));
            }

            builder.Append(" ");
            builder.Append(signature.Name);

            if (method.Parameters.Count > 0)
            {
                builder.AppendLine("(");

                var index = 0;
                foreach (var parameter in method.Parameters)
                {
                    builder.Append("       ");

                    if (index == 0)
                    {
                        if (method.Definition.IsExtensionMethod())
                        {
                            builder.Append("this ");
                        }
                    }

                    if (parameter.Definition.IsOut)
                    {
                        builder.Append("out ");
                    }
                    else if (parameter.Definition.ParameterType is ByReferenceType)
                    {
                        builder.Append("ref ");
                    }

                    // Append the type name.
                    var parameterTypeSignature = parameter.Definition.ParameterType.GetTypeSignature(null);
                    builder.Append(_renderer.Render(_language, parameterTypeSignature, TypeRenderOption.Name));
                    builder.Append(" ");

                    var parameterName = parameter.Name;
                    if (index == method.Parameters.Count - 1)
                    {
                        builder.AppendLine(parameterName);
                    }
                    else
                    {
                        builder.Append(parameterName);
                        builder.AppendLine(",");
                    }

                    index++;
                }
                builder.AppendLine(")");
            }
            else
            {
                builder.Append("()");
            }

            return builder.ToString();
        }
    }
}
