using System.Xml;
using NSubstitute;
using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class RemarksParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Correct_Element()
            {
                // Given
                var parser = new RemarksParser();
                var node = "<remarks>Hello World</remarks>".CreateXmlNode();

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
                var nodeParser = new RemarksParser();
                var node = "<remarks>Hello World</remarks>".CreateXmlNode();

                // When
                nodeParser.Parse(commentParser, node);

                // Then
                commentParser.Received(1).Parse(Arg.Any<XmlNode>());
            }            
        }
    }
}
