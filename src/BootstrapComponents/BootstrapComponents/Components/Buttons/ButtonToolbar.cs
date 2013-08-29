using System.Linq;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class ButtonToolbar : HtmlContainer
    {
        private readonly ButtonGroup[] _buttonGroups;

        public ButtonToolbar(params ButtonGroup[] buttonGroups)
            : base("div", false)
        {
            _buttonGroups = buttonGroups;
            Attrs["class"] = "btn-toolbar";
        }

        public override string BuildInnerHtml()
        {
            return string.Join("", _buttonGroups.Select(x => x.ToHtmlString()));
        }
    }
}