using System.Web.Mvc;

namespace BootstrapComponents.Components.Navs
{
    public static class NavExtensions
    {
        public static Nav Pills(this HtmlHelper html, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Pills;
            return new Nav(html.ViewContext, settings);
        }

        public static Nav Pills(this HtmlHelper html, string activeIdentifier, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Pills;
            return new Nav(html.ViewContext, activeIdentifier, settings);
        }

        public static Nav Tabs(this HtmlHelper html, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Tabs;
            return new Nav(html.ViewContext, settings);
        }

        public static Nav Tabs(this HtmlHelper html, string activeIdentifier, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Tabs;
            return new Nav(html.ViewContext, activeIdentifier, settings);
        }
    }
}