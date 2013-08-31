﻿using System.Text;
using BootstrapComponents.Core;

namespace BootstrapComponents.Tests.Core
{
    public class StringBuilderWriter : CloseableHtml.IWriter
    {
        private readonly StringBuilder _stringBuilder;

        public StringBuilderWriter(StringBuilder stringBuilder)
        {
            _stringBuilder = stringBuilder;
        }

        public void Write(string str)
        {
            _stringBuilder.Append(str);
        }
    }
}
