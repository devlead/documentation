using System.Xml;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class WhitespaceParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Xml_Text()
            {
                // Given
                var parser = new WhitespaceParser();
                var node = new XmlDocument().CreateWhitespace("\t \t");

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.True(result);
            }
        }

        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Return_InlineTextComment()
            {
                // Given
                var commentParser = new CommentParser();
                var nodeParser = new WhitespaceParser();
                var node = new XmlDocument().CreateTextNode("\t \t");

                // When
                var result = nodeParser.Parse(commentParser, node);

                // Then
                Assert.Equal("\t \t", result.Text);
            }
        }
    }
}
