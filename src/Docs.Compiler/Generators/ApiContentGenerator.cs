using System.Linq;
using Docs.Compiler.Core;
using Docs.Compiler.Core.NuGet;
using Docs.Compiler.Generators.Api;
using Docs.Compiler.Generators.Api.Builders;
using Docs.Compiler.Templating;
using Docs.Compiler.Text;
using Sparrow.Models;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.Generators
{
    internal sealed class ApiContentGenerator : IContentGenerator
    {
        private readonly INuGetInstaller _nugetInstaller;
        private readonly ApiOverviewContentBuilder _apiOverviewBuilder;
        private readonly DslOverviewContentBuilder _dslOverviewBuilder;
        private readonly NamespaceContentBuilder _namespaceBuilder;
        private readonly TypeContentBuilder _typeBuilder;
        private readonly MethodContentBuilder _methodBuilder;
        private readonly PropertyContentBuilder _propertyBuilder;

        public int SortOrder
        {
            get { return int.MaxValue; }
        }

        public ApiContentGenerator(INuGetInstaller nugetInstaller, ApiTemplateEngine engine)
        {
            _nugetInstaller = nugetInstaller;
            _apiOverviewBuilder = new ApiOverviewContentBuilder(engine);
            _dslOverviewBuilder = new DslOverviewContentBuilder(engine);
            _namespaceBuilder = new NamespaceContentBuilder(engine);
            _typeBuilder = new TypeContentBuilder(engine);
            _methodBuilder = new MethodContentBuilder(engine);
            _propertyBuilder = new PropertyContentBuilder(engine);
        }

        public void Generate(CompilerConfiguration configuration, Content parent)
        {
            // Install packages.
            var files = _nugetInstaller.Install(configuration, false /* Skip addins for now */);

            // Get document model.
            var modelBuilder = new DocumentModelBuilder();
            var model = modelBuilder.BuildModel(files.Select(x => x.Path.FullPath));

            // Build context.
            var renderer = new CommentRenderer();
            var pageIndex = new ApiUrlResolver(model);
            var context = new ApiContext(model, renderer, pageIndex);

            // Create the API and DSL reference overview.
            var apiRoot = _apiOverviewBuilder.Create(configuration, context, parent, model);
            var dslRoot = _dslOverviewBuilder.Create(configuration, context, parent, model);                        

            // Add the generated content to it's parent.
            parent.AddChild(dslRoot);
            parent.AddChild(apiRoot);

            // Generate the content.
            Generate(configuration, context, apiRoot);
        }

        private void Generate(CompilerConfiguration configuration, ApiContext context, Content parent)
        {
            foreach (var assembly in context.DocumentModel.Assemblies)
            {
                foreach (var @namespace in assembly.Namespaces.OrderBy(x => x.Identity))
                {
                    // Build the namespace content.
                    var namespaceContent = GenerateNamespace(configuration, context, parent, @namespace);

                    // Add the namespace content to the parent.
                    parent.AddChild(namespaceContent);
                }
            }
        }

        private Content GenerateNamespace(CompilerConfiguration configuration, ApiContext context, Content parent,
            DocumentedNamespace @namespace)
        {
            var namespaceContent = _namespaceBuilder.Create(configuration, context, parent, @namespace);

            foreach (var type in @namespace.Types.OrderBy(x => x.Definition.Name))
            {
                // Generate type content.
                var typeContent = GenerateType(configuration, context, namespaceContent, type);

                // Add the type to the namespace content.
                namespaceContent.AddChild(typeContent);
            }

            return namespaceContent;
        }

        private Content GenerateType(CompilerConfiguration configuration, ApiContext context, Content parent, DocumentedType type)
        {
            var typeContent = _typeBuilder.Create(configuration, context, parent, type);

            // Generate constructors.
            foreach (var constructorContent in type.Constructors.OrderBy(x => x.Parameters.Count)
                .Select(c => _methodBuilder.Create(configuration, context, typeContent, c)))
            {
                typeContent.AddChild(constructorContent);
            }

            // Generate properties.
            foreach (var propertyContent in type.Properties.OrderBy(x => x.Definition.Name)
                .Select(p => _propertyBuilder.Create(configuration, context, typeContent, p)))
            {
                typeContent.AddChild(propertyContent);
            }

            // Generate methods.
            foreach (var methodContent in type.Methods.OrderBy(x => x.Definition.Name)
                .Select(method => _methodBuilder.Create(configuration, context, typeContent, method)))
            {
                typeContent.AddChild(methodContent);
            }

            return typeContent;
        }
    }
}
