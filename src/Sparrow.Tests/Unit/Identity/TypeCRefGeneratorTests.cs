using System;
using Sparrow.Identity;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Identity
{
    public sealed class TypeCRefGeneratorTests
    {
        public sealed class TheGetTypeIdentityMethod : IClassFixture<IdentityGeneratorFixture>
        {
            private readonly IdentityGeneratorFixture _fixture;

            public TheGetTypeIdentityMethod(IdentityGeneratorFixture fixture)
            {
                _fixture = fixture;
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "T:Sparrow.Tests.Data.SimpleClass")]
            [InlineData(typeof(UnsafeClass), "T:Sparrow.Tests.Data.UnsafeClass")]
            [InlineData(typeof(GenericClass<>), "T:Sparrow.Tests.Data.GenericClass`1")]
            [InlineData(typeof(GenericClass<int>), "T:Sparrow.Tests.Data.GenericClass`1")]
            [InlineData(typeof(SimpleStruct), "T:Sparrow.Tests.Data.SimpleStruct")]
            [InlineData(typeof(IInterface), "T:Sparrow.Tests.Data.IInterface")]
            public void Should_Return_Correct_Name_For_Type(Type type, string expected)
            {
                // Given
                var typeDefinition = _fixture.GetCecilTypeDefinition(type);

                // When
                var result = CRefGenerator.GetTypeCRef(typeDefinition);

                // Then
                Assert.Equal(expected, result);
            }
        }
    }
}
