using BootstrapComponents.Components.Images;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Images
{
    [TestFixture]
    public class ImageTests
    {
        [Test]
        public void RoundedImage()
        {
            var image = new Image("http://placehold.it/350x150", "Placeholder", Image.Style.Rounded);
            Assert.AreEqual("<img alt=\"Placeholder\" class=\"img-rounded\" src=\"http://placehold.it/350x150\" />", image.ToHtmlString());
        }
        [Test]
        public void CircleImage()
        {
            var image = new Image("http://placehold.it/350x150", "Placeholder", Image.Style.Circle);
            Assert.AreEqual("<img alt=\"Placeholder\" class=\"img-circle\" src=\"http://placehold.it/350x150\" />", image.ToHtmlString());
        }
        [Test]
        public void ThumbnailImage()
        {
            var image = new Image("http://placehold.it/350x150", "Placeholder", Image.Style.Thumbnail);
            Assert.AreEqual("<img alt=\"Placeholder\" class=\"img-thumbnail\" src=\"http://placehold.it/350x150\" />", image.ToHtmlString());
        }
    }
}
