using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Forms.FormControls
{
    public class Label : GenericInnerHtmlContainer, IFormControl
    {
        private readonly string _id;

        public Label(FormGroup formGroup, string text, string id = null) : base("label", text, false)
        {
            _id = id ?? text;
            Attrs["for"] = _id;
        }

        public string LabelId { get { return _id; } }
    }
}
