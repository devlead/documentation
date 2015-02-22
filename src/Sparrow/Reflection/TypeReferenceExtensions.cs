using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Sparrow.Identity;
using Sparrow.Reflection.Signatures;
using Sparrow.Utilities;

namespace Sparrow.Reflection
{
    /// <summary>
    /// Contains extension methods for <see cref="TypeDefinition"/>.
    /// </summary>
    public static class TypeReferenceExtensions
    {
        /// <summary>
        /// Gets a type description for the specified type.
        /// </summary>
        /// <param name="type">The type reference.</param>
        /// <param name="resolver">The link resolver.</param>
        /// <returns>A type description for the specified type.</returns>
        public static TypeSignature GetTypeSignature(this TypeReference type, IUrlResolver resolver)
        {
            // Get the namespace of the type.
            var ns = new NamespaceSignature(type.Namespace);

            // Get the identity.
            var identity = CRefGenerator.GetTypeCRef(type);

            // Get the type name.
            var name = type.Name;
            var index = name.IndexOf('`');
            if (index != -1)
            {
                name = name.Substring(0, index);
            }

            if (name.EndsWith("&"))
            {
                name = name.TrimEnd('&');
            }

            // Get generic parameters and arguments.
            var genericParameters = new List<string>();
            var genericArguments = new List<TypeSignature>();
            if (type.IsGenericInstance)
            {
                // Generic arguments
                var genericInstanceType = type as GenericInstanceType;
                if (genericInstanceType != null)
                {
                    genericArguments.AddRange(
                        genericInstanceType.GenericArguments.Select(
                        reference => GetTypeSignature(reference, resolver)));
                }
            }
            else if (type.HasGenericParameters)
            {
                // Generic parameters
                genericParameters.AddRange(
                    type.GenericParameters.Select(
                        genericParameter => genericParameter.Name));
            }

            // Return the type description.
            var url = resolver == null ? null : resolver.GetUrl(identity);
            return new TypeSignature(identity, name, url, ns, genericParameters, genericArguments);
        }

        /// <summary>
        /// Gets the type classification for this type reference.
        /// </summary>
        /// <param name="type">The type reference.</param>
        /// <returns>The type classification for this type reference.</returns>
        public static TypeClassification GetTypeClassification(this TypeDefinition type)
        {
            if (type.IsEnum)
            {
                return TypeClassification.Enum;
            }
            if (type.IsInterface)
            {
                return TypeClassification.Interface;
            }
            if (type.IsValueType)
            {
                return TypeClassification.Struct;
            }
            if (type.IsClass)
            {
                return TypeClassification.Class;
            }
            return TypeClassification.Unknown;
        }
    }
}
