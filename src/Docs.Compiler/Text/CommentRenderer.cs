using Docs.Compiler.Core;
using Docs.Compiler.Core.Templating;
using Docs.Compiler.Generators.Api;
using Sparrow.Models;
using Sparrow.Models.Comments;
using Sparrow.Reflection;
using Sparrow.Utilities.Rendering;

namespace Docs.Compiler.Text
{
    public sealed class CommentRenderer : CommentVisitor<CommentRendererContext>
    {
        public string Render(ApiContext context, Comment comment)
        {
            if (comment == null)
            {
                return string.Empty;
            }
            var builder = new EncodedStringBuilder();
            comment.Accept(this, new CommentRendererContext(context, builder));
            return builder.ToString();
        }

        public override void VisitInlineCode(InlineCodeComment comment, CommentRendererContext context)
        {
            if (!string.IsNullOrWhiteSpace(comment.Code))
            {
                var code = comment.Code;
                code = code.Replace("{", "{{").Replace("}", "}}");
                code = code.UnintendCode();

                context.Builder.AppendRaw("<code>");
                context.Builder.AppendEncoded(code);
                context.Builder.AppendRaw("</code>");
            }
        }

        public override void VisitCode(CodeComment comment, CommentRendererContext context)
        {
            if (!string.IsNullOrWhiteSpace(comment.Code))
            {
                var code = comment.Code;
                code = code.Replace("{", "{{").Replace("}", "}}");
                code = code.UnintendCode();

                context.Builder.AppendRaw("<code>");
                context.Builder.AppendEncoded(code);
                context.Builder.AppendRaw("</code>");
            }
        }

        public override void VisitParamRef(ParamRefComment comment, CommentRendererContext context)
        {
            context.Builder.AppendRaw("<i>");
            context.Builder.AppendEncoded(comment.Name);
            context.Builder.AppendRaw("</i>");
        }

        public override void VisitInlineText(InlineTextComment comment, CommentRendererContext context)
        {
            context.Builder.AppendRaw(comment.Text);
        }

        public override void VisitSee(SeeComment comment, CommentRendererContext context)
        {
            var identity = comment.Member;
            var member = context.ApiContext.Resolver.FindType(comment.Member);
            if (member != null)
            {
                var signature = member.Definition.GetTypeSignature(context.ApiContext.UrlResolver);
                const TypeRenderOption options = TypeRenderOption.Link | TypeRenderOption.Name;
                var result = context.ApiContext.SignatureRenderer.Render(context.ApiContext.Language, signature, options);
                context.Builder.AppendRaw(result);   
            }
            else
            {
                // TODO: We need to find the link to external types. Save this for later.
                context.Builder.AppendRaw("<i>");
                var name = context.ApiContext.Language.GetAlias(identity);
                if (name == null)
                {
                    var index = identity.IndexOf(':');
                    context.Builder.AppendEncoded(index != 0 ? identity.Substring(index + 1) : "???");
                }
                else
                {
                    context.Builder.AppendEncoded("????");
                }   
                context.Builder.AppendRaw("</i>");
            }
        }
    }
}
