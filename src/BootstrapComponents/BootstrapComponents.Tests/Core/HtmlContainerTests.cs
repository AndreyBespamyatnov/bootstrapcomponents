using BootstrapComponents.Core;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Core
{
    [TestFixture]
    public class HtmlContainerTests
    {
        [Test]
        public virtual void SelfClosing()
        {
            var cont = new MockHtmlContainer("close");
            Assert.AreEqual("<close />", cont.ToHtmlString());
        }

        [Test]
        public virtual void NotSelfClosing()
        {
            var cont = new MockHtmlContainer("close", false);
            Assert.AreEqual("<close></close>", cont.ToHtmlString());
        }

        [Test]
        public void PullRight()
        {
            var cont = new MockHtmlContainer("tag").PullRight();
            Assert.AreEqual("<tag class=\"pull-right\" />", cont.ToHtmlString());
        }

        [Test]
        public void PullLeft()
        {
            var cont = new MockHtmlContainer("tag").PullLeft();
            Assert.AreEqual("<tag class=\"pull-left\" />", cont.ToHtmlString());
        }

        [Test]
        public void Clearfix()
        {
            var cont = new MockHtmlContainer("tag").Clearfix();
            Assert.AreEqual("<tag class=\"clearfix\" />", cont.ToHtmlString());
        }

        [Test]
        public void SrOnly()
        {
            var cont = new MockHtmlContainer("tag").SrOnly();
            Assert.AreEqual("<tag class=\"sr-only\" />", cont.ToHtmlString());
        }

        [Test]
        public void Visibility()
        {
            var cont = new MockHtmlContainer("tag").Visible("xs");
            Assert.AreEqual("<tag class=\"visible-xs\" />", cont.ToHtmlString());
        }
    }

    public class MockHtmlContainer : HtmlContainer
    {
        public MockHtmlContainer(string tag, bool selfClosing = true) : base(tag, selfClosing)
        {
        }
    }
}
