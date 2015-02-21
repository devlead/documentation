using System.Collections.Generic;
using System.Linq;
using Docs.Compiler.Core;
using Docs.Compiler.Generators.Api;
using Sparrow.Models.Comments;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.ViewModels.Api
{
    public sealed class TypeViewModel : ApiViewModel
    {
        private readonly DocumentedType _type;
        private readonly List<DocumentedMethod> _extensionMethods;

        public DocumentedType Type
        {
            get { return _type; }
        }

        public SummaryComment Summary
        {
            get { return _type.Summary; }
        }

        public IReadOnlyList<DocumentedMethod> Constructors
        {
            get { return _type.Constructors; }
        }

        public IReadOnlyList<DocumentedProperty> Properties
        {
            get { return _type.Properties; }
        }

        public IReadOnlyList<DocumentedMethod> Methods
        {
            get { return _type.Methods; }
        }

        public IReadOnlyList<DocumentedMethod> Operators
        {
            get { return _type.Operators; }
        }

        public IReadOnlyList<DocumentedMethod> ExtensionMethods
        {
            get { return _extensionMethods; }
        }

        public TypeViewModel(ApiContext context, DocumentedType type, Content parent, string title)
            : base(context, parent, title)
        {
            _type = type;
            _extensionMethods = context.DocumentModel.FindExtensionMethods(type).ToList();
        }
    }
}