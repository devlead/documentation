using System;
using System.IO;
using System.Linq;
using Docs.Compiler.Core.IO;

namespace Docs.Compiler.Generators.Static
{
    public sealed class StaticPageParser
    {
        public static StaticPage Parse(IFile file)
        {
            using(var stream = file.OpenRead())
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                var result =  Parse(content);

                var extension = file.Path.GetExtension();
                result.Id = file.Path.GetFilename().FullPath.Substring(0, file.Path.GetFilename().FullPath.Length - extension.Length);

                return result;
            }
        }

        public static StaticPage Parse(string content)
        {
            var lines = SplitLines(content);
            if (lines[0] != "---")
            {
                throw new InvalidOperationException("Invalid post format!");
            }

            var post = new StaticPage();
            var index = 1;
            foreach (var rline in lines.Skip(1))
            {
                var line = rline.Trim();
                if (line == "---")
                {
                    break;
                }

                var keyIndex = line.IndexOf(':');
                if (keyIndex == -1)
                {
                    throw new InvalidOperationException("Invalid post format!");
                }

                var key = line.Substring(0, keyIndex);
                if (key == "title")
                {
                    var value = line.Substring(keyIndex + 1, line.Length - keyIndex - 1);
                    post.Title = value.Trim();
                }
                if (key == "sortorder")
                {
                    var value = line.Substring(keyIndex + 1, line.Length - keyIndex - 1);
                    post.SortOrder = int.Parse(value.Trim());
                }
                if (key == "content-type")
                {
                    var value = line.Substring(keyIndex + 1, line.Length - keyIndex - 1);
                    post.ContentType = value.Trim();
                }
                index++;
            }

            post.Content = (index < lines.Length)
                ? string.Join(Environment.NewLine, lines.Skip(index + 1).Take(lines.Length - index))
                : string.Empty;

            return post;
        }

        public static string[] SplitLines(string content)
        {
            content = NormalizeLineEndings(content);
            return content.Split(new[] { "\r\n" }, StringSplitOptions.None);
        }

        public static string NormalizeLineEndings(string value)
        {
            if (value != null)
            {
                value = value.Replace("\r\n", "\n");
                value = value.Replace("\r", string.Empty);
                return value.Replace("\n", "\r\n");
            }
            return string.Empty;
        }
    }
}
