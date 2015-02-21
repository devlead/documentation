using System;
using Mono.Cecil;
using Sparrow.Reflection;

// ReSharper disable once CheckNamespace
namespace Sparrow.Models.Documentation
{
    public static class DocumentedMemberExtensions
    {
        public static string GetClassification(this DocumentedMember member)
        {
            var classification = member.Classification;
            if (classification == MemberClassification.Type)
            {
                var type = member as DocumentedType;
                if (type != null)
                {
                    return type.TypeClassification.ToString();
                }
                throw new InvalidOperationException();
            }
            if (classification == MemberClassification.Method)
            {
                var method = member as DocumentedMethod;
                if (method != null)
                {
                    bool isPropertyAlias;
                    if (method.IsCakeAlias(out isPropertyAlias))
                    {
                        return @"Extension Method (Cake Alias)";
                    }
                    return method.MethodClassification.ToString();
                }
                throw new InvalidOperationException();
            }
            return classification.ToString();
        }

        public static bool IsCakeAlias(this DocumentedMember member, out bool isPropertyAlias)
        {
            var method = member as DocumentedMethod;
            if (method != null)
            {
                if(IsCakeAlias(method.Definition, out isPropertyAlias))
                {
                    return true;
                }
            }
            isPropertyAlias = false;
            return false;
        }

        public static bool IsCakeAlias(MethodDefinition method, out bool isPropertyAlias)
        {
            foreach (var attribute in method.CustomAttributes)
            {
                if (attribute.AttributeType != null && (
                    attribute.AttributeType.FullName == "Cake.Core.Annotations.CakeMethodAliasAttribute" ||
                    attribute.AttributeType.FullName == "Cake.Core.Annotations.CakePropertyAliasAttribute"))
                {
                    isPropertyAlias = attribute.AttributeType.FullName == "Cake.Core.Annotations.CakePropertyAliasAttribute";
                    return true;
                }
            }
            isPropertyAlias = false;
            return false;
        }
    }
}
