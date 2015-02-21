using System.Collections.Generic;
using System.Linq;
using Sparrow.Models.Documentation;
using Sparrow.Utilities;

namespace Docs.Compiler.Generators.Api
{
    public sealed class ApiUrlResolver : IUrlResolver
    {
        private readonly Dictionary<string, string> _lookup;
        private const string RootLink = "api";

        public ApiUrlResolver(DocumentModel model)
        {
            _lookup = new Dictionary<string, string>();
            
            // Iterate all namespaces in all assemblies.
            foreach (var @namespace in model.Assemblies.SelectMany(assembly => assembly.Namespaces))
            {
                // Index namespace.
                var namespaceUrl = string.Concat(RootLink, "/", GetLinkPart(@namespace));
                _lookup.Add(@namespace.Identity, namespaceUrl);
                
                foreach (var type in @namespace.Types)
                {
                    // Index type.
                    var typeUrl = string.Concat(namespaceUrl, "/", GetLinkPart(type));
                    _lookup.Add(type.Identity, typeUrl);

                    foreach (var constructor in type.Constructors)
                    {
                        // Index method.
                        var methodUrl = string.Concat(typeUrl, "/", GetLinkPart(constructor));
                        _lookup.Add(constructor.Identity, methodUrl);
                    }

                    foreach (var property in type.Properties)
                    {
                        // Index method.
                        var methodUrl = string.Concat(typeUrl, "/", GetLinkPart(property));
                        _lookup.Add(property.Identity, methodUrl);
                    }

                    foreach (var method in type.Methods)
                    {
                        // Index method.
                        var methodUrl = string.Concat(typeUrl, "/", GetLinkPart(method));
                        _lookup.Add(method.Identity, methodUrl);
                    }
                }
            }
        }

        public string GetUrl(string identity)
        {
            return _lookup.ContainsKey(identity) 
                ? string.Concat("/", _lookup[identity], "/")
                : null;
        }

        public string GetLinkPart(DocumentedNamespace @namespace)
        {
            return @namespace.Identity.ToLowerInvariant();
        }

        public string GetLinkPart(DocumentedType type)
        {
            return string.Format("{0:X8}", type.Identity.GetHashCode())
                .ToLowerInvariant();
        }

        public string GetLinkPart(DocumentedMethod method)
        {
            return string.Format("{0:X8}", method.Identity.GetHashCode()).ToLowerInvariant();
        }

        public string GetLinkPart(DocumentedProperty property)
        {
            return string.Format("{0:X8}", property.Identity.GetHashCode()).ToLowerInvariant();
        }
    }
}
