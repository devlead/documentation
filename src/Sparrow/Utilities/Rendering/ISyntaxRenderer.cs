using Sparrow.Reflection.Signatures;

namespace Sparrow.Utilities.Rendering
{
    /// <summary>
    /// Represents a syntax renderer.
    /// </summary>
    public interface ISyntaxRenderer
    {
        /// <summary>
        /// Renders the syntax for a type.
        /// </summary>
        /// <param name="signature">The type signature.</param>
        /// <returns>The rendered syntax.</returns>
        string Render(TypeSignature signature);

        /// <summary>
        /// Renders the syntax for a method.
        /// </summary>
        /// <param name="signature">The method signature.</param>
        /// <returns>The rendered syntax.</returns>
        string Render(MethodSignature signature);
    }
}
