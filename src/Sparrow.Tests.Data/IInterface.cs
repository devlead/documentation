using System.Collections.Generic;

namespace Sparrow.Tests.Data
{
    /// <summary>
    /// T:Sparrow.Core.Tests.Data.IInterface
    /// </summary>
    public interface IInterface
    {
        /// <summary>
        /// P:Sparrow.Core.Tests.Data.IInterface.Property
        /// </summary>
        /// <value>The property value.</value>
        int Property { get; }

        /// <summary>
        /// A method with no parameters.
        /// </summary>
        void MethodWithoutParameters();

        /// <summary>
        /// A method with a single parameter.
        /// </summary>
        /// <param name="first">The first parameter.</param>
        void MethodWithSingleParameter(int first);

        /// <summary>
        /// A method with an out parameter.
        /// </summary>
        /// <param name="first">The first parameter.</param>
        void MethodWithOutParameter(out int first);

        /// <summary>
        /// A method with a ref parameter.
        /// </summary>
        /// <param name="first">The first parameter.</param>
        void MethodWithRefParameter(ref int first);

        /// <summary>
        /// A method the with multiple parameters.
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        void MethodWithMultipleParameters(int first, string second);

        /// <summary>
        /// A generic method with no parameters.
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        void GenericMethodWithoutParameters<T>();

        /// <summary>
        /// A generic method with a single parameter.
        /// </summary>
        /// <typeparam name="T">Tge generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        void GenericMethodWithSingleParameter<T>(int first);

        /// <summary>
        /// A generic method with multiple parameters where one is generic.
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        void GenericMethodWithMultipleParameterTypesWhereOneIsGeneric<T>(int first, T second);

        /// <summary>
        /// A generic method with multiple (same) generic parameters.
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        void GenericMethodWithMultipleSameGenericParameterTypes<T>(T first, T second);

        /// <summary>
        /// Methods the type of the with generic parameter.
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        void GenericMethodWithGenericInstanceParameter<T>(IEnumerable<T> first);
    }
}