namespace Sparrow.Models.Comments
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    public abstract class Comment
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="T">The context type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <param name="context">The context.</param>
        public abstract void Accept<T>(CommentVisitor<T> visitor, T context);
    }
}