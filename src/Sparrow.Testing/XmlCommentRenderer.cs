using System.Text;
using Sparrow.Models;
using Sparrow.Models.Comments;
using Sparrow.Testing.Extensions;

namespace Sparrow.Testing
{
    public sealed class XmlCommentRenderer : CommentVisitor<StringBuilder>
    {
        public static string Render(Comment comment)
        {
            var renderer = new XmlCommentRenderer();
            var builder = new StringBuilder();
            comment.Accept(renderer, builder);
            return builder.ToString().TrimWhitespace();
        }

        public override void VisitCode(CodeComment comment, StringBuilder context)
        {
            context.Append("<code>");
            context.Append(comment.Code);
            context.Append("</code>");
        }

        public override void VisitExample(ExampleComment comment, StringBuilder context)
        {
            context.Append("<example>");
            base.VisitExample(comment, context);
            context.Append("</example>");            
        }

        public override void VisitException(ExceptionComment comment, StringBuilder context)
        {
            context.AppendFormat("<exception cref=\"{0}\">", comment.Member);  
            base.VisitException(comment, context);
            context.Append("</exception>");
        }

        public override void VisitInlineCode(InlineCodeComment comment, StringBuilder context)
        {
            context.Append("<c>");
            context.Append(comment.Code);
            context.Append("</c>");
        }

        public override void VisitInlineText(InlineTextComment comment, StringBuilder context)
        {
            context.Append(comment.Text);
        }

        public override void VisitPara(ParaComment comment, StringBuilder context)
        {
            context.Append("<para>");
            base.VisitPara(comment, context);
            context.Append("</para>");
        }

        public override void VisitParam(ParamComment comment, StringBuilder context)
        {
            context.AppendFormat("<param name=\"{0}\">", comment.Name);
            base.VisitParam(comment, context);
            context.Append("</param>");
        }

        public override void VisitParamRef(ParamRefComment comment, StringBuilder context)
        {
            context.AppendFormat("<paramref name=\"{0}\" />", comment.Name);
        }

        public override void VisitPermission(PermissionComment comment, StringBuilder context)
        {
            context.AppendFormat("<permission cref=\"{0}\">", comment.Member);
            base.VisitPermission(comment, context);
            context.Append("</permission>");            
        }

        public override void VisitRemarks(RemarksComment comment, StringBuilder context)
        {
            context.Append("<remarks>");
            base.VisitRemarks(comment, context);
            context.Append("</remarks>");
        }

        public override void VisitReturns(ReturnsComment comment, StringBuilder context)
        {
            context.Append("<returns>");
            base.VisitReturns(comment, context);
            context.Append("</returns>");
        }

        public override void VisitSee(SeeComment comment, StringBuilder context)
        {
            context.AppendFormat("<see cref=\"{0}\" />", comment.Member);
        }

        public override void VisitSeeAlso(SeeAlsoComment comment, StringBuilder context)
        {
            context.AppendFormat("<seealso cref=\"{0}\" />", comment.Member);
        }

        public override void VisitSummary(SummaryComment comment, StringBuilder context)
        {
            context.Append("<summary>");
            base.VisitSummary(comment, context);
            context.Append("</summary>");
        }

        public override void VisitTypeParam(TypeParamComment comment, StringBuilder context)
        {
            context.AppendFormat("<typeparam name=\"{0}\">", comment.Name);
            base.VisitTypeParam(comment, context);
            context.Append("</typeparam>");
        }

        public override void VisitTypeParamRef(TypeParamRefComment comment, StringBuilder context)
        {
            context.AppendFormat("<typeparamref name=\"{0}\" />", comment.Name);
        }

        public override void VisitValue(ValueComment comment, StringBuilder context)
        {
            context.Append("<value>");
            base.VisitValue(comment, context);
            context.Append("</value>");
        }

        public override void VisitWhitespace(WhitespaceComment comment, StringBuilder context)
        {
            context.Append(comment.Text);
        }
    }
}
