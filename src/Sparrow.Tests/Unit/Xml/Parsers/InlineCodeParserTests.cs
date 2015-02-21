using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class InlineCodeParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Correct_Element()
            {
                // Given
                var parser = new InlineCodeParser();
                var node = "<c>Hello World</c>".CreateXmlNode();

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.True(result);
            }
        }

        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Return_InlineCodeComment()
            {
                // Given
                var commentParser = new CommentParser();
                var nodeParser = new InlineCodeParser();
                var node = "<c>Hello World</c>".CreateXmlNode();

                // When
                var result = nodeParser.Parse(commentParser, node);

                // Then
                Assert.Equal("Hello World", result.Code);
            }
        }
    }
}
