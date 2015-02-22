using System;
using Sparrow.Identity;
using Sparrow.Testing.Extensions;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Identity
{
    public sealed class FieldCRefGeneratorTests
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
            [InlineData(typeof(SimpleClass), "F:Sparrow.Tests.Data.SimpleClass.Field")]
            [InlineData(typeof(GenericClass<>), "F:Sparrow.Tests.Data.GenericClass`1.Field")]
            public void Should_Return_Correct_Identity_For_Fields(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var field = definition.GetField("Field");

                // When
                var identity = CRefGenerator.GetFieldCRef(field);

                // Then
                Assert.Equal(expected, identity);
            }
        }
    }
}
