using System;
using System.Collections.Generic;
using Sparrow.Models.Comments;
using Sparrow.Models.Xml;
using Xunit;

namespace Sparrow.Tests.Unit.Models.Xml
{
    public sealed class XmlDocumentationMemberTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_Identity_Is_Null()
            {
                // Given
                var members = new List<Comment>();

                // When
                var result = Record.Exception(() => new XmlDocumentationMember(null, members));

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("cref", ((ArgumentNullException)result).ParamName);
            }

            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("\t")]
            [InlineData("\t ")]
            public void Should_Throw_If_Identity_Is_Empty(string cref)
            {
                // Given
                var members = new List<Comment>();

                // When
                var result = Record.Exception(() => new XmlDocumentationMember(cref, members));

                // Then
                Assert.IsType<InvalidOperationException>(result);
                Assert.Equal("Identity cannot be empty.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Comments_Are_Null()
            {
                // Given, When
                var result = Record.Exception(() => new XmlDocumentationMember("cref", null));

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("comments", ((ArgumentNullException)result).ParamName);

            }
        }
    }
}
