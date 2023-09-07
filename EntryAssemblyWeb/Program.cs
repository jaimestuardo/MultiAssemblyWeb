using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using EntryAssemblyWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register a convention allowing to us to prefix routes to modules.
builder.Services
    .AddTransient<IPostConfigureOptions<MvcOptions>, ModuleRoutingMvcOptionsPostConfigure>()
    .AddModule<FirstAssembly.Startup>("First", builder.Configuration)
    .AddModule<SecondAssembly.Startup>("Second", builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

    app.Use(next => context =>
    {
        Console.WriteLine($"Encontrado: {context.GetEndpoint()?.DisplayName}");
        return next(context);
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();

var modules = app.Services.GetRequiredService<IEnumerable<Module>>();
foreach (var module in modules)
{
    app.Map($"/{module.RoutePrefix}", ab =>
    {
        ab.UseRouting();
        module.Startup.Configure(ab);
    });
}

app.Run();
