using System.Collections.Generic;
using Docs.Compiler.Core;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Templating;
using Docs.Compiler.ViewModels.Api;
using Mono.Cecil;
using Sparrow.Models.Documentation;

namespace Docs.Compiler.Generators.Api.Builders
{
    internal sealed class DslOverviewContentBuilder : ApiContentBuilder<DocumentModel, DslOverviewViewModel>
    {
        public DslOverviewContentBuilder(ApiTemplateEngine engine) 
            : base(engine)
        {
        }

        protected override FilePath GetTemplate()
        {
            return "templates/api/dsl.cshtml";
        }

        protected override DslOverviewViewModel CreateViewModel(ApiContext context, Content parent, DocumentModel model)
        {
            return new DslOverviewViewModel(context, parent, "DSL reference", BuildTree(model));
        }

        protected override string GetContentId(ApiContext context, Content parent, DocumentModel model, DslOverviewViewModel viewModel)
        {
            return "dsl-reference";
        }

        protected override string GetLink(ApiContext context, Content parent, DocumentModel model, DslOverviewViewModel viewModel)
        {
            return "dsl";
        }

        // NOTE: lol?
        private static Dictionary<string, Dictionary<string, List<DocumentedMethod>>> BuildTree(DocumentModel model)
        {
            var result = new Dictionary<string, Dictionary<string, List<DocumentedMethod>>>();

            foreach (var assembly in model.Assemblies)
            {
                foreach (var ns in assembly.Namespaces)
                {
                    foreach (var type in ns.Types)
                    {
                        foreach (var method in type.Methods)
                        {
                            bool isPropertyAlias;
                            if (method.IsCakeAlias(out isPropertyAlias))
                            {
                                var typeCategory = GetCategory(method.Definition.DeclaringType.CustomAttributes);
                                var methodCategory = GetCategory(method.Definition.CustomAttributes);

                                var parentCategory = typeCategory ?? "Misc";
                                var category = methodCategory ?? string.Empty;

                                if (!result.ContainsKey(parentCategory))
                                {
                                    result.Add(parentCategory, new Dictionary<string, List<DocumentedMethod>>());
                                }
                                if (!result[parentCategory].ContainsKey(category))
                                {
                                    result[parentCategory].Add(category, new List<DocumentedMethod>());
                                }

                                result[parentCategory][category].Add(method);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static string GetCategory(IEnumerable<CustomAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.AttributeType != null &&
                    attribute.AttributeType.FullName == "Cake.Core.Annotations.CakeAliasCategoryAttribute")
                {
                    return attribute.ConstructorArguments[0].Value as string;
                }
            }
            return null;
        }
    }
}
