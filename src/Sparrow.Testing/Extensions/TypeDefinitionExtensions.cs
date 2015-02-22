using System;
using System.Linq;
using Mono.Cecil;

namespace Sparrow.Testing.Extensions
{
    public static class TypeDefinitionExtensions
    {
        public static MethodDefinition GetConstructor(this TypeDefinition type, params Type[] types)
        {
            foreach (var method in type.Methods)
            {
                if (method.IsConstructor)
                {
                    if (method.Parameters.Count == types.Length)
                    {
                        if (types.Length == 0)
                        {
                            return method;
                        }

                        var isMatch = true;
                        for (var index = 0; index < types.Length; index++)
                        {
                            if (method.Parameters[index].ParameterType.FullName != types[index].FullName)
                            {
                                isMatch = false;
                                break;
                            }
                        }
                        if (isMatch)
                        {
                            return method;
                        }
                    }
                }
            }
            var parameters = string.Join(",", types.Select(x => x.FullName));
            var message = string.Format("The constructor '{0}({1})' was not found.", type.Name, parameters);
            throw new SparrowTestingException(message);
        }

        public static MethodDefinition GetMethod(this TypeDefinition type, string name)
        {
            var method = type.Methods.FirstOrDefault(x => x.Name == name);
            if (method == null)
            {
                var message = string.Format("Could not find method '{0}.{1}'", type.FullName, name);
                throw new SparrowTestingException(message);
            }
            return method;
        }

        public static MethodDefinition GetConversionOperator(this TypeDefinition type, Type returnValue, bool isImplicit)
        {
            var methodName = isImplicit ? "op_Implicit" : "op_Explicit";
            var methods = type.Methods.Where(x => x.IsSpecialName && x.Name.StartsWith(methodName));
            foreach (var method in methods)
            {
                if (method.ReturnType.FullName == returnValue.FullName)
                {
                    return method;
                }
            }
            var message = string.Format("Could not find conversion operator from '{0}' to '{1}'", type.FullName, returnValue.FullName);
            throw new SparrowTestingException(message);
        }

        public static PropertyDefinition GetProperty(this TypeDefinition type, string name)
        {
            var property = type.Properties.FirstOrDefault(x => x.Name == name);
            if (property == null)
            {
                var message = string.Format("Could not find property '{0}.{1}'", type.FullName, name);
                throw new SparrowTestingException(message);
            }
            return property;
        }

        public static FieldDefinition GetField(this TypeDefinition type, string name)
        {
            var property = type.Fields.FirstOrDefault(x => x.Name == name);
            if (property == null)
            {
                var message = string.Format("Could not find field '{0}.{1}'", type.FullName, name);
                throw new SparrowTestingException(message);
            }
            return property;
        }
    }
}
