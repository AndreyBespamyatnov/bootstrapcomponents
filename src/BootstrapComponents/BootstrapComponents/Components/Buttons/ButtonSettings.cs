using BootstrapComponents.Common;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class ButtonSettings
    {
        public Size Size { get; set; }
        public bool BlockLevel { get; set; }
        public bool Disabled { get; set; }
        public Category Category { get; set; }
        public ButtonTag Tag { get; set; }
        public string Url { get; set; }

        public ButtonSettings()
        {
            Size = Size.Md;
            Category = Category.Default;
            Tag = ButtonTag.Button;
        }

        public void UpdateAttributes(HtmlAttributes attrs)
        {
            attrs["class"] += "btn-" + Category.ToString().ToLower();
            if (Size != Size.Md) attrs["class"] += "btn-" + Size.ToString().ToLower();
            if (BlockLevel) attrs["class"] += "btn-block";
            if (!string.IsNullOrEmpty(Url))
            {
                attrs["href"] = Url;
                Tag = ButtonTag.A;
            }
            if (Tag == ButtonTag.A && string.IsNullOrEmpty(Url)) attrs["href"] = "#";
            if (Disabled) attrs[Tag == ButtonTag.A ? "class" : "disabled"] += "disabled";
        }

        public enum ButtonTag { A, Button }
    }
}