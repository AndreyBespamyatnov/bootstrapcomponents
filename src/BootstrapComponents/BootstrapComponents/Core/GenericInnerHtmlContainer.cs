using System.Web;

namespace BootstrapComponents.Core
{
    public class GenericInnerHtmlContainer : HtmlContainer
    {
        protected string _innerHtml;

        public GenericInnerHtmlContainer(string tag, string innerHtml = "", bool selfClosing = true) : base(tag, selfClosing)
        {
            _innerHtml = innerHtml;
        }

        public override string InnerHtml()
        {
            return _innerHtml;
        }
        
        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(string html)
        {
            _innerHtml += html;
        }
        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(IHtmlString html)
        {
            _innerHtml += html;
        }
    }
}