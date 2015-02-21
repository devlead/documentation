using System;
using System.Globalization;
using System.Reflection;

namespace Docs.Compiler.Core.IO
{
    /// <summary>
    /// Represents the environment Cake operates in.
    /// </summary>
    internal sealed class Environment : IEnvironment
    {
        /// <summary>
        /// Gets or sets the working directory.
        /// </summary>
        /// <value>The working directory.</value>
        public DirectoryPath WorkingDirectory
        {
            get { return System.Environment.CurrentDirectory; }
            set { SetWorkingDirectory(value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Environment"/> class.
        /// </summary>
        public Environment()
        {
            WorkingDirectory = new DirectoryPath(System.Environment.CurrentDirectory);    
        }

        /// <summary>
        /// Gets whether or not the current operative system is 64 bit.
        /// </summary>
        /// <returns>
        /// Whether or not the current operative system is 64 bit.
        /// </returns>
        public bool Is64BitOperativeSystem()
        {
            return Machine.Is64BitOperativeSystem();
        }

        /// <summary>
        /// Determines whether the current machine is running Unix.
        /// </summary>
        /// <returns>
        /// Whether or not the current machine is running Unix.
        /// </returns>
        public bool IsUnix()
        {
            return Machine.IsUnix();
        }

        /// <summary>
        /// Gets a special path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// A <see cref="DirectoryPath" /> to the special path.
        /// </returns>
        public DirectoryPath GetSpecialPath(SpecialPath path)
        {
            if (path == SpecialPath.ProgramFilesX86)
            {
                return new DirectoryPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86));
            }
            if (path == SpecialPath.Windows)
            {
                return new DirectoryPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows));
            }
            const string format = "The special path '{0}' is not supported.";
            throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, format, path.ToString()));
        }

        /// <summary>
        /// Gets the application root path.
        /// </summary>
        /// <returns>
        /// The application root path.
        /// </returns>
        public DirectoryPath GetApplicationRoot()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new DirectoryPath(path);
        }

        /// <summary>
        /// Gets an environment variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>
        /// The value of the environment variable.
        /// </returns>
        public string GetEnvironmentVariable(string variable)
        {
            return System.Environment.GetEnvironmentVariable(variable);
        }

        private static void SetWorkingDirectory(DirectoryPath path)
        {
            if (path.IsRelative)
            {
                throw new InvalidOperationException("Working directory can not be set to a relative path.");
            }
            System.Environment.CurrentDirectory = path.FullPath;
        }
    }
}
