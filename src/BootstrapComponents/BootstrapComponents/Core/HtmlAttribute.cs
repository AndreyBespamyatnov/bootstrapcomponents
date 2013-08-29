using System.Globalization;

namespace BootstrapComponents.Core
{
    public class HtmlAttribute
    {
        private string _value;

        public HtmlAttribute(string value)
        {
            _value = value;
        }

        public HtmlAttribute(object value)
        {
            _value = value.ToString();
        }

        public static implicit operator HtmlAttribute(string value)
        {
            return new HtmlAttribute(value);
        }

        public static HtmlAttribute operator +(HtmlAttribute h1, HtmlAttribute h2)
        {
            if (h1.IsEmpty()) return h2;
            if (h2.IsEmpty()) return h1;
            return new HtmlAttribute(h1._value + " " + h2._value);
        }

        public override string ToString()
        {
            return _value;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(_value);
        }
    }
}