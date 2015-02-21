using System.Collections.Generic;

namespace Docs.Compiler.Core
{
    public static class ContentExtensions
    {
        public static string GetLink(this Content content)
        {
            var stack = new Stack<string>();
            stack.Push(content.UrlPart);
            var current = content.Parent;
            while (current != null)
            {
                stack.Push(current.UrlPart);
                current = current.Parent;
            }
            return string.Join("/", stack);
        }

        public static Content Find(this Content content, string id)
        {
            if (content.Id == id)
            {
                return content;
            }
            foreach (var child in content.Children)
            {
                var result = Find(child, id);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public static IReadOnlyList<Content> GetParents(this Content content, bool includeSelf = true)
        {
            var result = new List<Content>();
            if (includeSelf)
            {
                result.Add(content);
            }
            var parent = content.Parent;
            while (parent != null)
            {
                result.Add(parent);
                parent = parent.Parent;
            }
            return result;
        }
    }
}
