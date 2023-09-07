using Microsoft.AspNetCore.Mvc;

namespace EntryAssemblyWeb.Extensions
{
    public static class WebExtensions
    {
        public static string ModuleAction(this IUrlHelper urlHelper, string action, string controller, string module, object? values = null)
        {
            ArgumentNullException.ThrowIfNull(urlHelper);

            var oldPathBase = urlHelper.ActionContext.HttpContext.Request.PathBase;
            urlHelper.ActionContext.HttpContext.Request.PathBase = new PathString($"/{module}");
            var url = urlHelper.Action(action, controller, values) ?? string.Empty;
            urlHelper.ActionContext.HttpContext.Request.PathBase = oldPathBase;
            return url;
        }
    }
}
