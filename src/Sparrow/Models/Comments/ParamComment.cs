﻿using System.Collections.Generic;

namespace Sparrow.Models.Comments
{
    /// <summary>
    /// Represents a <code>param</code> comment.
    /// </summary>
    public sealed class ParamComment : AggregateComment
    {
        private readonly string _name;

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamComment"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="comments">The comments.</param>
        public ParamComment(string name, IEnumerable<Comment> comments) 
            : base(comments)
        {
            _name = name;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="T">The context type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <param name="context">The context.</param>
        public override void Accept<T>(CommentVisitor<T> visitor, T context)
        {
            visitor.VisitParam(this, context);
        }
    }
}
