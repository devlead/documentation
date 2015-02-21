using Autofac;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.NuGet;

namespace Docs.Compiler.Core.Bootstrapping
{
    public sealed class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NuGetInstaller>().As<INuGetInstaller>().SingleInstance();
            builder.RegisterType<FileSystem>().As<IFileSystem>().SingleInstance();
            builder.RegisterType<Environment>().As<IEnvironment>().SingleInstance();
            builder.RegisterType<Globber>().As<IGlobber>().SingleInstance();
        }
    }
}
