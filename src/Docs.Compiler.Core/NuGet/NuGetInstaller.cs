using System.Collections.Generic;
using System.Linq;
using Docs.Compiler.Core.Diagnostics;
using Docs.Compiler.Core.IO;
using NuGet;
using IFileSystem = Docs.Compiler.Core.IO.IFileSystem;

namespace Docs.Compiler.Core.NuGet
{
    internal sealed class NuGetInstaller : INuGetInstaller
    {
        private readonly IFileSystem _fileSystem;
        private readonly IEnvironment _environment;
        private readonly IGlobber _globber;
        private readonly ILog _log;

        public NuGetInstaller(IFileSystem fileSystem, IEnvironment environment, IGlobber globber, ILog log)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _globber = globber;
            _log = log;
        }

        public IEnumerable<IFile> Install(CompilerConfiguration options, bool installAddins)
        {
            var result = new List<FilePath>();
            foreach (var package in options.Packages)
            {
                if (!package.IsCore && !installAddins)
                {
                    continue;
                }

                var paths = new FilePathCollection(PathComparer.Default);

                // Install the package.
                var packagePath = Install(package);
                var packageDirectory = _fileSystem.GetDirectory(packagePath);

                if (package.Filters != null && package.Filters.Count > 0)
                {
                    // Get all files matching the filters.
                    foreach (var filter in package.Filters)
                    {
                        var pattern = string.Concat(packagePath.FullPath, "/", filter.TrimStart('/', '\\'));
                        paths.Add(_globber.GetFiles(pattern));
                    }
                }
                else
                {
                    // Do a recursive search in the package directory.
                    paths.Add(packageDirectory.
                        GetFiles("*", SearchScope.Recursive)
                        .Select(file => file.Path));
                }

                if (paths.Count > 0)
                {
                    result.AddRange(paths);
                }
            }

            return result.Select(path => _fileSystem.GetFile(path));
        }

        public DirectoryPath Install(PackageDefinition package)
        {
            var packagePath = _environment.GetApplicationRoot().Combine("Packages");
            if (!_fileSystem.Exist(packagePath))
            {
                _log.Information("Creating package directory...");
                _fileSystem.GetDirectory(packagePath).Create();
            }

            if (!_fileSystem.Exist(packagePath.Combine(package.PackageName)))
            {
                _log.Information("Downloading package {0}...", package.PackageName);
                var packageManager = CreatePackageManager(packagePath);
                packageManager.InstallPackage(package.PackageName);   
            }

            // Return the installation directory.
            return packagePath.Combine(package.PackageName);
        }

        private static PackageManager CreatePackageManager(DirectoryPath packagePath)
        {
            var repository = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
            var resolver = new PackagePathResolver(packagePath);
            var fileSystem = new PhysicalFileSystem(packagePath.FullPath);
            return new PackageManager(repository, resolver, fileSystem);
        }
    }
}
