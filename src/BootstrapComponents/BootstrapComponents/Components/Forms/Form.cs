using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BootstrapComponents.Core;

namespace BootstrapComponents.Components.Forms
{
    public class Form : CloseableHtml
    {
        private MvcForm _form;

        public Form(HtmlHelper html, string actionName = null, string controllerName = null, object routeValues = null, FormMethod method = FormMethod.Post, object htmlAttrs = null, FormType? formType = null) : base(html.ViewContext)
        {
            Init(html, actionName, controllerName, routeValues, method, htmlAttrs, formType);
        }

        public Form(IWriter writer, HtmlHelper html, string actionName = null, string controllerName = null, object routeValues = null, FormMethod method = FormMethod.Post, object htmlAttrs = null, FormType? formType = null) : base(writer)
        {
            Init(html, actionName, controllerName, routeValues, method, htmlAttrs, formType);
        }

        private void Init(HtmlHelper html, string actionName = null, string controllerName = null, object routeValues = null,
                          FormMethod method = FormMethod.Post, object htmlAttrs = null, FormType? formType = null)
        {
            var attrs = new HtmlAttributes(htmlAttrs);
            if (formType != null) attrs["class"] += "form-" + formType.ToString().ToLower();
            if (html == null) return;
            _form = html.BeginForm(actionName, controllerName, new RouteValueDictionary(routeValues), method, attrs.ToDictionary());
        }

        protected override string ClosingHtml()
        {
            if (_form != null) _form.Dispose();
            return null;
        }

        public FormGroup Group(params Func<FormGroup, IFormControl>[] controls)
        {
            return new FormGroup(this, controls);
        }
    }
}