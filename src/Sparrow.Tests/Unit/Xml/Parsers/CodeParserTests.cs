using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Sparrow.Xml.Parsers;
using Xunit;

namespace Sparrow.Tests.Unit.Xml.Parsers
{
    public sealed class CodeParserTests
    {
        public sealed class TheCanParseMethod
        {
            [Fact]
            public void Should_Return_True_For_Correct_Element()
            {
                // Given
                var parser = new CodeParser();
                var node = "<code>Hello World</code>".CreateXmlNode();

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.True(result);
            }

            [Fact]
            public void Should_Return_False_For_Incorrect_Element()
            {
                // Given
                var parser = new CodeParser();
                var node = "<test>Hello World</test>".CreateXmlNode();

                // When
                var result = parser.CanParse(node);

                // Then
                Assert.False(result);
            }
        }

        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Return_CodeComment()
            {
                // Given
                var commentParser = new CommentParser();
                var nodeParser = new CodeParser();
                var node = "<code>Hello World</code>".CreateXmlNode();

                // When
                var result = nodeParser.Parse(commentParser, node);

                // Then
                Assert.Equal("Hello World", result.Code);
            }
        }
    }
}
