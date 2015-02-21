using System.Collections.Generic;
using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public sealed class ApiOverviewViewModel : ApiViewModel
    {
        private readonly List<DocumentedAssembly> _namespaces;

        public IReadOnlyList<DocumentedAssembly> Assemblies
        {
            get { return _namespaces; }
        }

        public ApiOverviewViewModel(ApiContext context, Content parent, string title) 
            : base(context, parent, title)
        {
            _namespaces = new List<DocumentedAssembly>(context.DocumentModel.Assemblies);
        }
    }
}
