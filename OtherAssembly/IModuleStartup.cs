using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OtherAssembly
{
    public interface IModuleStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        void Configure(IApplicationBuilder app);
    }
}
