using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Images
{
    public class Image : NoInnerHtmlContainer
    {
        public Image(string src, string alt, Style style, bool responsive = false) : base("img", true)
        {
            Attrs["src"] = src;
            Attrs["alt"] = alt;
            switch (style)
            {
                case Style.Rounded: Attrs["class"] += "img-rounded"; break;
                case Style.Circle: Attrs["class"] += "img-circle"; break;
                case Style.Thumbnail: Attrs["class"] += "img-thumbnail"; break;
            }
            if (responsive) Attrs["class"] += "img-responsive";
        }

        public enum Style { Rounded, Circle, Thumbnail }
    }
}
