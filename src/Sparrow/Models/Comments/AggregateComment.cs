using System.Collections.Generic;

namespace Sparrow.Models.Comments
{
    /// <summary>
    /// Represents an aggregate comment.
    /// </summary>
    public abstract class AggregateComment : Comment
    {
        private readonly List<Comment> _children;

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public IReadOnlyList<Comment> Children
        {
            get { return _children; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateComment"/> class.
        /// </summary>
        /// <param name="comments">The comments.</param>
        protected AggregateComment(IEnumerable<Comment> comments)
        {
            _children = new List<Comment>(comments);
        }
    }
}
