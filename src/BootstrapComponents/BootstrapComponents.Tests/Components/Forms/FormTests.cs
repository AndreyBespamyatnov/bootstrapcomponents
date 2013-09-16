using System.Text;
using BootstrapComponents.Components.Forms;
using BootstrapComponents.Tests.Core;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Components.Forms
{
    [TestFixture]
    public class FormTests
    {
        [Test]
        public void NullHtmlHelperForTestingShouldntBreak()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var form = new Form(writer, null))
            {

            }
            Assert.AreEqual("", output.ToString());
        }

        [Test]
        public void EmptyFormGroup()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var form = new Form(writer, null))
            {
                writer.Write(form.Group());
            }
            Assert.AreEqual("<div class=\"form-group\"></div>", output.ToString());
        }

        [Test]
        public void BasicInputWithLabel()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var form = new Form(writer, null))
            {
                writer.Write(form.Group(
                    fg => fg.Label("Email"),
                    fg => fg.TextBox("Email", "email@address.com")
                ));
            }
            Assert.AreEqual("<div class=\"form-group\">" +
                                "<label for=\"Email\">Email</label>" +
                                "<input class=\"form-control\" id=\"Email\" type=\"text\" value=\"email@address.com\" />" +
                            "</div>", output.ToString());
        }

        [Test]
        public void GenerateLabelForScreenReaderIfMissing()
        {
            var output = new StringBuilder();
            var writer = new StringBuilderWriter(output);
            using (var form = new Form(writer, null))
            {
                writer.Write(form.Group(
                    fg => fg.TextBox("Email", "email@address.com")
                ));
            }
            Assert.AreEqual("<div class=\"form-group\">" +
                                "<input class=\"form-control\" id=\"Email\" type=\"text\" value=\"email@address.com\" />" +
                                "<label class=\"sr-only\" for=\"Email\">Email</label>" +
                            "</div>", output.ToString());
        }
    }
}
