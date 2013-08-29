using BootstrapComponents.Common;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class ButtonGroupSettings
    {
        /// <summary>
        /// Make a set of buttons appear vertically stacked rather than horizontally.
        /// </summary>
        public bool Vertical { get; set; }

        /// <summary>
        /// Make a group of buttons stretch at the same size to span the entire width of its parent. (This only works with a elements as the button doesn't pick up these styles)
        /// </summary>
        public bool Justified { get; set; }

        public Size Size { get; set; }

        public void UpdateAttributes(HtmlAttributes attrs)
        {
            attrs["class"] = Vertical ? "btn-group-vertical" : "btn-group";
            if (Justified) attrs["class"] += "btn-group-justified";
            if (Size != Size.Md) attrs["class"] += "btn-group-" + Size.ToString().ToLower();
        }

        public ButtonGroupSettings()
        {
            Size = Size.Md;
        }
    }
}