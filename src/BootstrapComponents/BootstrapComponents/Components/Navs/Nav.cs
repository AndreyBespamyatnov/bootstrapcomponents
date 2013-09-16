using System.Web;
using System.Web.Mvc;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Navs
{
    public class Nav : CloseableHtml
    {
        private readonly string _activeIdentifier;
        private readonly NavSettings _settings;

        public Nav(ViewContext viewContext, NavSettings settings = null) : base(viewContext)
        {
            _settings = settings ?? new NavSettings();
            WriteOpening();
        }

        public Nav(ViewContext viewContext, string activeIdentifier, NavSettings settings = null) : base(viewContext)
        {
            _activeIdentifier = activeIdentifier;
            _settings = settings ?? new NavSettings();
            WriteOpening();
        }

        public Nav(IWriter writer, NavSettings settings = null) : base(writer)
        {
            _settings = settings ?? new NavSettings();
            WriteOpening();
        }

        public Nav(IWriter writer, string activeIdentifier, NavSettings settings = null) : base(writer)
        {
            _activeIdentifier = activeIdentifier;
            _settings = settings ?? new NavSettings();
            WriteOpening();
        }

        private void WriteOpening()
        {
            var navAttrs = new HtmlAttributes(new { @class = "nav" });
            if (_settings.Style == NavStyle.Navbar) navAttrs["class"] += "navbar-nav";
            else navAttrs["class"] += "nav-" + _settings.Style.ToString().ToLower();
            if (_settings.Stacked) navAttrs["class"] += "nav-stacked";
            if (_settings.Justified) navAttrs["class"] += "nav-justified";
            if (_settings.NavbarRight) navAttrs["class"] += "navbar-right";
            Write("<ul {0}>", navAttrs.ToString());
        }

        public IHtmlString Link(string text, string url, string identifier, object liHtmlAttrs = null, object aHtmlAttrs = null)
        {
            var a = new GenericInnerHtmlContainer("a", text, false) { Attrs = new HtmlAttributes(aHtmlAttrs) };
            a.Attrs["href"] = url;
            var li = new GenericInnerHtmlContainer("li", a.ToHtmlString(), false) { Attrs = new HtmlAttributes(liHtmlAttrs) };
            if (!string.IsNullOrEmpty(_activeIdentifier))
            {
                var id = string.IsNullOrEmpty(identifier) ? text : identifier;
                if (_activeIdentifier == id) li.Attrs["class"] += "active";
            }
            return li;
        }

        public IHtmlString Link(string text, string url, object liHtmlAttrs = null, object aHtmlAttrs = null)
        {
            return Link(text, url, null, liHtmlAttrs, aHtmlAttrs);
        }

        protected override string ClosingHtml()
        {
            return "</ul>";
        }

        public static NavSettings Settings { get { return new NavSettings(); } }
    }
}
