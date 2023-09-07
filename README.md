# MultiAssemblyWeb

This is a sample project to show how to develop a .NET Core Web Site with separated assemblies for each functionality.

The detail to fix here is in the extension method:

        public static string ModuleAction(this IUrlHelper urlHelper, string action, string controller, string module, object? values = null)
        {
            ArgumentNullException.ThrowIfNull(urlHelper);

            var oldPathBase = urlHelper.ActionContext.HttpContext.Request.PathBase;
            urlHelper.ActionContext.HttpContext.Request.PathBase = new PathString($"/{module}");
            var url = urlHelper.Action(action, controller, values) ?? string.Empty;
            urlHelper.ActionContext.HttpContext.Request.PathBase = oldPathBase;
            return url;
        }

For the URL generation to work correctly in every page, this check should be accomplished when modifying `PathBase` property:

    urlHelper.ActionContext.HttpContext.Request.PathBase = oldPathBase.Value == $"/{module}" ? new PathString() : new PathString($"/{module}");
