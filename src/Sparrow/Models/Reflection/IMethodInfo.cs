﻿using Mono.Cecil;

namespace Sparrow.Models.Reflection
{
    /// <summary>
    /// Represents reflected method information.
    /// </summary>
    public interface IMethodInfo
    {
        /// <summary>
        /// Gets the method identity.
        /// </summary>
        /// <value>The method identity.</value>
        string Identity { get; }

        /// <summary>
        /// Gets the method definition.
        /// </summary>
        /// <value>
        /// The method definition.
        /// </value>
        MethodDefinition Definition { get; }
    }
}
