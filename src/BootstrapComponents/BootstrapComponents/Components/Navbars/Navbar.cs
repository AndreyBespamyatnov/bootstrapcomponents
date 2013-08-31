using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
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

        public void WriteOpening()
        {
            var navAttrs = new HtmlAttributes(new {@class = "navbar navbar-default", role = "navigation"});
            if (_settings.FixedPosition == FixedPosition.Top) navAttrs["class"] += "navbar-fixed-top";
            else if (_settings.FixedPosition == FixedPosition.Bottom) navAttrs["class"] += "navbar-fixed-bottom";

            Write("<nav {0}>", navAttrs.ToString());
            if (_settings.UseInnerContainer) Write("<div class=\"container\">");
        }

        public override string ClosingHtml()
        {
            return _settings.UseInnerContainer ? "</div></nav>" : "</nav>";
        }

        public static NavbarSettings Settings { get { return new NavbarSettings(); } }
    }
}
