using System.Collections.Generic;

namespace Sparrow.Models.Comments
{
    /// <summary>
    /// Represents a <code>returns</code> comment.
    /// </summary>
    public sealed class ReturnsComment : AggregateComment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnsComment"/> class.
        /// </summary>
        /// <param name="comments">The comments.</param>
        public ReturnsComment(IEnumerable<Comment> comments) 
            : base(comments)
        {
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="T">The context type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <param name="context">The context.</param>
        public override void Accept<T>(CommentVisitor<T> visitor, T context)
        {
            visitor.VisitReturns(this, context);
        }
    }
}
