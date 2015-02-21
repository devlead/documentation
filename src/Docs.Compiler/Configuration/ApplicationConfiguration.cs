using System.Collections.Generic;
using Docs.Compiler.Core.IO;
using Docs.Compiler.Core.NuGet;
using Newtonsoft.Json;

namespace Docs.Compiler.Configuration
{
    internal sealed class ApplicationConfiguration
    {
        [JsonProperty("output")]
        public DirectoryPath OutputPath { get; set; }

        [JsonProperty("packages")]
        public List<PackageDefinition> Packages { get; set; }
    }
}
