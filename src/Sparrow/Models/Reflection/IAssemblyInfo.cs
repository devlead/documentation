﻿using System.Collections.Generic;
using Mono.Cecil;

namespace Sparrow.Models.Reflection
{
    /// <summary>
    /// Represents reflected assembly information.
    /// </summary>
    public interface IAssemblyInfo
    {
        /// <summary>
        /// Gets the assembly Identity.
        /// </summary>
        /// <value>The Identity.</value>
        string Identity { get; }

        /// <summary>
        /// Gets the assembly definition.
        /// </summary>
        /// <value>The assembly definition.</value>
        AssemblyDefinition Definition { get; }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <value>The types.</value>
        IReadOnlyList<ITypeInfo> Types { get; }
    }
}
