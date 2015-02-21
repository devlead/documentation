using System.Collections.Generic;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.NuGet;

namespace Docs.Compiler.Core
{
    public sealed class CompilerConfiguration
    {
        private readonly DirectoryPath _root;
        private readonly DirectoryPath _outputPath;
        private readonly List<PackageDefinition> _packages;

        public DirectoryPath Root
        {
            get { return _root; }
        }

        public DirectoryPath OutputPath
        {
            get { return _outputPath; }
        }

        public IReadOnlyList<PackageDefinition> Packages
        {
            get { return _packages; }
        }

        public CompilerConfiguration(DirectoryPath root, DirectoryPath outputPath, IEnumerable<PackageDefinition> packages)
        {
            _root = root;
            _outputPath = outputPath;
            _packages = new List<PackageDefinition>(packages);
        }
    }
}
