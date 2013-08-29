using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BootstrapComponents.Core
{
    public class HtmlAttributes
    {
        private readonly IDictionary<string, HtmlAttribute> _attributes = new Dictionary<string, HtmlAttribute>();

        public HtmlAttributes() { }

        public HtmlAttributes(IEnumerable<KeyValuePair<string, object>> htmlAttributes)
        {
            if (htmlAttributes == null) return;
            _attributes = htmlAttributes.ToDictionary(x => x.Key, x => new HtmlAttribute(x.Value));
        }

        public HtmlAttributes(object htmlAttributes)
        {
            if (htmlAttributes == null) return;
            var dict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            _attributes = dict.ToDictionary(x => x.Key, x => new HtmlAttribute(x.Value));
        }

        public HtmlAttribute this[string attribute]
        {
            get { return _attributes.ContainsKey(attribute) ? _attributes[attribute].ToString() : null; }
            set
            {
                if (_attributes.ContainsKey(attribute))
                    _attributes[attribute] = value;
                else
                    _attributes.Add(attribute, value);
            }
        }

        public override string ToString()
        {
            return string.Join(" ", _attributes.OrderBy(x => x.Key).Select(x => string.Format("{0}=\"{1}\"", x.Key, x.Value)));
        }

        public HtmlAttributes Clone()
        {
            return new HtmlAttributes(_attributes.ToDictionary(x => x.Key, x => new HtmlAttributes(x.Value)));
        }

        public bool Any(Func<KeyValuePair<string, HtmlAttribute>, bool> func = null)
        {
            return func == null ? _attributes.Any() : _attributes.Any(func);
        }
    }
}