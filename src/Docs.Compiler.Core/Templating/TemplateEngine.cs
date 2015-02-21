using System;
using System.IO;
using Docs.Compiler.Core.IO;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Docs.Compiler.Core.Templating
{
    public class TemplateEngine
    {
        private readonly IFileSystem _fileSystem;
        private readonly IRazorEngineService _engine;
        private readonly object _lock;

        public TemplateEngine(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            _engine = RazorEngineService.Create(CreateConfiguration());
            _lock = new object();
        }

        private TemplateServiceConfiguration CreateConfiguration()
        {
            return new TemplateServiceConfiguration
            {
                Debug = true,
                BaseTemplateType = GetTemplateType()
            };
        }

        protected virtual Type GetTemplateType()
        {
            return typeof(Template<>);
        }

        public string Render<TModel>(CompilerConfiguration configuration, FilePath templatePath, TModel model)
            where TModel : TemplateViewModel
        {
            lock (_lock)
            {
                var templateName = templatePath.FullPath;

                if (!_engine.IsTemplateCached(templateName, typeof(TModel)))
                {
                    templatePath = configuration.Root.CombineWithFilePath(templatePath);

                    // Make sure the template exist.
                    if (!_fileSystem.Exist(templatePath))
                    {
                        const string format = "The template '{0}' do not exist.";
                        var message = string.Format(format, templatePath.FullPath);
                        throw new InvalidOperationException(message);
                    }

                    using (var stream = _fileSystem.GetFile(templatePath).OpenRead())
                    using (var reader = new StreamReader(stream))
                    {
                        // Read the template and compile it.
                        var template = reader.ReadToEnd();

                        _engine.AddTemplate(templateName, template);
                        _engine.Compile(templateName, typeof(TModel));
                    }
                }

                return _engine.Run(templateName, typeof(TModel), model);
            }
        }
    }
}
