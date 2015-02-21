using System;
using Sparrow.Identity;
using Sparrow.Testing.Extensions;
using Sparrow.Tests.Data;
using Sparrow.Tests.Fixtures;
using Xunit;

namespace Sparrow.Tests.Unit.Identity
{
    public sealed class MethodCRefGeneratorTests
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
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.#ctor")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.#ctor")]
            public void Should_Return_Correct_Identity_For_Constructor_Without_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetConstructor();

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.#ctor(System.Int32)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.#ctor(System.Int32)")]
            public void Should_Return_Correct_Identity_For_Constructor_With_Single_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetConstructor(typeof(int));

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.#ctor(System.Int32,System.String)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.#ctor(System.Int32,System.String)")]
            public void Should_Return_Correct_Identity_For_Constructor_With_Multiple_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetConstructor(typeof(int), typeof(string));

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }
            
            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.MethodWithoutParameters")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.MethodWithoutParameters")]
            public void Should_Return_Correct_Identity_For_Method_Without_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("MethodWithoutParameters");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.MethodWithSingleParameter(System.Int32)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.MethodWithSingleParameter(System.Int32)")]
            public void Should_Return_Correct_Identity_For_Method_With_Single_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("MethodWithSingleParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.MethodWithOutParameter(System.Int32@)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.MethodWithOutParameter(System.Int32@)")]
            public void Should_Return_Correct_Name_For_Method_With_Out_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("MethodWithOutParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.MethodWithRefParameter(System.Int32@)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.MethodWithRefParameter(System.Int32@)")]
            public void Should_Return_Correct_Name_For_Method_With_Ref_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("MethodWithRefParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.MethodWithMultipleParameters(System.Int32,System.String)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.MethodWithMultipleParameters(System.Int32,System.String)")]
            public void Should_Return_Correct_Identity_For_Method_With_Multiple_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("MethodWithMultipleParameters");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithoutParameters``1")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithoutParameters``1")]
            public void Should_Return_Correct_Identity_For_Generic_Method_Without_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithoutParameters");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithSingleParameter``1(System.Int32)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithSingleParameter``1(System.Int32)")]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Single_Argument(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithSingleParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithMultipleParameterTypesWhereOneIsGeneric``1(System.Int32,``0)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithMultipleParameterTypesWhereOneIsGeneric``1(System.Int32,``0)")]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Multiple_Arguments_Where_One_Is_Generic(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithMultipleParameterTypesWhereOneIsGeneric");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithMultipleSameGenericParameterTypes``1(``0,``0)")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithMultipleSameGenericParameterTypes``1(``0,``0)")]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Multiple_Same_Generic_Parameters(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithMultipleSameGenericParameterTypes");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);                
            }

            [Fact]
            public void Should_Return_Correct_Identity_For_Method_Referencing_Generic_Type_Parameter()
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(typeof(GenericClass<>));
                var method = definition.GetMethod("GenericMethodReferencingGenericTypeParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal("M:Sparrow.Tests.Data.GenericClass`1.GenericMethodReferencingGenericTypeParameter(`0)", identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithGenericInstanceParameter``1(System.Collections.Generic.IEnumerable{``0})")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithGenericInstanceParameter``1(System.Collections.Generic.IEnumerable{``0})")]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Generic_Instance_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithGenericInstanceParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);
            }

            [Theory]
            [InlineData(typeof(SimpleClass), "M:Sparrow.Tests.Data.SimpleClass.GenericMethodWithNestedGenericInstanceParameter``2(System.Collections.Generic.IDictionary{``0,System.Collections.Generic.IEnumerable{``1}})")]
            [InlineData(typeof(GenericClass<>), "M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithNestedGenericInstanceParameter``2(System.Collections.Generic.IDictionary{``0,System.Collections.Generic.IEnumerable{``1}})")]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Nested_Generic_Instance_Parameter(Type type, string expected)
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(type);
                var method = definition.GetMethod("GenericMethodWithNestedGenericInstanceParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal(expected, identity);                
            }

            [Fact]
            public void Should_Return_Correct_Identity_For_Generic_Method_With_Generic_Instance_Parameter2()
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(typeof(GenericClass<>));
                var method = definition.GetMethod("GenericMethodWithGenericInstanceParameterReferencingGenericTypeParameter");

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal("M:Sparrow.Tests.Data.GenericClass`1.GenericMethodWithGenericInstanceParameterReferencingGenericTypeParameter``1(System.Collections.Generic.IEnumerable{`0})", identity);
            }

            [Fact]
            public void Should_Return_Correct_Identity_For_Implicit_Conversion_Operator()
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = definition.GetConversionOperator(typeof(int), isImplicit: true);

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal("M:Sparrow.Tests.Data.SimpleClass.op_Implicit(Sparrow.Tests.Data.SimpleClass)~System.Int32", identity);
            }

            [Fact]
            public void Should_Return_Correct_Identity_For_Explicit_Conversion_Operator()
            {
                // Given
                var definition = _fixture.GetCecilTypeDefinition(typeof(SimpleClass));
                var method = definition.GetConversionOperator(typeof(long), isImplicit:false);

                // When
                var identity = CRefGenerator.GetMethodCRef(method);

                // Then
                Assert.Equal("M:Sparrow.Tests.Data.SimpleClass.op_Explicit(Sparrow.Tests.Data.SimpleClass)~System.Int64", identity);           
            }
        }
    }
}
