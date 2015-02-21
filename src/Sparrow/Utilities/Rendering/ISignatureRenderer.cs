using Sparrow.Reflection.Signatures;

namespace Sparrow.Utilities.Rendering
{
    /// <summary>
    /// Represents a signature renderer.
    /// </summary>
    public interface ISignatureRenderer
    {
        /// <summary>
        /// Renders the specified type signature.
        /// </summary>
        /// <param name="language">The language to use.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="options">The options.</param>
        /// <returns>The rendering result.</returns>
        string Render(ILanguageProvider language, TypeSignature signature, TypeRenderOption options);

        /// <summary>
        /// Renders the specified method signature.
        /// </summary>
        /// <param name="language">The language to use.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="options">The options.</param>
        /// <returns>The rendering result.</returns>
        string Render(ILanguageProvider language, MethodSignature signature, MethodRenderOption options);
    }
}
