using Mono.Cecil;

namespace Sparrow.Models.Reflection
{
    /// <summary>
    /// Represents reflected property information.
    /// </summary>
    public interface IPropertyInfo
    {
        /// <summary>
        /// Gets the Identity.
        /// </summary>
        /// <value>
        /// The Identity.
        /// </value>
        string Identity { get; }

        /// <summary>
        /// Gets the definition.
        /// </summary>
        /// <value>
        /// The definition.
        /// </value>
        PropertyDefinition Definition { get; }
    }
}