using System;
using System.Collections.Generic;
using System.Xml;

namespace Sparrow.Testing.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeLineEndings(this string value)
        {
            if (value != null)
            {
                value = value.Replace("\r\n", "\n");
                value = value.Replace("\r", string.Empty);
                return value.Replace("\n", "\r\n");
            }
            return string.Empty;
        }

        public static string[] SplitLines(this string content)
        {
            content = NormalizeLineEndings(content);
            return content.Split(new[] { "\r\n" }, StringSplitOptions.None);
        }

        public static string TrimWhitespace(this string content)
        {
            content = content.NormalizeLineEndings();
            var builder = new List<string>();
            foreach (var line in content.SplitLines())
            {
                var l = line.Trim(' ', '\t');
                if (!string.IsNullOrWhiteSpace(l))
                {
                    builder.Add(l);
                }
            }
            return string.Join("\r\n", builder);
        }

        public static XmlNode CreateTextNode(this string content)
        {
            var document = new XmlDocument { PreserveWhitespace = true };
            return document.CreateTextNode(content);
        }

        public static XmlNode CreateXmlNode(this string content)
        {
            var document = new XmlDocument { PreserveWhitespace = true };
            document.LoadXml(content);
            return document.ChildNodes[0];
        }
    }
}
