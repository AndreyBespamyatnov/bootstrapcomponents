using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Forms.FormControls
{
    public class TextBox : GenericInnerHtmlContainer, IFormControl
    {
        private readonly string _id;

        public TextBox(FormGroup formGroup, string id, string value) : base("input", null, true)
        {
            _id = id;
            Attrs["type"] = "text";
            Attrs["id"] = id;
            Attrs["value"] = value;
            Attrs["class"] += "form-control";
        }

        public string LabelId { get { return _id; } }
    }
}