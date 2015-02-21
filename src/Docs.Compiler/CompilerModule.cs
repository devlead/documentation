using Autofac;
using Docs.Compiler.Core;
using Docs.Compiler.Generators;
using Docs.Compiler.Templating;

namespace Docs.Compiler
{
    public sealed class CompilerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register content generators.
            builder.RegisterType<ApiContentGenerator>().As<IContentGenerator>().SingleInstance();
            builder.RegisterType<StaticContentGenerator>().As<IContentGenerator>().SingleInstance();

            // Register services.
            builder.RegisterType<ApiTemplateEngine>().SingleInstance();
        }
    }
}
