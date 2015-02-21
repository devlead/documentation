using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Mono.Cecil;
using Sparrow.Models.Documentation;
using Sparrow.Models.Reflection;
using Sparrow.Models.Xml;

namespace Sparrow.Models
{
    /// <summary>
    /// Responsible for building a document model
    /// given a reflection model and an XML documentation model.
    /// </summary>
    public sealed class DocumentModelBuilder
    {
        /// <summary>
        /// Generates a document model.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns>The built document model.</returns>
        public DocumentModel BuildModel(IEnumerable<string> paths)
        {
            var filePaths = paths.ToArray();
            var reflectionModel = BuildReflectionModel(filePaths);
            var xmlModel = BuildXmlModel(filePaths);
            return DocumentModelMapper.Map(reflectionModel, xmlModel);
        }

        private static ReflectionModel BuildReflectionModel(IEnumerable<string> paths)
        {
            var assemblyPaths = paths.Where(x => Path.GetExtension(x) == ".dll");
            var definitions = new List<AssemblyDefinition>();
            foreach (var assemblyPath in assemblyPaths)
            {
                definitions.Add(AssemblyDefinition.ReadAssembly(assemblyPath));
            }
            return ReflectionModelBuilder.Build(definitions);
        }

        private static XmlDocumentationModel BuildXmlModel(IEnumerable<string> paths)
        {
            var parser = new XmlDocumentationParser();
            var documents = new List<XmlDocument>();
            var xmlPaths = paths.Where(x => Path.GetExtension(x) == ".xml").ToArray();
            foreach (var path in xmlPaths)
            {
                using (var stream = File.OpenRead(path))
                {
                    var document = new XmlDocument { PreserveWhitespace = false };
                    document.Load(stream);
                    documents.Add(document);
                }
            }
            return parser.Parse(documents);
        }
    }
}
