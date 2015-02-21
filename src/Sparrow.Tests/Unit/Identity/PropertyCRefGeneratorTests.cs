using System;
using Sparrow.Identity;
using Sparrow.Testing.Extensions;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Identity
{
    public sealed class PropertyCRefGeneratorTests
    {
        public sealed class TheGetIdentityMethod : IClassFixture<IdentityGeneratorFixture>
        {
            #region Fixture Initialization

            private readonly IdentityGeneratorFixture _fixture;

            public TheGetIdentityMethod(IdentityGeneratorFixture fixture)
            {
                _fixture = fixture;
            }

            #endregion

            [Theory]
            [InlineData(typeof(SimpleClass), "P:Sparrow.Tests.Data.SimpleClass.Property")]
            [InlineData(typeof(GenericClass<>), "P:Sparrow.Tests.Data.GenericClass`1.Property")]
            public void Should_Return_Correct_Identity_For_Properties(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var property = definition.GetProperty("Property");

                // When
                var identity = CRefGenerator.GetProprtyCRef(property);

                // Then
                Assert.Equal(expected, identity);
            }
        }
    }
}
