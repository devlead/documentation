using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class PermissionParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Correct_Element()
            {
                // Given
                var parser = new PermissionParser();
                var node = @"<permission cref=""member"">Hello World</permission>".CreateXmlNode();

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.True(result);
            }
        }

        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Return_CodeComment()
            {
                // Given
                var commentParser = new CommentParser();
                var nodeParser = new PermissionParser();
                var node = @"<permission cref=""member"">Hello World</permission>".CreateXmlNode();

                // When
                var result = nodeParser.Parse(commentParser, node);

                // Then
                Assert.Equal("member", result.Member);
            }
        }
    }
}
