using Sparrow.Models.Documentation;

namespace Sparrow.Utilities
{
    /// <summary>
    /// Represents a document resolver.
    /// </summary>
    public interface IDocumentationResolver
    {
        /// <summary>
        /// Finds a type by it's cref.
        /// </summary>
        /// <param name="cref">The cref.</param>
        /// <returns>The documented type, or <c>null</c> if not found.</returns>
        DocumentedType FindType(string cref);

        /// <summary>
        /// Finds a method by it's cref.
        /// </summary>
        /// <param name="cref">The cref.</param>
        /// <returns>The documented method, or <c>null</c> if not found.</returns>
        DocumentedMethod FindMethod(string cref);
    }
}
