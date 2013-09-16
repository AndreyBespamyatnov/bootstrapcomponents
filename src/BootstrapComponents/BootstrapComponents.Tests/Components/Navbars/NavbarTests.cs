using System.Text;
using BootstrapComponents.Components.Navbars;
using BootstrapComponents.Tests.Core;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Navbars
{
    [TestFixture]
    public class NavbarTests
    {
        [Test]
        public void BasicNavbar()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\"></div></nav>", output.ToString());
        }

        [Test]
        public void NavbarFixedToTop()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer, Navbar.Settings.FixedTop()))
            {

            }
            Assert.AreEqual("<nav class=\"navbar navbar-default navbar-fixed-top\" role=\"navigation\"><div class=\"container\"></div></nav>", output.ToString());
        }

        [Test]
        public void NavbarInverse()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer, Navbar.Settings.Inverted()))
            {

            }
            Assert.AreEqual("<nav class=\"navbar navbar-default navbar-inverse\" role=\"navigation\"><div class=\"container\"></div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithButton()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                writer.Write(navbar.Button("Sign In"));
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<button class=\"btn btn-default navbar-btn\">Sign In</button>" +
                            "</div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithText()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                writer.Write(navbar.Text("Signed in as Jordan Wallwork"));
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<p class=\"navbar-text\">Signed in as Jordan Wallwork</p>" +
                            "</div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithBrand()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                using (navbar.Header())
                {
                    writer.Write(navbar.Brand("BootstrapComponents"));
                }
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<div class=\"navbar-header\">" + toggleHtml +
                                    "<p class=\"navbar-brand\">BootstrapComponents</p>" +
                                "</div>" +
                            "</div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithBrandLink()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                writer.Write(navbar.Brand("BootstrapComponents", "https://github.com/jordanwallwork/bootstrapcomponents"));
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<a class=\"navbar-brand\" href=\"https://github.com/jordanwallwork/bootstrapcomponents\">BootstrapComponents</a>" +
                            "</div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithNavLinks()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                using (var nav = navbar.Nav())
                {
                    writer.Write(nav.Link("Google", "www.google.com"));
                    writer.Write(nav.Link("GitHub", "www.github.com"));
                }
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<ul class=\"nav navbar-nav\">" +
                                    "<li><a href=\"www.google.com\">Google</a></li>" +
                                    "<li><a href=\"www.github.com\">GitHub</a></li>" +
                                "</ul>" +
                            "</div></nav>", output.ToString());
        }

        [Test]
        public void NavbarWithRightNav()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var navbar = new Navbar(writer))
            {
                using (var nav = navbar.Nav())
                {
                    writer.Write(nav.Link("Google", "www.google.com"));
                    writer.Write(nav.Link("GitHub", "www.github.com"));
                }
                using (var nav = navbar.RightNav())
                {
                    writer.Write(nav.Link("Profile", "#"));
                }
            }
            Assert.AreEqual("<nav class=\"navbar navbar-default\" role=\"navigation\"><div class=\"container\">" +
                                "<ul class=\"nav navbar-nav\">" +
                                    "<li><a href=\"www.google.com\">Google</a></li>" +
                                    "<li><a href=\"www.github.com\">GitHub</a></li>" +
                                "</ul>" +
                                "<ul class=\"nav navbar-nav navbar-right\">" +
                                    "<li><a href=\"#\">Profile</a></li>" +
                                "</ul>" +
                            "</div></nav>", output.ToString());
        }

        #region Html Strings


        private const string toggleHtml = "<button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-ex1-collapse\">" +
                                    "<span class=\"sr-only\">Toggle navigation</span>" +
                                    "<span class=\"icon-bar\"></span>" +
                                    "<span class=\"icon-bar\"></span>" +
                                    "<span class=\"icon-bar\"></span>" +
                                    "</button>";

        #endregion
    }
}
