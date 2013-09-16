using System.Web;
using System.Web.Mvc;
using BootstrapComponents.Components.Buttons;
using BootstrapComponents.Components.Navs;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Navbars
{
    public class Navbar : CloseableHtml
    {
        private readonly NavbarSettings _settings;

        public Navbar(ViewContext viewContext, NavbarSettings settings = null) : base(viewContext)
        {
            _settings = settings ?? new NavbarSettings();
            WriteOpening();
        }

        public Navbar(IWriter writer, NavbarSettings settings = null) : base(writer)
        {
            _settings = settings ?? new NavbarSettings();
            WriteOpening();
        }

        private void WriteOpening()
        {
            var navAttrs = new HtmlAttributes(new {@class = "navbar navbar-default", role = "navigation"});
            if (_settings.Fixed == FixedPosition.Top) navAttrs["class"] += "navbar-fixed-top";
            else if (_settings.Fixed == FixedPosition.Bottom) navAttrs["class"] += "navbar-fixed-bottom";
            if (_settings.Inverse) navAttrs["class"] += "navbar-inverse";
            Write("<nav {0}>", navAttrs.ToString());
            if (_settings.UseInnerContainer) Write("<div class=\"container\">");
        }

        protected override string ClosingHtml()
        {
            return _settings.UseInnerContainer ? "</div></nav>" : "</nav>";
        }

        public CloseableHtml Header(bool includeToggle = true)
        {
            var toggle = includeToggle ? "<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-ex1-collapse\">" +
                                            "<span class=\"sr-only\">Toggle navigation</span>" +
                                            "<span class=\"icon-bar\"></span>" +
                                            "<span class=\"icon-bar\"></span>" +
                                            "<span class=\"icon-bar\"></span>" +
                                          "</button>" : "";
            return new BasicCloseableHtml("<div class=\"navbar-header\">"+toggle, "</div>", _writer);
        }

        public CloseableHtml Collapsible()
        {
            return new BasicCloseableHtml("<div class=\"collapse navbar-collapse navbar-ex1-collapse\">", "</div>", _writer);
        }

        public Button Button(string text, ButtonSettings settings = null)
        {
            var button = new Button(text, settings);
            button.Attrs["class"] += "navbar-btn";
            return button;
        }

        public IHtmlString Text(string text)
        {
            var t = new GenericInnerHtmlContainer("p", text, false);
            t.Attrs["class"] += "navbar-text";
            return t;
        }

        public IHtmlString Brand(string text, string url = null)
        {
            var t = new GenericInnerHtmlContainer(string.IsNullOrEmpty(url) ? "p" : "a", text, false);
            t.Attrs["class"] += "navbar-brand";
            if (!string.IsNullOrEmpty(url)) t.Attrs["href"] = url;
            return t;
        }

        public Nav Nav(string activeIdentifier, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Navbar;
            return new Nav(_writer, activeIdentifier, settings);
        }

        public Nav Nav(NavSettings settings = null)
        {
            return Nav(null, settings);
        }

        public Nav RightNav(string activeIdentifier, NavSettings settings = null)
        {
            settings = settings ?? new NavSettings();
            settings.Style = NavStyle.Navbar;
            settings.NavbarRight = true;
            return new Nav(_writer, activeIdentifier, settings);
        }

        public Nav RightNav(NavSettings settings = null)
        {
            return RightNav(null, settings);
        }

        public static NavbarSettings Settings { get { return new NavbarSettings(); } }
    }
}
