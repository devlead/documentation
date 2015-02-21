﻿using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using Sparrow.Models.Reflection;
using Sparrow.Reflection;

namespace Sparrow.Models.Documentation
{
    /// <summary>
    /// Represents a documented assembly.
    /// </summary>
    [DebuggerDisplay("{Identity,nq}")]
    public sealed class DocumentedAssembly : DocumentedMember
    {        
        private readonly AssemblyDefinition _definition;
        private readonly string _identity;
        private readonly List<DocumentedNamespace> _namespaces;

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public string Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Gets the document model.
        /// </summary>
        /// <value>The document model.</value>
        public DocumentModel Model { get; internal set; }

        /// <summary>
        /// Gets the assembly definition.
        /// </summary>
        /// <value>The assembly definition.</value>
        public AssemblyDefinition Definition
        {
            get { return _definition; }
        }

        /// <summary>
        /// Gets the types in this namespace.
        /// </summary>
        /// <value>The types in this namespace.</value>
        public IReadOnlyList<DocumentedNamespace> Namespaces
        {
            get { return _namespaces; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentedAssembly"/> class.
        /// </summary>
        /// <param name="info">The assembly information.</param>
        /// <param name="namespaces">The namespaces.</param>
        public DocumentedAssembly(IAssemblyInfo info, IEnumerable<DocumentedNamespace> namespaces)
            : base(MemberClassification.Assembly,  null, null, null)
        {
            _definition = info.Definition;
            _identity = info.Identity;
            _namespaces = new List<DocumentedNamespace>(namespaces);
        }
    }
}
