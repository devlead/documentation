using System.Collections.Generic;
using System.Xml;
using Sparrow.Models.Comments;

namespace Sparrow.Xml.Parsers
{
    /// <summary>
    /// Base class for parsing child nodes.
    /// </summary>
    /// <typeparam name="T">The comment type.</typeparam>
    public abstract class AggregateParser<T> : CommentNodeParser<T>
        where T : AggregateComment
    {
        /// <summary>
        /// Parses child nodes of the specified <see cref="XmlNode"/>.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="node">The node.</param>
        /// <returns>The parsed comments.</returns>
        protected IEnumerable<Comment> ParseChildren(ICommentParser parser, XmlNode node)
        {
            var children = new List<Comment>();
            foreach (XmlNode child in node.ChildNodes)
            {
                children.Add(parser.Parse(child));
            }
            return children;
        }
    }
}
