using System;
using System.Linq;
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

        public static Button Button(this HtmlHelper html, string text, string url)
        {
            return new Button(text, new ButtonSettings { LinkUrl = url });
        }

        public static Button Button(this HtmlHelper html, string text, string url, ButtonSettings buttonSettings)
        {
            buttonSettings.LinkUrl = url;
            return new Button(text, buttonSettings);
        }

        public static ButtonGroup ButtonGroup(this HtmlHelper html, params Button[] buttons)
        {
            return new ButtonGroup(buttons);
        }

        public static ButtonGroup ButtonGroup(this HtmlHelper html, params Func<HtmlHelper, Button>[] buttons)
        {
            return new ButtonGroup(buttons.Select(btn => btn(html)).ToArray());
        }

        public static Button Submit(this HtmlHelper html, string text = "Submit", ButtonSettings buttonSettings = null)
        {
            return new Button(text, buttonSettings, new{type="Submit"});
        }
    }
}
