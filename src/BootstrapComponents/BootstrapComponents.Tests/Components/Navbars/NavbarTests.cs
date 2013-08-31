using System.Text;
using BootstrapComponents.Components.Navbars;
using BootstrapComponents.Core;
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
            using (var navbar = new Navbar(writer, Navbar.Settings.Fixed()))
            {

            }
            Assert.AreEqual("<nav class=\"navbar navbar-default navbar-fixed-top\" role=\"navigation\"><div class=\"container\"></div></nav>", output.ToString());
        }
    }
}
