using System.Xml;
using NSubstitute;
using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class ReturnsParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Correct_Element()
            {
                // Given
                var parser = new ReturnsParser();
                var node = "<returns>Hello World</returns>".CreateXmlNode();

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.True(result);
            }
        }

        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Parse_Content_Recursivly()
            {
                // Given
                var commentParser = Substitute.For<ICommentParser>();
                var nodeParser = new ReturnsParser();
                var node = "<returns>Hello World</returns>".CreateXmlNode();

                // When
                nodeParser.Parse(commentParser, node);

                // Then
                commentParser.Received(1).Parse(Arg.Any<XmlNode>());
            }            
        }
    }
}
