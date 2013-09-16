using System.Web.Mvc;

namespace BootstrapComponents.Components.Navs
{
    public static class NavExtensions
    {
        public static Nav Nav(this HtmlHelper html, NavSettings settings = null)
        {
            return new Nav(html.ViewContext, settings);
        }

        public static Nav Nav(this HtmlHelper html, string activeIdentifier, NavSettings settings = null)
        {
            return new Nav(html.ViewContext, activeIdentifier, settings);
        }
    }
}