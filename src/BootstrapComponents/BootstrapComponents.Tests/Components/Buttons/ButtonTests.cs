using BootstrapComponents.Common;
using BootstrapComponents.Components.Buttons;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Buttons
{
    [TestFixture]
    public class ButtonTests
    {
        [Test]
        public void DefaultButton()
        {
            var button = new Button("Test Button");
            Assert.AreEqual("<button class=\"btn btn-default\">Test Button</button>", button.ToHtmlString());
        }

        [Test]
        public void ButtonWithCategory()
        {
            var button = new Button("Info Button", new ButtonSettings { Category = Category.Info });
            Assert.AreEqual("<button class=\"btn btn-info\">Info Button</button>", button.ToHtmlString());
        }

        [Test]
        public void ButtonWithSize()
        {
            var button = new Button("Extra Small Button", new ButtonSettings { Size = Size.Xs });
            Assert.AreEqual("<button class=\"btn btn-default btn-xs\">Extra Small Button</button>", button.ToHtmlString());
        }

        [Test]
        public void HyperlinkButton()
        {
            var button = new Button("GitHub", new ButtonSettings { LinkUrl = "http://www.github.com"});
            Assert.AreEqual("<a class=\"btn btn-default\" href=\"http://www.github.com\">GitHub</a>", button.ToHtmlString());
        }

        [Test]
        public void BlockLevelButton()
        {
            var button = new Button("Block Level", new ButtonSettings { BlockLevel = true });
            Assert.AreEqual("<button class=\"btn btn-default btn-block\">Block Level</button>", button.ToHtmlString());
        }

        [Test]
        public void DisabledButton()
        {
            var button = new Button("Disabled", new ButtonSettings { IsDisabled = true });
            Assert.AreEqual("<button class=\"btn btn-default\" disabled=\"disabled\">Disabled</button>", button.ToHtmlString());
        }

        [Test]
        public void DisabledHyperlink()
        {
            var button = new Button("Disabled", new ButtonSettings { Tag = ButtonSettings.ButtonTag.A, IsDisabled = true });
            Assert.AreEqual("<a class=\"btn btn-default disabled\" href=\"#\">Disabled</a>", button.ToHtmlString());
        }

        [Test]
        public void ButtonPullRight()
        {
            var button = new Button("Button").PullRight();
            Assert.AreEqual("<button class=\"btn btn-default pull-right\">Button</button>", button.ToHtmlString());
        }
    }
}
