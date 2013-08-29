using System.Web;
using System.Web.Mvc;

namespace BootstrapComponents.Components.Images
{
    public static class ImageExtensions
    {
        public static IHtmlString Image(this HtmlHelper html, string src, string alt, Image.Style style, bool responsive = false)
        {
            return new Image(src, alt, style, responsive);
        }
    }
}
