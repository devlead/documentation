using System.Collections.Generic;
using Docs.Compiler.Core.IO;

namespace Docs.Compiler.Core.NuGet
{
    public interface INuGetInstaller
    {
        IEnumerable<IFile> Install(CompilerConfiguration options, bool installAddins);
        DirectoryPath Install(PackageDefinition package);
    }
}
