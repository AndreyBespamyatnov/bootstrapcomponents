using System.Security.Policy;
using BootstrapComponents.Common;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Buttons
{
    public class ButtonSettings
    {
        public Size Size { get; set; }
        public bool BlockLevel { get; set; }
        public bool IsDisabled { get; set; }
        public Category Category { get; set; }
        public ButtonTag Tag { get; set; }
        public string LinkUrl { get; set; }

        public ButtonSettings()
        {
            Size = Size.Md;
            Category = Category.Default;
            Tag = ButtonTag.Button;
        }

        public ButtonSettings ExtraSmall() { return SetSize(Size.Xs); }
        public ButtonSettings Small() { return SetSize(Size.Sm); }
        public ButtonSettings Medium() { return SetSize(Size.Md); }
        public ButtonSettings Large() { return SetSize(Size.Lg); }

        public ButtonSettings SetSize(Size size)
        {
            Size = size;
            return this;
        }

        public ButtonSettings Block() { return SetBlockLevel(); }
        public ButtonSettings SetBlockLevel(bool blockLevel = true)
        {
            BlockLevel = blockLevel;
            return this;
        }

        public ButtonSettings Disabled() { return SetDisabled(); }
        public ButtonSettings SetDisabled(bool disabled = true)
        {
            IsDisabled = disabled;
            return this;
        }

        public ButtonSettings Primary() { return SetCategory(Category.Primary); }
        public ButtonSettings Success() { return SetCategory(Category.Success); }
        public ButtonSettings Info() { return SetCategory(Category.Info); }
        public ButtonSettings Warning() { return SetCategory(Category.Warning); }
        public ButtonSettings Danger() { return SetCategory(Category.Danger); }
        public ButtonSettings Inverse() { return SetCategory(Category.Inverse); }
        public ButtonSettings Link() { return SetCategory(Category.Link); }

        public ButtonSettings SetCategory(Category category)
        {
            Category = category;
            return this;
        }

        public ButtonSettings Url(string url) { return SetLinkUrl(url); }
        public ButtonSettings SetLinkUrl(string url)
        {
            LinkUrl = url;
            return this;
        }
        

        public enum ButtonTag { A, Button }
    }
}