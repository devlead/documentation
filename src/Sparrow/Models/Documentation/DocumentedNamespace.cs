using System.Collections.Generic;
using System.Diagnostics;
using Sparrow.Models.Comments;
using Sparrow.Reflection;

namespace Sparrow.Models.Documentation
{
    /// <summary>
    /// Represents a documented namespace.
    /// </summary>
    [DebuggerDisplay("{Identity,nq}")]
    public sealed class DocumentedNamespace : DocumentedMember
    {
        private readonly string _identity;
        private readonly List<DocumentedType> _types;

        /// <summary>
        /// Gets the identity.
        /// </summary>
        /// <value>The identity.</value>
        public string Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Gets the assembly this namespace is located in.
        /// </summary>
        /// <value>The assembly this namespace is located in.</value>
        public DocumentedAssembly Assembly { get; internal set; }

        /// <summary>
        /// Gets the types in this namespace.
        /// </summary>
        /// <value>The types in this namespace.</value>
        public IReadOnlyList<DocumentedType> Types
        {
            get { return _types; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentedNamespace"/> class.
        /// </summary>
        /// <param name="identity">The Identity.</param>
        /// <param name="types">The types.</param>
        /// <param name="summaryComment">The summary comment.</param>
        public DocumentedNamespace(
            string identity, 
            IEnumerable<DocumentedType> types,
            SummaryComment summaryComment)
            : base(MemberClassification.Namespace, summaryComment, null, null)
        {
            _identity = identity;
            _types = new List<DocumentedType>(types);
        }
    }
}