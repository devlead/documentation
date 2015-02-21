using System;
using System.Xml;
using Sparrow.Models;
using Sparrow.Tests.Properties;
using Xunit;

namespace Sparrow.Tests.Unit.Models.Xml
{
    public sealed class XmlDocumentationParserTests
    {
        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Throw_If_Xml_Document_Is_Null()
            {
                // Given
                var parser = new XmlDocumentationParser();

                // When
                var result = Record.Exception(() => parser.Parse(null));

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("documents", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Parse_Members()
            {
                // Given
                var parser = new XmlDocumentationParser();
                var document = new XmlDocument();
                document.PreserveWhitespace = false;
                document.LoadXml(Resources.XML_Simple);

                // When
                var result = parser.Parse(new[] { document });

                // Then
                Assert.Equal(3, result.Members.Count);
            }
        }
    }
}
