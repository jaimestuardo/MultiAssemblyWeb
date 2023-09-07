using Integration;
using System.Reflection;

namespace EntryAssemblyWeb
{
    public class Module
    {
        /// <summary>
        /// Gets the route prefix to all controller and endpoints in the module.
        /// </summary>
        public string RoutePrefix { get; }

        /// <summary>
        /// Gets the startup class of the module.
        /// </summary>
        public IModuleStartup Startup { get; }

        /// <summary>
        /// Gets the assembly of the module.
        /// </summary>
        public Assembly Assembly => Startup.GetType().Assembly;

        public Module(string routePrefix, IModuleStartup startup)
        {
            RoutePrefix = routePrefix;
            Startup = startup;
        }
    }
}
