using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sparrow.Reflection;

namespace Sparrow.Models.Documentation
{
    /// <summary>
    /// Contains extension methods for <see cref="DocumentModel"/>.
    /// </summary>
    public static class DocumentModelExtensions
    {
        /// <summary>
        /// Finds the specified documented type.
        /// </summary>
        /// <param name="model">The document model.</param>
        /// <param name="identity">The Identity of the documented type.</param>
        /// <returns>The documented type.</returns>
        public static DocumentedType FindType(this DocumentModel model, string identity)
        {
            foreach (var assembly in model.Assemblies)
            {
                foreach (var @namespace in assembly.Namespaces)
                {
                    foreach (var type in @namespace.Types)
                    {
                        if (type.Identity == identity)
                        {
                            return type;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets all extension methods in the document model.
        /// </summary>
        /// <param name="model">The document model.</param>
        /// <returns>All extension methods in the document model.</returns>
        public static IEnumerable<DocumentedMethod> GetExtensionMethods(this DocumentModel model)
        {
            foreach (var method in model.Assemblies
                .SelectMany(assembly => assembly.Namespaces)
                .SelectMany(ns => ns.Types)
                .SelectMany(type => type.Methods))
            {
                if (method.MethodClassification == MethodClassification.ExtensionMethod)
                {
                    yield return method;
                }
            }
        }

        /// <summary>
        /// Finds all extension methods for a specific type.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="source">The source.</param>
        /// <returns>A sequence of <see cref="DocumentedMethod"/> instances.</returns>
        public static IEnumerable<DocumentedMethod> FindExtensionMethods(this DocumentModel model, DocumentedType source)
        {
            var methods = GetExtensionMethods(model).ToList();
            foreach (var method in methods)
            {
                Debug.Assert(method.Parameters.Count > 0, "No extension method can have zero parameters.");

                if (method.Parameters[0].Definition.ParameterType.MetadataToken == source.Definition.MetadataToken)
                {
                    yield return method;
                }
            }           
        }
    }
}
