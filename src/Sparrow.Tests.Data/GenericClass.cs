using System.Collections.Generic;

namespace Sparrow.Tests.Data
{
    /// <summary>
    /// T:Sparrow.Core.Tests.Data.GenericClass`1
    /// </summary>
    public class GenericClass<X> : IInterface
    {
        /// <summary>
        /// P:Sparrow.Core.Tests.Data.GenericClass`1.Property
        /// </summary>
        /// <value>The property value.</value>
        public int Property
        {
            get { return 0; }
        }

        /// <summary>
        /// F:Sparrow.Core.Tests.Data.GenericClass`1.Field
        /// </summary>
        public string Field;

        /// <summary>
        /// Default constructor.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.#ctor
        /// </summary>
        public GenericClass()
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericClass{X}"/> class.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.#ctor(System.Int32)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public GenericClass(int first)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericClass{X}"/> class.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.#ctor(System.Int32,System.String)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public GenericClass(int first, string second)
        {
        }

        /// <summary>
        /// A method with no parameters.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.MethodWithoutParameters
        /// </summary>
        public void MethodWithoutParameters()
        {
        }

        /// <summary>
        /// A method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.MethodWithSingleParameter(System.Int32)
        /// </summary>
        /// <param name="value">The value.</param>
        public void MethodWithSingleParameter(int value)
        {
        }

        /// <summary>
        /// A method with an out parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.MethodWithOutParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithOutParameter(out int first)
        {
            first = 0;
        }

        /// <summary>
        /// A method with a ref parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.MethodWithRefParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithRefParameter(ref int first)
        {
        }

        /// <summary>
        /// A method the with multiple parameters.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.MethodWithMultipleParameters(System.Int32,System.String)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void MethodWithMultipleParameters(int first, string second)
        {
        }

        /// <summary>
        /// A generic method with no parameters.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithoutParameters``1
        /// </summary>
        /// <typeparam name="V">The generic parameter type.</typeparam>
        public void GenericMethodWithoutParameters<V>()
        {
        }

        /// <summary>
        /// A generic method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithSingleArgument``1(System.Int32)
        /// </summary>
        /// <typeparam name="V">Tge generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithSingleParameter<V>(int first)
        {
        }

        /// <summary>
        /// A generic method with multiple parameters where one is generic.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithMultipleParameterTypesWhereOneIsGeneric``1(System.Int32,``0)
        /// </summary>
        /// <typeparam name="V">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void GenericMethodWithMultipleParameterTypesWhereOneIsGeneric<V>(int first, V second)
        {
        }

        /// <summary>
        /// A generic method with multiple (same) generic parameters.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithMultipleSameGenericParameterTypes``1(``0,``0)
        /// </summary>
        /// <typeparam name="V">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void GenericMethodWithMultipleSameGenericParameterTypes<V>(V first, V second)
        {
        }

        /// <summary>
        /// A generic method that references a generic parameter that originates from the type <see cref="GenericClass{X}"/>.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodReferencingGenericTypeParameter(`0)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodReferencingGenericTypeParameter(X first)
        {
        }

        /// <summary>
        /// Methods the type of the with generic parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithGenericInstanceParameter``1(System.Collections.Generic.IEnumerable{``0})
        /// </summary>
        /// <typeparam name="V">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithGenericInstanceParameter<V>(IEnumerable<V> first)
        {
        }

        /// <summary>
        /// A generic method with a nested generic instance parameter.
        /// M:Sparrow.Core.Tests.Data.GenericClass`1.GenericMethodWithGenericInstanceParameter``2(System.Collections.Generic.IDictionary{``0,System.Collections.Generic.IEnumerable{``1}})
        /// </summary>
        /// <typeparam name="T">The first generic parameter type.</typeparam>
        /// <typeparam name="V">The second generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithNestedGenericInstanceParameter<T, V>(IDictionary<T, IEnumerable<V>> first)
        {
        }

        /// <summary>
        /// A generic method with a generic instance parameter that references a generic parameter 
        /// that originates from the type <see cref="GenericClass{T}"/>.
        /// </summary>
        /// <typeparam name="V">The generic parameter type.</typeparam>
        /// <param name="first">The first.</param>
        public void GenericMethodWithGenericInstanceParameterReferencingGenericTypeParameter<V>(IEnumerable<X> first)
        {            
        }

        /// <summary>
        /// Helloes the world.
        /// </summary>
        /// <returns>A thing</returns>
        public GenericClass<int> HelloWorld()
        {
            return null;
        }
    }
}
