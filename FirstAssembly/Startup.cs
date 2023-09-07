
using Integration;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Text;

namespace FirstAssembly
{
    public class Startup : IModuleStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
