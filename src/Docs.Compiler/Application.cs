using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Docs.Compiler.Configuration;
using Docs.Compiler.Core;
using Docs.Compiler.Core.Diagnostics;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.Templating;
using Docs.Compiler.ViewModels;

namespace Docs.Compiler
{
    internal sealed class Application
    {
        private readonly IFileSystem _fileSystem;
        private readonly IEnvironment _environment;
        private readonly ILog _log;
        private readonly ApplicationConfigurationReader _configurationReader;
        private readonly TemplateEngine _engine;
        private readonly IEnumerable<IContentGenerator> _generators;

        public Application(IFileSystem fileSystem, IEnvironment environment, ILog log,
            ApplicationConfigurationReader configurationReader, TemplateEngine engine,
            IEnumerable<IContentGenerator> generators)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _log = log;
            _configurationReader = configurationReader;
            _engine = engine;
            _generators = generators;
        }

        public void Run(FilePath configurationPath)
        {
            // Read the configuration.
            var configuration = GetConfiguration(configurationPath);

            // Iterate all content generators and let the generate content.
            var root = new Content("root", null, "Root", null, null);
            foreach (var generator in _generators.OrderBy(x => x.SortOrder))
            {
                _log.Information("Building content using {0}...", generator.GetType().FullName);
                generator.Generate(configuration, root);
            }

            // Generate pages for all the content.
            _log.Information("Processing content...");
            var count = 0;
            foreach (var page in root.Children)
            {
                count += BuildPage(configuration, root, root, page);
            }
            _log.Information("Created {0} pages.", count);
        }

        public int BuildPage(CompilerConfiguration configuration, Content root, Content parent, Content current)
        {
            var count = 1;

            // Create the view model.
            var model = new LayoutViewModel(parent, current.Title);
            model.CurrentId = current.Id;
            model.Current = current;
            model.Root = root;

            // Render the master page with the model.
            var html = _engine.Render(configuration, "templates/layout.cshtml", model);

            // Save the result to disc.
            var outputFilePath = current.Id == "index" && current.Parent == root 
                ? new FilePath("index.html")
                : new FilePath(string.Concat(current.GetLink(), "/index.html").TrimStart('/'));

            outputFilePath = outputFilePath.MakeAbsolute(configuration.OutputPath);
            var outputPath = outputFilePath.GetDirectory();
            if (!_fileSystem.Exist(outputPath))
            {
                _fileSystem.GetDirectory(outputPath).Create();
            }
            
            using(var stream = _fileSystem.GetFile(outputFilePath).OpenWrite())
            using (var writer = new StreamWriter(stream))
            {                
                writer.Write(html);
            }

            // Process child pages recursivly.
            foreach (var child in current.Children)
            {
                count += BuildPage(configuration, root, current, child);
            }

            return count;
        }

        private CompilerConfiguration GetConfiguration(FilePath configurationPath)
        {
            // Read the JSON configuration.
            _log.Information("Reading configuration...");
            var configuration = _configurationReader.Read(configurationPath);

            // Get the root directory.
            var root = configurationPath.GetDirectory().MakeAbsolute(_environment);

            // Validate the output path.
            if (configuration.OutputPath == null)
            {
                throw new InvalidOperationException("No output path specified in configuration.");
            }

            // Make sure the output path exist.
            var outputPath = root.Combine(configuration.OutputPath).Collapse();
            if (!_fileSystem.Exist(outputPath))
            {
                var message = string.Format("The output path '{0}' do not exist.", outputPath);
                throw new InvalidOperationException(message);
            }

            // Create the compiler configuration.
            return new CompilerConfiguration(root, outputPath, configuration.Packages);
        }
    }
}
