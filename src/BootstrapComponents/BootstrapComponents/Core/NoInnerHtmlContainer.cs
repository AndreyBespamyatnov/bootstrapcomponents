namespace BootstrapComponents.Core
{
    public class NoInnerHtmlContainer : HtmlContainer
    {
        public NoInnerHtmlContainer(string tag, bool selfClosing = true) : base(tag, selfClosing)
        {
        }

        public override string InnerHtml()
        {
            return null;
        }
    }
}