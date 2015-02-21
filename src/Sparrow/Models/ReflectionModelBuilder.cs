using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Sparrow.Models.Reflection;

namespace Sparrow.Models
{
    internal static class ReflectionModelBuilder
    {
        public static ReflectionModel Build(IEnumerable<AssemblyDefinition> assemblies)
        {
            var result = new List<IAssemblyInfo>();
            foreach (var assembly in assemblies)
            {
                result.Add(Build(assembly));
            }
            return new ReflectionModel(result);
        }

        private static IAssemblyInfo Build(AssemblyDefinition assembly)
        {
            var types = new List<ITypeInfo>();
            foreach (var module in assembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    if (type.IsSpecialName)
                    {
                        continue;
                    }
                    if (type.Name.StartsWith("_"))
                    {
                        continue;
                    }
                    if (!type.IsPublic)
                    {
                        continue;
                    }
                    types.Add(Build(type));
                }
            }
            return new AssemblyInfo(assembly, types);
        }

        private static ITypeInfo Build(TypeDefinition type)
        {
            // Add methods.
            var methods = new List<IMethodInfo>();
            var methodDefinitions = type.Methods.Where(x => x.IsPublic || x.IsFamily || x.IsFamilyOrAssembly);
            foreach (var method in methodDefinitions)
            {
                if (!(method.IsGetter || method.IsSetter))
                {
                    methods.Add(Build(method));
                }
            }

            // Add properties.
            var properties = new List<IPropertyInfo>();
            var propertyDefinitions = type.Properties;
            foreach (var property in propertyDefinitions)
            {
                properties.Add(Build(property));
            }

            return new TypeInfo(type, methods, properties);
        }

        private static IMethodInfo Build(MethodDefinition method)
        {
            return new MethodInfo(method);
        }

        private static IPropertyInfo Build(PropertyDefinition property)
        {
            return new PropertyInfo(property);
        }
    }
}