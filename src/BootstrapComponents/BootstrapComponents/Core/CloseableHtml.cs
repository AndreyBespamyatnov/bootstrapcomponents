using System;
using System.Web.Mvc;

namespace BootstrapComponents.Core
{
    public abstract class CloseableHtml : IDisposable
    {
        protected readonly IWriter _writer;

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
