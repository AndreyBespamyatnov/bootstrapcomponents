using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BootstrapComponents.Core
{
    public abstract class HtmlContainer : IHtmlString
    {
        public bool SelfClosing { get; set; }
        public string HtmlTag { get; set; }
        public HtmlAttributes Attrs = new HtmlAttributes();

        protected HtmlContainer(string tag, bool selfClosing = true)
        {
            HtmlTag = tag;
            SelfClosing = selfClosing;
            InnerHtml = "";
        }

        protected virtual string StartHtml()
        {
            return string.Format("<{0}{1}>", HtmlTag, Attrs.Any() ? " " + Attrs : "");
        }

        public string InnerHtml { get; set; }
        public virtual string BuildInnerHtml()
        {
            return InnerHtml;
        }

        protected virtual string EndHtml()
        {
            return string.Format("</{0}>", HtmlTag);
        }

        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(string html)
        {
            InnerHtml += html;
        }
        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(IHtmlString html)
        {
            InnerHtml += html;
        }

        public virtual string ToHtmlString()
        {
            if (SelfClosing && string.IsNullOrEmpty(BuildInnerHtml()))
                return string.Format("<{0}{1} />", HtmlTag, Attrs.Any() ? " " + Attrs : "");
            return StartHtml() + BuildInnerHtml() + EndHtml();
        }

        /// <summary>
        /// Float an element left with a class
        /// </summary>
        /// <returns></returns>
        public HtmlContainer PullRight()
        {
            return WithClass("pull-right");
        }

        /// <summary>
        /// Float an element right with a class
        /// </summary>
        /// <returns></returns>
        public HtmlContainer PullLeft()
        {
            return WithClass("pull-left");
        }

        /// <summary>
        /// Clear the float on any element
        /// </summary>
        /// <returns></returns>
        public HtmlContainer Clearfix()
        {
            return WithClass("clearfix");
        }

        /// <summary>
        /// Hide an element to all users except screen readers
        /// </summary>
        /// <returns></returns>
        public HtmlContainer SrOnly()
        {
            return WithClass("sr-only");
        }

        /// <summary>
        /// Makes element visible only at the specified size(s)
        /// </summary>
        /// <param name="sizes">Extra Small (phones): xs, Small (tablets): x, Medium (desktops > 992px): md, Large (desktops > 1200px): lg</param>
        /// <returns></returns>
        public HtmlContainer Visible(params string[] sizes)
        {
            foreach (var size in sizes) Attrs["class"] += "visible-" + size;
            return this;
        }

        /// <summary>
        /// Hides element at the specified size(s)
        /// </summary>
        /// <param name="sizes">Extra Small (phones): xs, Small (tablets): x, Medium (desktops > 992px): md, Large (desktops > 1200px): lg</param>
        /// <returns></returns>
        public HtmlContainer Hidden(params string[] sizes)
        {
            foreach (var size in sizes) Attrs["class"] += "hidden-" + size;
            return this;
        }

        private HtmlContainer WithClass(string @class)
        {
            Attrs["class"] += @class;
            return this;
        }
    }
}
