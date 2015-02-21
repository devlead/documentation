using System.Collections.Generic;
using System.Linq;
using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Sparrow.Models.Comments;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public sealed class NamespaceViewModel : ApiViewModel
    {
        private readonly DocumentedNamespace _namespace;
        private readonly List<DocumentedType> _classes;
        private readonly List<DocumentedType> _interfaces;

        public DocumentedNamespace Namespace
        {
            get { return _namespace; }
        }

        public IReadOnlyList<DocumentedType> Classes
        {
            get { return _classes; }
        }

        public IReadOnlyList<DocumentedType> Interfaces
        {
            get { return _interfaces; }
        }

        public SummaryComment Summary
        {
            get { return _namespace.Summary; }
        }

        public NamespaceViewModel(ApiContext context, DocumentedNamespace @namespace, Content parent, string title)
            : base(context, parent, title)
        {
            _namespace = @namespace;
            _classes = new List<DocumentedType>(_namespace.Types.Where(x => x.Definition.IsClass));
            _interfaces = new List<DocumentedType>(_namespace.Types.Where(x => x.Definition.IsInterface));
        }
    }
}