using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace BootstrapComponents.Components.Forms
{
    public static class FormExtensions
    {
        public static Form InlineForm(this HtmlHelper html, string actionName = null, string controllerName = null, object routeValues = null, FormMethod method = FormMethod.Post, object htmlAttrs = null)
        {
            return new Form(html, actionName, controllerName, routeValues, method, htmlAttrs, FormType.Inline);
        }

        public static Form HorizontalForm(this HtmlHelper html, string actionName = null, string controllerName = null, object routeValues = null, FormMethod method = FormMethod.Post, object htmlAttrs = null)
        {
            return new Form(html, actionName, controllerName, routeValues, method, htmlAttrs, FormType.Horizontal);
        }
    }

    public enum FormType { Inline, Horizontal }
}
