namespace Sparrow.Tests.Data
{
    /// <summary>
    /// T:Sparrow.Core.Tests.Data.SimpleStruct
    /// </summary>
    public struct SimpleStruct
    {
        /// <summary>
        /// A method with no parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.MethodWithoutParameters
        /// </summary>
        public void MethodWithoutParameters()
        {
        }

        /// <summary>
        /// A method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.MethodWithSingleParameter(System.Int32)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithSingleParameter(int first)
        {
        }

        /// <summary>
        /// A method with an out parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.MethodWithOutParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithOutParameter(out int first)
        {
            first = 0;
        }

        /// <summary>
        /// A method with a ref parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.MethodWithRefParameter(System.Int32@)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        public void MethodWithRefParameter(ref int first)
        {
        }

        /// <summary>
        /// A method the with multiple parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.MethodWithMultipleParameters(System.Int32,System.String)
        /// </summary>
        /// <param name="first">The first parameter.</param>
        /// <param name="second">The second parameter.</param>
        public void MethodWithMultipleParameters(int first, string second)
        {
        }

        /// <summary>
        /// A generic method with no parameters.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.GenericMethodWithoutParameters``1
        /// </summary>
        /// <typeparam name="T">The generic parameter type.</typeparam>
        public void GenericMethodWithoutParameters<T>()
        {
        }

        /// <summary>
        /// A generic method with a single parameter.
        /// M:Sparrow.Core.Tests.Data.SimpleStruct.GenericMethodWithSingleArgument``1(System.Int32)
        /// </summary>
        /// <typeparam name="T">Tge generic parameter type.</typeparam>
        /// <param name="first">The first parameter.</param>
        public void GenericMethodWithSingleParameter<T>(int first)
        {
        }
    }
}
