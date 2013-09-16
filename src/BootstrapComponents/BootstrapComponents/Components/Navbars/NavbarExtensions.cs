using System.Web.Mvc;

namespace BootstrapComponents.Components.Navbars
{
    public static class NavbarExtensions
    {
        public static Navbar Navbar(this HtmlHelper html, NavbarSettings settings = null)
        {
            return new Navbar(html.ViewContext, settings);
        }
    }
}