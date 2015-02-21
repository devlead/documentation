using RazorEngine.Text;
using Sparrow.Models.Comments;

// ReSharper disable once CheckNamespace
namespace Docs.Compiler.Templating
{
    public partial class DocumentationHelper
    {
        public IEncodedString Comment(Comment comment)
        {
            return new RawString(_context.CommentRenderer.Render(_context, comment));
        }
    }
}
