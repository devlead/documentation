using System.Xml;
using Sparrow.Models.Comments;

namespace Sparrow.Xml
{
    /// <summary>
    /// Represents a comment parser.
    /// </summary>
    public interface ICommentParser
    {
        /// <summary>
        /// Parses the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The parsed comment.</returns>
        Comment Parse(XmlNode node);
    }
}
