using System.Web.Mvc;

namespace BootstrapComponents.Components.Buttons
{
    public static class ButtonExtensions
    {
        public static Button Button(this HtmlHelper html, string text)
        {
            return new Button(text);
        }

        public static Button Button(this HtmlHelper html, string text, ButtonSettings buttonSettings)
        {
            return new Button(text, buttonSettings);
        }
    }
}
