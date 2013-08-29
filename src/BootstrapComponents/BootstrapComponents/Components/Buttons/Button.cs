using BootstrapComponents.Common;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class Button : HtmlContainer
    {
        private readonly string _text;
        private readonly ButtonSettings _settings;

        public Button(string text, ButtonSettings settings = null, object htmlAttributes = null) : base("a", false)
        {
            _text = text;
            _settings = settings ?? new ButtonSettings();
            Attrs = new HtmlAttributes(htmlAttributes);
            Attrs["class"] += "btn";
            _settings.UpdateAttributes(Attrs);
            HtmlTag = _settings.Tag.ToString().ToLower();
            InnerHtml = text;
        }
    }
}
