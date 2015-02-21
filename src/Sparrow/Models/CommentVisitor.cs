using Sparrow.Models.Comments;

namespace Sparrow.Models
{
    /// <summary>
    /// Represents an abstract comment visitor.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public abstract class CommentVisitor<TContext>
    {
        /// <summary>
        /// Visits a <c>code</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitCode(CodeComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>example</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitExample(ExampleComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>exception</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitException(ExceptionComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>inlinecode</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitInlineCode(InlineCodeComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>inlinetext</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitInlineText(InlineTextComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>param</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitParam(ParamComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>paramref</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitParamRef(ParamRefComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>para</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitPara(ParaComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>permission</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitPermission(PermissionComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>remarks</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitRemarks(RemarksComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>returns</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitReturns(ReturnsComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>seealso</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitSeeAlso(SeeAlsoComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>see</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitSee(SeeComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>summary</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitSummary(SummaryComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>typeparam</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitTypeParam(TypeParamComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a <c>typeparamref</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitTypeParamRef(TypeParamRefComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits a <c>value</c> comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitValue(ValueComment comment, TContext context)
        {
            VisitChildren(comment, context);
        }

        /// <summary>
        /// Visits a whitespace comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        public virtual void VisitWhitespace(WhitespaceComment comment, TContext context)
        {
        }

        /// <summary>
        /// Visits child comments.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="context">The context.</param>
        protected void VisitChildren(AggregateComment comment, TContext context)
        {
            foreach (var child in comment.Children)
            {
                if (child != null)
                {
                    child.Accept(this, context);   
                }                
            }
        }
    }
}
