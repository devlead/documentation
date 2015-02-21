using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Docs.Compiler.Core.NuGet
{
    [DebuggerDisplay("{DebuggerDisplay(),nq}")]
    public sealed class PackageDefinition
    {
        [JsonProperty(PropertyName = "package")]
        public string PackageName { get; set; }

        [JsonProperty(PropertyName = "filters")]
        public List<string> Filters { get; set; }

        [JsonProperty(PropertyName = "core")]
        public bool IsCore { get; set; }

        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay()
        {
            var suffix = IsCore ? string.Empty : "(addin)";
            return string.Format("\"{0}\" {1}", PackageName, suffix).Trim();
        }
    }
}