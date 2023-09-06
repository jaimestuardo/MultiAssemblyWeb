using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MultipleAssemblyWeb
{
    /// <summary>
    /// Adds the route prefix to all actions 
    /// </summary>
    public class ModuleRoutingConvention : IActionModelConvention
    {
        private readonly IEnumerable<Module> _modules;

        public ModuleRoutingConvention(IEnumerable<Module> modules)
        {
            _modules = modules;
        }

        public void Apply(ActionModel action)
        {
            //var module = _modules.FirstOrDefault(m => m.Assembly == action.Controller.ControllerType.Assembly);
            var module = _modules.FirstOrDefault(m => action.Controller.ControllerType.Assembly.FullName?.StartsWith(m.RoutePrefix) ?? false);
            if (module == null)
            {
                return;
            }

            action.RouteValues.Add("module", module.RoutePrefix);
        }
    }
}
