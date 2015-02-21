using Sparrow.Reflection;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Reflection
{
    public sealed class TypeReferenceExtensionsTests
    {
        public sealed class TheGetTypeSignatureMethod : IClassFixture<IdentityGeneratorFixture>
        {
            #region Fixture Initialization

            private readonly IdentityGeneratorFixture _fixture;

            public TheGetTypeSignatureMethod(IdentityGeneratorFixture fixture)
            {
                _fixture = fixture;
            }

            #endregion

            [Fact]
            public void Should_Return_Correct_Type_Description_For_Simple_Type()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));

                // When
                var description = info.GetTypeSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Name);
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Identity);
                Assert.Equal("SimpleClass", description.Name);
                Assert.Equal("T:Sparrow.Tests.Data.SimpleClass", description.Identity);
                Assert.Empty(description.GenericParameters);
            }

            [Fact]
            public void Should_Return_Correct_Type_Description_For_Open_Generic_Type()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(GenericClass<>));

                // When
                var description = info.GetTypeSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Name);
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Identity);
                Assert.Equal("GenericClass", description.Name);
                Assert.Equal("T:Sparrow.Tests.Data.GenericClass`1", description.Identity);
                Assert.Equal(1, description.GenericArguments.Count);
                Assert.Equal("X", description.GenericArguments[0]);
            }

            [Fact]
            public void Should_Return_Correct_Type_Description_For_Generic_Type()
            {
                // Given
                var genericArguments = new[] { typeof(SimpleClass) };
                var genericInstance = _fixture.GetGenericInstanceTypeReference(typeof(GenericClass<>), genericArguments);

                // When
                var description = genericInstance.GetTypeSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Name);
                Assert.Equal("Sparrow.Tests.Data", description.Namespace.Identity);
                Assert.Equal("GenericClass", description.Name);
                Assert.Equal("T:Sparrow.Tests.Data.GenericClass`1", description.Identity);
                Assert.Equal(1, description.GenericParameters.Count);
                Assert.Equal("Sparrow.Tests.Data", description.GenericParameters[0].Namespace.Name);
                Assert.Equal("SimpleClass", description.GenericParameters[0].Name);
            }
        }
    }
}
