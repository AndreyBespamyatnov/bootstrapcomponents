using System.Web.Mvc;

namespace BootstrapComponents.Components.Navbars
{
    public class NavbarSettings
    {
        public NavbarSettings()
        {
            UseInnerContainer = true;
            FixedPosition = FixedPosition.None;
        }

        public FixedPosition FixedPosition { get; set; }
        public bool UseInnerContainer { get; set; }

        public NavbarSettings Fixed(FixedPosition fixedPosition = FixedPosition.Top)
        {
            FixedPosition = fixedPosition;
            return this;
        }


    }
    
    public enum FixedPosition { None, Top, Bottom }

    public static class NavbarExtensions
    {
        public static Navbar Navbar(this HtmlHelper html, ViewContext context, NavbarSettings settings = null)
        {
            return new Navbar(context, settings);
        }
    }
}