using System;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.Templating;

namespace Docs.Compiler.Templating
{
    internal sealed class ApiTemplateEngine : TemplateEngine
    {
        public ApiTemplateEngine(IFileSystem fileSystem) 
            : base(fileSystem)
        {
        }

        protected override Type GetTemplateType()
        {
            return typeof(ApiTemplate<>);
        }
    }
}