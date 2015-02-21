using System.Collections.Generic;
using System.Linq;
using RazorEngine.Text;

namespace Docs.Compiler.Core.Templating
{
    public sealed class TemplateHelper
    {
        private readonly TemplateViewModel _viewModel;

        public TemplateHelper(TemplateViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public IEncodedString MakeAnchorIdentifier(string identifier)
        {
            return new RawString(identifier.Replace(" ", string.Empty)
                .ToLowerInvariant());
        }

        public IEncodedString BreadCrumb()
        {
            var builder = new EncodedStringBuilder();

            var stack = new Stack<IEncodedString>();
            stack.Push(new RawString(_viewModel.Title));
            var current = _viewModel.Parent;
            while (current != null && current.Id != "root")
            {
                stack.Push(Link(current));
                current = current.Parent;
            }

            if (stack.Count <= 1)
            {
                return new RawString(string.Empty);
            }

            builder.AppendRaw("<ol class=\"breadcrumb\">");
            foreach (var part in stack)
            {
                builder.AppendRaw("<li>");
                builder.AppendRaw(part.ToString());
                builder.AppendRaw("</li>");
            }
            builder.AppendRaw("</ol>");

            return builder.ToRaw();
        }

        public IEncodedString Link(Content link)
        {
            var stack = new Stack<string>();
            stack.Push(link.UrlPart);
            var current = link.Parent;
            while (current != null && current.Id != "root")
            {
                stack.Push(current.UrlPart);      
                current = current.Parent;
            }

            var url = string.Concat("/", string.Join("/", stack), "/");

            var builder = new EncodedStringBuilder();
            builder.AppendRaw(@"<a href=""{0}"">", url);
            builder.AppendEncoded(link.MenuTitle);
            builder.AppendRaw("</a>");

            return builder.ForceRaw();
        }

        public IEncodedString Tree(Content tree, string currentId)
        {
            var node = tree.Find(currentId);
            var expandedNodes = node.GetParents();

            var builder = new EncodedStringBuilder();
            builder.AppendRawLine(@"<ul class=""nav nav-sidebar"">");
            foreach (var child in tree.Children)
            {
                Tree(builder, child, currentId, expandedNodes, 0);
            }
            builder.AppendRawLine("</ul>");
            return builder.ForceRaw();
        }

        private static void Tree(EncodedStringBuilder builder, Content node, string currentId, IReadOnlyList<Content> expanded, int depth)
        {
            var active = false;
            var isExpanded = expanded.Any(x => x.Id == node.Id);

            if (node.Id == currentId || isExpanded && depth == 0)
            {
                active = true;
            }

            if (depth == 0)
            {
                builder.AppendRaw(active ? @"<li class=""active"">" : @"<li>");
            }
            else
            {
                builder.AppendRaw(@"<li class=""list-unstyled"">");  
            }

            if (active && depth > 0)
            {
                builder.AppendRaw(@"<b>");
            }

            var link = node.GetLink();
            if (link == "/index")
            {
                link = "/";
            }

            builder.AppendRaw(@"<a href=""{0}"">", link);
            builder.AppendEncoded(node.MenuTitle);
            builder.AppendRaw(@"</a>");

            if (active && depth > 0)
            {
                builder.AppendRaw(@"</b>");
            }

            if (node.Children.Count > 0)
            {
                if (isExpanded)
                {
                    builder.AppendRawLine("<ul>");
                    depth++;
                    foreach (var child in node.Children)
                    {                        
                        Tree(builder, child, currentId, expanded, depth);                        
                    }
                    builder.AppendRawLine("</ul>");   
                }
            }

            builder.AppendRaw(@"</li>");
        }
    }
}
