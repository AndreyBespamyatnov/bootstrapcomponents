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
        }

        protected virtual string StartHtml()
        {
            return string.Format("<{0}{1}>", HtmlTag, Attrs.Any() ? " " + Attrs : "");
        }

        public abstract string InnerHtml();

        protected virtual string EndHtml()
        {
            return string.Format("</{0}>", HtmlTag);
        }

        public virtual string ToHtmlString()
        {
            var inner = InnerHtml();
            if (SelfClosing && string.IsNullOrEmpty(inner))
            {
                return string.Format("<{0}{1} />", HtmlTag, Attrs.Any() ? " " + Attrs : "");
            }
            return StartHtml() + inner + EndHtml();
        }

        public override string ToString()
        {
            return ToHtmlString();
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
