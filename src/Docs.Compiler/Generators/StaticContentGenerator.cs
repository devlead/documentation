using System.Collections.Generic;
using System.Linq;
using Docs.Compiler.Core;
using Docs.Compiler.Core.Diagnostics;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Generators.Static;

namespace Docs.Compiler.Generators
{
    public sealed class StaticContentGenerator : IContentGenerator
    {
        private readonly IFileSystem _fileSystem;
        private readonly IEnvironment _environment;
        private readonly ILog _log;

        public int SortOrder
        {
            get { return int.MinValue; }
        }

        public StaticContentGenerator(IFileSystem fileSystem, IEnvironment environment, ILog log)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _log = log;
        }

        public void Generate(CompilerConfiguration configuration, Content parent)
        {
            var pagesPath = configuration.Root.Combine("pages").MakeAbsolute(_environment);
            var pagesDirectory = _fileSystem.GetDirectory(pagesPath);
            if (!pagesDirectory.Exists)
            {
                _log.Warning("No pages directory found.");
                return;
            }

            // Get all files.
            var pages = new List<StaticPage>();
            var files = pagesDirectory.GetFiles("*.md", SearchScope.Current)
                .Concat(pagesDirectory.GetFiles("*.html", SearchScope.Current));
            foreach (var file in files)
            {                
                var page = StaticPageParser.Parse(file);
                pages.Add(page);
            }

            // Create content from all files.
            foreach (var page in pages.OrderBy(x=> x.SortOrder))
            {
                var pageContent = page.Content;
                if (page.ContentType == "markdown")
                {
                    // Process markdown.
                    var md = new MarkdownDeep.Markdown();
                    pageContent = md.Transform(pageContent);
                }

                var content = new Content(page.Id, page.Id, page.Title, null, pageContent);
                parent.AddChild(content);
            }
        }
    }
}
