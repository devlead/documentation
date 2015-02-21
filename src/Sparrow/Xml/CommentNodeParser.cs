using System.Xml;
using Sparrow.Models.Comments;

namespace Sparrow.Xml
{
    /// <summary>
    /// Represents a <see cref="XmlNode" /> parser.
    /// </summary>
    /// <typeparam name="T">The comment type.</typeparam>
    public abstract class CommentNodeParser<T> : ICommentNodeParser
        where T : Comment
    {
        /// <summary>
        /// Determines whether this instance can parse the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if this instance can parse the specified node; otherwise <c>false</c>.</returns>
        public abstract bool CanParse(XmlNode node);

        /// <summary>
        /// Parses the specified <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="node">The node.</param>
        /// <returns>The parsed comment.</returns>
        public abstract T Parse(ICommentParser parser, XmlNode node);

        /// <summary>
        /// Parses the specified <see cref="XmlNode" />.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="node">The node.</param>
        /// <returns>The parsed comment.</returns>
        Comment ICommentNodeParser.Parse(ICommentParser parser, XmlNode node)
        {
            return Parse(parser, node);
        }
    }
}
