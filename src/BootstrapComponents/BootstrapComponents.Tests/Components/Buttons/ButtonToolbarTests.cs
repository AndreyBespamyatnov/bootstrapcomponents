using BootstrapComponents.Components.Buttons;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Buttons
{
    [TestFixture]
    public class ButtonToolbarTests
    {
        [Test]
        public void DefaultButtonToolbar()
        {
            var buttonGroup = new ButtonGroup(new Button("Left"), new Button("Middle"), new Button("Right"));
            var html = "<div class=\"btn-group\"><button class=\"btn btn-default\">Left</button>"
                       + "<button class=\"btn btn-default\">Middle</button>"
                       + "<button class=\"btn btn-default\">Right</button></div>";
            var toolbar = new ButtonToolbar(buttonGroup, buttonGroup, buttonGroup);

            Assert.AreEqual(string.Format("<div class=\"btn-toolbar\">{0}{0}{0}</div>", html),
                            toolbar.ToHtmlString());
        }
    }
}