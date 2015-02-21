using Sparrow.Testing;
using Sparrow.Testing.Extensions;
using Sparrow.Xml;
using Xunit;

namespace Sparrow.Tests.Unit.Xml
{
    public sealed class CommentParserTests
    {
        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Return_Null_If_Node_Cannot_Be_Parsed()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<test>Hello World</test>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.Null(result);
            }

            [Fact]
            public void Should_Preserve_Whitespace()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<value> <see cref=""System.String"" />\t<c>true</c></value>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<value> <see cref=""System.String"" />\t<c>true</c></value>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Code_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<code>Hello World</code>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<code>Hello World</code>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Example_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<example>Hello World</example>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<example>Hello World</example>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Exception_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<exception cref=""SparrowException"">Hello World</exception>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<exception cref=""SparrowException"">Hello World</exception>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_InlineCode_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<c>Hello World</c>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<c>Hello World</c>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_InlineText_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"Hello World".CreateTextNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"Hello World", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Param_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<param name=""test"">Hello World</param>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<param name=""test"">Hello World</param>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_ParamRef_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<paramref name=""test"" />".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<paramref name=""test"" />", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Para_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<para>Hello World</para>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<para>Hello World</para>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Permission_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<permission cref=""System.Security.PermissionSet"">Hello World</permission>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<permission cref=""System.Security.PermissionSet"">Hello World</permission>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Remarks_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<remarks>Hello World</remarks>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<remarks>Hello World</remarks>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Returns_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<returns>Hello World</returns>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<returns>Hello World</returns>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_SeeAlso_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<seealso cref=""System.String""/>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<seealso cref=""System.String"" />", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_See_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<see cref=""System.String"" />".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<see cref=""System.String"" />", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Summary_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<summary>Hello World</summary>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<summary>Hello World</summary>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_TypeParam_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<typeparam name=""T"">Hello World</typeparam>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<typeparam name=""T"">Hello World</typeparam>", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_TypeParamRef_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<typeparamref name=""test"" />".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<typeparamref name=""test"" />", XmlCommentRenderer.Render(result));
            }

            [Fact]
            public void Can_Parse_Value_Comment()
            {
                // Given
                var parser = new CommentParser();
                var node = @"<value>Hello World</value>".CreateXmlNode();

                // When
                var result = parser.Parse(node);

                // Then
                Assert.NotNull(result);
                Assert.Equal(@"<value>Hello World</value>", XmlCommentRenderer.Render(result));
            }
        }
    }
}
