using System;
using System.Collections.Generic;
using System.Text;
using RazorEngine.Text;

namespace Docs.Compiler.Core.Templating
{
    public sealed class EncodedStringBuilder
    {
        private readonly LinkedList<Tuple<string, bool>> _parts;

        public EncodedStringBuilder()
        {
            _parts = new LinkedList<Tuple<string, bool>>();
        }

        public void AppendRaw(IEncodedString raw)
        {
            _parts.AddLast(new Tuple<string, bool>(raw.ToEncodedString(), false));
        }

        public void AppendRaw(string format, params object[] args)
        {
            _parts.AddLast(new Tuple<string, bool>(string.Format(format, args), false));
        }

        public void AppendEncoded(IEncodedString html)
        {
            _parts.AddLast(new Tuple<string, bool>(html.ToEncodedString(), true));
        }

        public void AppendEncoded(string format, params object[] args)
        {
            _parts.AddLast(new Tuple<string, bool>(string.Format(format, args), true));
        }

        public void AppendRawLine(string format, params object[] args)
        {
            _parts.AddLast(new Tuple<string, bool>(
                string.Concat(string.Format(format, args), Environment.NewLine), false));
        }

        public void AppendEncodedLine(string format, params object[] args)
        {
            _parts.AddLast(new Tuple<string, bool>(
                string.Concat(string.Format(format, args), Environment.NewLine), true));
        }

        public IEncodedString ToRaw()
        {
            var builder = new StringBuilder();
            foreach (var part in _parts)
            {
                if (part.Item2)
                {
                    // HTML encoded
                    builder.Append(new HtmlEncodedString(part.Item1));
                }
                else
                {
                    // Raw string
                    builder.Append(new RawString(part.Item1));
                }
            }
            return new RawString(builder.ToString());
        }

        public IEncodedString ForceRaw()
        {
            var builder = new StringBuilder();
            foreach (var part in _parts)
            {
                builder.Append(new RawString(part.Item1));
            }
            return new RawString(builder.ToString());
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var part in _parts)
            {
                if (part.Item2)
                {
                    // HTML encoded
                    builder.Append(new HtmlEncodedString(part.Item1));
                }
                else
                {
                    // Raw string
                    builder.Append(new RawString(part.Item1));
                }
            }
            return builder.ToString();
        }
    }
}
