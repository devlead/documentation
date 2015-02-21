using Docs.Compiler.Generators.Api;

namespace Docs.Compiler.Templating
{
    // ---------------------------------------------------------------------
    // See the "Docs.Compiler/Templating/Helpers" folder for implementation.
    // ---------------------------------------------------------------------

    public sealed partial class DocumentationHelper
    {
        private readonly ApiContext _context;

        public DocumentationHelper(ApiContext context)
        {
            _context = context;
        }
    }
}