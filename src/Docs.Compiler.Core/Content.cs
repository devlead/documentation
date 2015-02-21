using System.Collections.Generic;
using System.Diagnostics;

namespace Docs.Compiler.Core
{
    [DebuggerDisplay("{Id,nq}")]
    public sealed class Content
    {
        private readonly string _id;  
        private readonly string _urlPart;        
        private readonly string _title;
        private readonly string _subTitle;
        private readonly string _menuTitle;
        private readonly string _body;
        private readonly List<Content> _children;

        public Content Parent { get; internal set; }

        public IReadOnlyList<Content> Children
        {
            get { return _children; }
        }

        public string Id
        {
            get { return _id; }
        }

        public string UrlPart
        {
            get { return _urlPart; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string SubTitle
        {
            get { return _subTitle; }
        }

        public bool HasSubTitle
        {
            get { return !string.IsNullOrWhiteSpace(SubTitle); }
        }

        public string MenuTitle
        {
            get { return _menuTitle; }
        }

        public string Body
        {
            get { return _body; }
        }

        public Content(string id, string urlPart, string title, string subTitle, string body)
            : this(id, urlPart, title, subTitle, null, body)
        {
            
        }

        public Content(string id, string urlPart, string title, string subTitle, string menuTitle, string body)
        {
            _id = id;
            _body = body;            
            _urlPart = urlPart;
            _title = title;
            _subTitle = subTitle;
            _menuTitle = menuTitle ?? _title;
            _children = new List<Content>();
        }

        public void AddChild(Content content)
        {
            content.Parent = this;
            _children.Add(content);
        }
    }
}
