using System;
using System.Collections.Generic;
using System.Linq;
using BootstrapComponents.Components.Forms.FormControls;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Forms
{
    public class FormGroup : HtmlContainer
    {
        protected readonly Form _form;
        private readonly Func<FormGroup, IFormControl>[] _controls;

        public FormGroup(Form form, params Func<FormGroup, IFormControl>[] controls) : base("div", false)
        {
            _form = form;
            _controls = controls;
            Attrs["class"] += "form-group";
        }

        public override string InnerHtml()
        {
            var items = new List<IFormControl>();
            var dictionary = new Dictionary<string, bool>();
            foreach (var control in _controls.Select(c => c.Invoke(this)))
            {
                items.Add(control);
                if (control is Label)
                    dictionary[control.LabelId] = true;
                else
                    if (!dictionary.ContainsKey(control.LabelId)) dictionary[control.LabelId] = false;

            }
            foreach (var noLabel in dictionary.Where(x => !x.Value))
            {
                var label = new Label(this, noLabel.Key, noLabel.Key);
                label.Attrs["class"] += "sr-only";
                items.Add(label);
            }
            return string.Join("", items.Select(x => x.ToHtmlString()));
        }

        public Label Label(string text, string id = null)
        {
            return new Label(this, text, id);
        }

        public TextBox TextBox(string id, string value)
        {
            return new TextBox(this, id, value);
        }
    }

    public interface IFormControl
    {
        string ToHtmlString();
        string LabelId { get; }
    }


}