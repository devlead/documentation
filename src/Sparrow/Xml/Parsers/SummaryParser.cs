﻿using System.Xml;
using Sparrow.Models.Comments;

namespace Sparrow.Xml.Parsers
{
    /// <summary>
    /// Responsible for parsing <code>summary</code> comments.
    /// </summary>
    public sealed class SummaryParser : AggregateParser<SummaryComment>
    {
        /// <summary>
        /// Determines whether this instance can parse the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        ///   <c>true</c> if this instance can parse the specified node; otherwise <c>false</c>.
        /// </returns>
        public override bool CanParse(XmlNode node)
        {
            return node.Name == "summary";
        }

        /// <summary>
        /// Parses the specified <see cref="XmlNode" />.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="node">The node.</param>
        /// <returns>
        /// The parsed comment.
        /// </returns>
        public override SummaryComment Parse(ICommentParser parser, XmlNode node)
        {
            return new SummaryComment(ParseChildren(parser, node));
        }
    }
}
