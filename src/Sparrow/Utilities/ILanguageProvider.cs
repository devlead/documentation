namespace Sparrow.Utilities
{
    /// <summary>
    /// Represents a language provider.
    /// </summary>
    public interface ILanguageProvider
    {
        /// <summary>
        /// Gets the alias for a cref.
        /// </summary>
        /// <param name="cref">The cref.</param>
        /// <returns>An alias.</returns>
        string GetAlias(string cref);
    }
}
