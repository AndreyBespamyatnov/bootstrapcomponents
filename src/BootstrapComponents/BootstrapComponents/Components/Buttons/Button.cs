using BootstrapComponents.Common;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class Button : GenericInnerHtmlContainer
    {
        private readonly ButtonSettings _settings;

        public Button(string text, ButtonSettings settings = null, object htmlAttributes = null) : base("a", text, false)
        {
            _settings = settings ?? new ButtonSettings();
            Attrs = new HtmlAttributes(htmlAttributes);
            Attrs["class"] += "btn";

            Attrs["class"] += "btn-" + _settings.Category.ToString().ToLower();
            if (_settings.Size != Size.Md) Attrs["class"] += "btn-" + _settings.Size.ToString().ToLower();
            if (_settings.BlockLevel) Attrs["class"] += "btn-block";
            if (!string.IsNullOrEmpty(_settings.LinkUrl))
            {
                Attrs["href"] = _settings.LinkUrl;
                _settings.Tag = ButtonSettings.ButtonTag.A;
            }
            if (_settings.Tag == ButtonSettings.ButtonTag.A && string.IsNullOrEmpty(_settings.LinkUrl)) Attrs["href"] = "#";
            if (_settings.IsDisabled) Attrs[_settings.Tag == ButtonSettings.ButtonTag.A ? "class" : "disabled"] += "disabled";

            HtmlTag = _settings.Tag.ToString().ToLower();
        }



        public static ButtonSettings Settings
        {
            get { return new ButtonSettings(); }
        }
    }
}
