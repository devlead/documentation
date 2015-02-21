using Mono.Cecil;

namespace Sparrow.Models.Reflection
{
    /// <summary>
    /// Represents reflected method information.
    /// </summary>
    public interface IMethodInfo
    {
        /// <summary>
        /// Gets the type Identity.
        /// </summary>
        /// <value>The Identity.</value>
        string Identity { get; }

        /// <summary>
        /// Gets the method Definition.
        /// </summary>
        /// <value>
        /// The method Definition.
        /// </value>
        MethodDefinition Definition { get; }
    }
}
