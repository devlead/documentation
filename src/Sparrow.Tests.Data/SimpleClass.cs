using System.Collections.Generic;

namespace Sparrow.Tests.Data
{
    /// <summary>
    /// T:Sparrow.Core.Tests.Data.SimpleClass
    /// </summary>
    public class SimpleClass : IInterface
    {
        /// <summary>
        /// P:Sparrow.Core.Tests.Data.SimpleClass.Property
        /// </summary>
        /// <value>The property value.</value>
        public int Property
        {
            get { return 0; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClass"/> class.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.#ctor
        /// </summary>
        public SimpleClass()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClass"/> class.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.#ctor(System.Int32)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public SimpleClass(int first)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleClass"/> class.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.#ctor(System.Int32,System.String)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public SimpleClass(int first, string second)
        {
        }

        /// <summary>
        /// A method with no parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.MethodWithoutParameters
        /// </summary>
        public void MethodWithoutParameters()
        {
        }

        /// <summary>
        /// A method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.MethodWithSingleParameter(System.Int32)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithSingleParameter(int first)
        {
        }

        /// <summary>
        /// A method with an out parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.MethodWithOutParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithOutParameter(out int first)
        {
            first = 0;
        }

        /// <summary>
        /// A method with a ref parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.MethodWithRefParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithRefParameter(ref int first)
        {
        }

        /// <summary>
        /// A method the with multiple parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.MethodWithMultipleParameters(System.Int32,System.String)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void MethodWithMultipleParameters(int first, string second)
        {
        }

        /// <summary>
        /// A generic method with no parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithoutParameters``1
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        public void GenericMethodWithoutParameters<T>()
        {            
        }

        /// <summary>
        /// A generic method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithSingleArgument``1(System.Int32)
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithSingleParameter<T>(int first)
        {
        }

        /// <summary>
        /// A generic method with multiple parameters where one is generic.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithMultipleParameterTypesWhereOneIsGeneric``1(System.Int32,``0)
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void GenericMethodWithMultipleParameterTypesWhereOneIsGeneric<T>(int first, T second)
        {
        }

        /// <summary>
        /// A generic method with multiple (same) generic parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithMultipleSameGenericParameterTypes``1(``0,``0)
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void GenericMethodWithMultipleSameGenericParameterTypes<T>(T first, T second)
        {
        }

        /// <summary>
        /// A generic method with a generic instance parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithGenericInstanceParameter``1(System.Collections.Generic.IEnumerable{``0})
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithGenericInstanceParameter<T>(IEnumerable<T> first)
        {
        }

        /// <summary>
        /// A generic method with a nested generic instance parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleClass.GenericMethodWithGenericInstanceParameter``2(System.Collections.Generic.IDictionary{``0,System.Collections.Generic.IEnumerable{``1}})
        /// </summary>
        /// <typeparam name="T">The first generic parameter type.</typeparam>
        /// <typeparam name="V">The second generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithNestedGenericInstanceParameter<T,V>(IDictionary<T, IEnumerable<V>> first)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SimpleClass" /> to <see cref="System.Int32" />.
        /// </summary>
        /// <param name="x">The instance to convert.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator int(SimpleClass x)
        {
            return 0;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SimpleClass"/> to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="x">The instance to convert.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator long(SimpleClass x)
        {
            return 0;
        }
    }
}
