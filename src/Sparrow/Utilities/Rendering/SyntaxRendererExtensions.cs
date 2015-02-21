using Sparrow.Models.Documentation;
using Sparrow.Reflection;

namespace Sparrow.Utilities.Rendering
{
    /// <summary>
    /// Contains extension methods for <see cref="ISyntaxRenderer"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class SyntaxRendererExtensions
    {
        /// <summary>
        /// Renders the syntax for a method.
        /// </summary>
        /// <param name="renderer">The syntax renderer to use.</param>
        /// <param name="method">The method.</param>
        /// <returns>The rendered syntax.</returns>
        public static string Render(this ISyntaxRenderer renderer, DocumentedMethod method)
        {
            return renderer.Render(method.Definition.GetMethodSignature(null));
        }

        /// <summary>
        /// Renders the syntax for a type.
        /// </summary>
        /// <param name="renderer">The syntax renderer to use.</param>
        /// <param name="type">The type.</param>
        /// <returns>The rendered syntax.</returns>
        public static string Render(this ISyntaxRenderer renderer, DocumentedType type)
        {
            return renderer.Render(type.Definition.GetTypeSignature(null));
        }
    }
}
