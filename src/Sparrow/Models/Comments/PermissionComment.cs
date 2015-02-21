﻿using System.Collections.Generic;

namespace Sparrow.Models.Comments
{
    /// <summary>
    /// Represents a <code>permission</code> comment.
    /// </summary>
    public sealed class PermissionComment : AggregateComment
    {
        private readonly string _member;

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <value>The member.</value>
        public string Member
        {
            get { return _member; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionComment"/> class.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="comments">The comments.</param>
        public PermissionComment(string member, IEnumerable<Comment> comments)
            : base(comments)
        {
            _member = member;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <typeparam name="T">The context type.</typeparam>
        /// <param name="visitor">The visitor.</param>
        /// <param name="context">The context.</param>
        public override void Accept<T>(CommentVisitor<T> visitor, T context)
        {
            visitor.VisitPermission(this, context);
        }
    }
}
