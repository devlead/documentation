using System.Collections.Generic;
using System.IO;
using Docs.Compiler.Core.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Docs.Compiler.Configuration
{
    internal sealed class ApplicationConfigurationReader
    {
        private readonly IFileSystem _fileSystem;

        public ApplicationConfigurationReader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public ApplicationConfiguration Read(FilePath configurationPath)
        {
            var file = _fileSystem.GetFile(configurationPath);
            if (!file.Exists)
            {
                throw new FileNotFoundException("Configuration file do not exist.", configurationPath.FullPath);
            }
            using (var stream = file.OpenRead())
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ApplicationConfiguration>(content, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter> { new StringEnumConverter { CamelCaseText = false } },
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }
    }
}
