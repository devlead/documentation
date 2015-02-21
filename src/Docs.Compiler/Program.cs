using System;
using Autofac;
using CLAP;
using Docs.Compiler.Configuration;
using Docs.Compiler.Core.Bootstrapping;
using Docs.Compiler.Core.Diagnostics;
using Docs.Compiler.Core.Templating;

namespace Docs.Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Run<Program>(args);
        }

        [Empty, Help]
        public static void Help(string help)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cake Documentation Compiler");
            Console.ResetColor();
            Console.WriteLine(help);
        }

        // ReSharper disable once UnusedMember.Local
        [Verb(IsDefault = true)]
        private static void Run(string configuration)
        {
            // Build the container.
            using (var container = BuildContainer())
            {
                // Run the application.
                var application = container.Resolve<Application>();
                application.Run(configuration);
            }
        }

        private static IContainer BuildContainer()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register modules.            
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<CompilerModule>();

            // Register services.
            builder.RegisterType<Application>().SingleInstance();
            builder.RegisterType<ApplicationConfigurationReader>().SingleInstance();
            builder.RegisterType<ConsoleLog>().As<ILog>().SingleInstance();
            builder.RegisterType<TemplateEngine>().SingleInstance();

            // Build the container.
            return builder.Build();
        }
    }
}
