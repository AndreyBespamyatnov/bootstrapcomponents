namespace BootstrapComponents.Core
{
    public class BasicCloseableHtml : CloseableHtml
    {
        private readonly string _end;

        public BasicCloseableHtml(string begin, string end, IWriter writer) : base(writer)
        {
            Write(begin);
            _end = end;
        }

        public override string ClosingHtml()
        {
            return _end;
        }
    }
}