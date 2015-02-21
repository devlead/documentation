using RazorEngine.Text;
using Sparrow.Models.Documentation;

// ReSharper disable once CheckNamespace
namespace Docs.Compiler.Templating
{
    public partial class DocumentationHelper
    {
        public IEncodedString AssemblyName(DocumentedAssembly assembly)
        {
            var identity = assembly.Identity;
            var index = identity.IndexOf(',');
            if (index != -1)
            {
                identity = identity.Substring(0, index);
            }
            identity = string.Concat(identity, ".dll");
            return new RawString(identity);
        }
    }
}
