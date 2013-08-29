using System;
using System.Linq;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class ButtonGroup : HtmlContainer
    {
        private readonly ButtonGroupSettings _settings;
        private readonly Button[] _buttons;

        public ButtonGroup(params Button[] buttons) : base("div", false)
        {
            _settings = new ButtonGroupSettings();
            _buttons = buttons;
            _settings.UpdateAttributes(Attrs);
        }

        public ButtonGroup(ButtonGroupSettings settings, params Button[] buttons) : base("div", false)
        {
            _settings = settings;
            _buttons = buttons;
            _settings.UpdateAttributes(Attrs);
        }

        public override string BuildInnerHtml()
        {
            return string.Join("", _buttons.Select(x => x.ToHtmlString()));
        }
    }
}
