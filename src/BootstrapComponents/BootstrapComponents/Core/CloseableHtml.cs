using System;
using System.Text;
using System.Web.Mvc;

namespace BootstrapComponents.Core
{
    public abstract class CloseableHtml : IDisposable
    {
        private readonly IWriter _writer;
        private readonly ViewContext _viewContext;

        protected CloseableHtml(ViewContext viewContext)
        {
            _writer = new ViewContextWriter(viewContext);
        }

        protected CloseableHtml(IWriter writer)
        {
            _writer = writer;
        }

        public void Write(string formatString, params object[] strs)
        {
            _writer.Write(string.Format(formatString, strs));
        }

        public abstract string ClosingHtml();

        public void Dispose()
        {
            Write(ClosingHtml());
        }


        public interface IWriter
        {
            void Write(string str);
        }

        public class ViewContextWriter : IWriter
        {
            private readonly ViewContext _viewContext;

            public ViewContextWriter(ViewContext viewContext)
            {
                _viewContext = viewContext;
            }

            public void Write(string str)
            {
                _viewContext.Writer.Write(str);
            }
        }
    }
}
