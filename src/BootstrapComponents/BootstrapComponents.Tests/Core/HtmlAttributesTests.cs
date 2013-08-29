using System;
using System.Collections.Generic;
using BootstrapComponents.Core;
using NUnit.Framework;

namespace BootstrapComponents.Tests.Core
{
    [TestFixture]
    public class HtmlAttributesTests
    {
        [Test]
        public void CreateFromDictionary()
        {
            var attributes = new HtmlAttributes(new Dictionary<string, object>
                {
                    {"text", "some text"},
                    {"num", 123}
                });
            Assert.AreEqual("num=\"123\" text=\"some text\"", attributes.ToString());
        }

        [Test]
        public void CreateFromAnonymousObject()
        {
            var attributes = new HtmlAttributes(new {
                    text = "some text",
                    num = 123
                });
            Assert.AreEqual("num=\"123\" text=\"some text\"", attributes.ToString());
        }

        [Test]
        public void OverwriteAttributes()
        {
            var attributes = new HtmlAttributes(new { text = "original" });
            attributes["text"] = "replacement";
            Assert.AreEqual("text=\"replacement\"", attributes.ToString());
        }

        [Test]
        public void AppendAttributesWithSpace()
        {
            var attributes = new HtmlAttributes(new { text = "original" });
            attributes["text"] += "replacement";
            Assert.AreEqual("text=\"original replacement\"", attributes.ToString());
        }

        [Test]
        public void AppendNonExistantAttributesSetsWithoutLeadingSpace()
        {
            var attributes = new HtmlAttributes(new { });
            attributes["text"] += "some words";
            Assert.AreEqual("text=\"some words\"", attributes.ToString());
        }

        [Test]
        public void ImplementAnyMethod()
        {
            var attributes = new HtmlAttributes(new {  });
            Assert.IsFalse(attributes.Any());
            attributes["test"] = "test";
            Assert.IsTrue(attributes.Any());
            Assert.IsFalse(attributes.Any(x => x.Key == "fail"));
        }
    }
}
