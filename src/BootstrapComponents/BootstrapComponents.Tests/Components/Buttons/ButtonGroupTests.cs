using BootstrapComponents.Common;
using BootstrapComponents.Components.Buttons;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Buttons
{
    [TestFixture]
    public class ButtonGroupTests
    {
        [Test]
        public void DefaultButtonGroup()
        {
            var buttonGroup = new ButtonGroup(new Button("Left"), new Button("Middle"), new Button("Right"));
            Assert.AreEqual("<div class=\"btn-group\"><button class=\"btn btn-default\">Left</button>"
                            + "<button class=\"btn btn-default\">Middle</button>"
                            + "<button class=\"btn btn-default\">Right</button></div>",
                            buttonGroup.ToHtmlString());
        }

        [Test]
        public void VerticalButtonGroup()
        {
            var buttonGroup = new ButtonGroup(
                    new ButtonGroupSettings { Vertical = true},
                    new Button("Left"), new Button("Middle"), new Button("Right")
                );
            Assert.AreEqual("<div class=\"btn-group-vertical\"><button class=\"btn btn-default\">Left</button>"
                            + "<button class=\"btn btn-default\">Middle</button>"
                            + "<button class=\"btn btn-default\">Right</button></div>",
                            buttonGroup.ToHtmlString());
        }

        [Test]
        public void LargeButtonGroup()
        {
            var buttonGroup = new ButtonGroup(
                    new ButtonGroupSettings { Size = Size.Lg },
                    new Button("Left"), new Button("Middle"), new Button("Right")
                );
            Assert.AreEqual("<div class=\"btn-group btn-group-lg\"><button class=\"btn btn-default\">Left</button>"
                            + "<button class=\"btn btn-default\">Middle</button>"
                            + "<button class=\"btn btn-default\">Right</button></div>",
                            buttonGroup.ToHtmlString());
        }
    }
}