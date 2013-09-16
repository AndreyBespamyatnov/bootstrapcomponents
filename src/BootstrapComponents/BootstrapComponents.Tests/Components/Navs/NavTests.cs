using System.Text;
using BootstrapComponents.Components.Navs;
using BootstrapComponents.Tests.Core;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Navs
{
    [TestFixture]
    public class NavTests
    {
        [Test]
        public void DefaultTabs()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-tabs\">" +
                                "<li><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void ExplicitTabs()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, Nav.Settings.Tabs()))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-tabs\">" +
                                "<li><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void Pills()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, Nav.Settings.Pills()))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-pills\">" +
                                "<li><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void StackedPills()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, Nav.Settings.Pills().Stack()))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-pills nav-stacked\">" +
                                "<li><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void Justify()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, Nav.Settings.Justify()))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-tabs nav-justified\">" +
                                "<li><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void DisabledLinks()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer))
            {
                writer.Write(nav.Link("Home", "#", new {@class="disabled"}));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-tabs\">" +
                                "<li class=\"disabled\"><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void IndicateActiveUsingLinkText()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, "Home", Nav.Settings.Pills()))
            {
                writer.Write(nav.Link("Home", "#"));
                writer.Write(nav.Link("Profile", "#"));
            }
            Assert.AreEqual("<ul class=\"nav nav-pills\">" +
                                "<li class=\"active\"><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }

        [Test]
        public void IndicateActiveWithExplicitIdentifier()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var nav = new Nav(writer, "HomeLink", Nav.Settings.Pills()))
            {
                writer.Write(nav.Link("Home", "#", "HomeLink"));
                writer.Write(nav.Link("Profile", "#", "ProfileLink"));
            }
            Assert.AreEqual("<ul class=\"nav nav-pills\">" +
                                "<li class=\"active\"><a href=\"#\">Home</a></li>" +
                                "<li><a href=\"#\">Profile</a></li>" +
                            "</ul>", output.ToString());
        }
    }
}
