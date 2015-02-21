using System;

namespace Sparrow.Utilities.Rendering
{
    /// <summary>
    /// Represent options for rendering methods.
    /// </summary>
    [Flags]
    public enum MethodRenderOption
    {
        /// <summary>
        /// Render nothing.
        /// </summary>
        None = 1 << 0,

        /// <summary>
        /// Render link.
        /// </summary>
        Link = 1 << 1,

        /// <summary>
        /// Render method name.
        /// </summary>
        Name = 1 << 2,

        /// <summary>
        /// Render parameters.
        /// </summary>
        Parameters = 1 << 3,

        /// <summary>
        /// Render return type.
        /// </summary>
        ReturnType = 1 << 4,

        /// <summary>
        /// Render namespace.
        /// </summary>
        Namespace = 1 << 5,

        /// <summary>
        /// The default rendering options.
        /// </summary>
        Default = Name | Parameters
    }
}