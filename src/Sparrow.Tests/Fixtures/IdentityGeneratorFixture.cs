using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using NSubstitute;
using Sparrow.Tests.Data;
using Sparrow.Utilities;

namespace Sparrow.Tests.Fixtures
{
    public sealed class IdentityGeneratorFixture
    {
        private readonly AssemblyDefinition _assembly;

        public IUrlResolver UrlResolver { get; set; }

        public IdentityGeneratorFixture()
        {
            _assembly = AssemblyDefinition.ReadAssembly(typeof(SimpleClass).Assembly.Location);

            UrlResolver = Substitute.For<IUrlResolver>();
        }

        public TypeReference GetGenericInstanceTypeReference(Type type, Type[] arguments)
        {
            var module = _assembly.Modules.First();
            var typeDef = module.Import(GetCecilTypeDefinition(type));
            // ReSharper disable once CoVariantArrayConversion
            return typeDef.MakeGenericInstanceType(arguments.Select(GetCecilTypeDefinition).ToArray());
        }

        public TypeDefinition GetCecilTypeDefinition(Type type)
        {
            foreach (var module in _assembly.Modules)
            {
                foreach (var moduleType in module.Types)
                {
                    if (moduleType.MetadataToken.ToInt32() == type.MetadataToken)
                    {
                        return moduleType;
                    }
                }
            }
            throw new InvalidOperationException("Could not find type.");
        }
    }
}
