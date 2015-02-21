using Sparrow.Reflection;
using Sparrow.Testing.Extensions;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Reflection
{
    public sealed class MethodReferenceExtensionsTests
    {
        public sealed class TheGetMethodSignatureMethod : IClassFixture<IdentityGeneratorFixture>
        {
            #region Fixture Initialization

            private readonly IdentityGeneratorFixture _fixture;

            public TheGetMethodSignatureMethod(IdentityGeneratorFixture fixture)
            {
                _fixture = fixture;
            }

            #endregion

            [Fact]
            public void Should_Return_Correct_Method_Signature_For_Constructor()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = info.GetConstructor();

                // When
                var signature = method.GetMethodSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", signature.DeclaringType.Namespace.Name);
                Assert.Equal("SimpleClass", signature.DeclaringType.Name);
                Assert.Equal("SimpleClass", signature.Name);
                Assert.Equal(0, signature.Parameters.Count);
            }

            [Fact]
            public void Should_Return_Correct_Method_Signature_For_Constructor_With_Parameter()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = info.GetConstructor(typeof(int));

                // When
                var signature = method.GetMethodSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", signature.DeclaringType.Namespace.Name);
                Assert.Equal("SimpleClass", signature.DeclaringType.Name);
                Assert.Equal("SimpleClass", signature.Name);
                Assert.Equal(1, signature.Parameters.Count);
                Assert.Equal("first", signature.Parameters[0].Name);
                Assert.Equal("System", signature.Parameters[0].ParameterType.Namespace.Name);
                Assert.Equal("Int32", signature.Parameters[0].ParameterType.Name);
            }

            [Fact]
            public void Should_Return_Correct_Method_Signature_For_Method_Without_Parameters()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = info.GetMethod("MethodWithoutParameters");

                // When
                var signature = method.GetMethodSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", signature.DeclaringType.Namespace.Name);
                Assert.Equal("SimpleClass", signature.DeclaringType.Name);
                Assert.Equal("MethodWithoutParameters", signature.Name);
                Assert.Equal(0, signature.Parameters.Count);
            }

            [Fact]
            public void Should_Return_Correct_Method_Signature_For_Method_With_Single_Parameter()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = info.GetMethod("MethodWithSingleParameter");

                // When
                var signature = method.GetMethodSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", signature.DeclaringType.Namespace.Name);
                Assert.Equal("SimpleClass", signature.DeclaringType.Name);
                Assert.Equal("MethodWithSingleParameter", signature.Name);
                Assert.Equal(1, signature.Parameters.Count);
                Assert.Equal("first", signature.Parameters[0].Name);
                Assert.Equal("System", signature.Parameters[0].ParameterType.Namespace.Name);
                Assert.Equal("Int32", signature.Parameters[0].ParameterType.Name);
            }

            [Fact]
            public void Should_Return_Correct_Signature_For_Method_With_Generic_Instance_Parameter()
            {
                // Given
                var info = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = info.GetMethod("GenericMethodWithGenericInstanceParameter");

                // When
                var signature = method.GetMethodSignature(_fixture.UrlResolver);

                // Then
                Assert.Equal("Sparrow.Tests.Data", signature.DeclaringType.Namespace.Name);
                Assert.Equal("SimpleClass", signature.DeclaringType.Name);
                Assert.Equal("GenericMethodWithGenericInstanceParameter", signature.Name);
                Assert.Equal(1, signature.GenericParameters.Count);
                Assert.Equal("T", signature.GenericParameters[0]);
                Assert.Equal(1, signature.Parameters.Count);
                Assert.Equal("first", signature.Parameters[0].Name);
                Assert.Equal("System.Collections.Generic", signature.Parameters[0].ParameterType.Namespace.Name);
                Assert.Equal("IEnumerable", signature.Parameters[0].ParameterType.Name);
                Assert.Equal(1, signature.Parameters[0].ParameterType.GenericParameters.Count);
                Assert.Equal("T", signature.Parameters[0].ParameterType.GenericParameters[0].Name);
            }
        }
    }
}
