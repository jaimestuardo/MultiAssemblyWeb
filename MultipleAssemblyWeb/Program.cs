using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultipleAssemblyWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register a convention allowing to us to prefix routes to modules.
builder.Services
    .AddTransient<IPostConfigureOptions<MvcOptions>, ModuleRoutingMvcOptionsPostConfigure>()
    .AddModule<OtherAssembly.Startup>("Other", builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
