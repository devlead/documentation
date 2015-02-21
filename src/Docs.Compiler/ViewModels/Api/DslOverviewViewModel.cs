using System.Collections.Generic;
using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public class DslOverviewViewModel : ApiViewModel
    {
        private readonly Dictionary<string, Dictionary<string, List<DocumentedMethod>>> _tree;

        public Dictionary<string, Dictionary<string, List<DocumentedMethod>>> Tree
        {
            get { return _tree; }
        }

        public DslOverviewViewModel(
            ApiContext context, 
            Content parent, 
            string title, 
            Dictionary<string, Dictionary<string, List<DocumentedMethod>>> tree) 
            : base(context, parent, title)
        {
            _tree = tree;
        }
    }
}
