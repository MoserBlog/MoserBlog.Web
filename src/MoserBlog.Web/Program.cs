using MoserBlog.Application;
using MoserBlog.Persistence;
using MoserBlog.Web;
using MoserBlog.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var services = builder.Services;

services.AddApplicationServices();
services.AddPersistenceServices(builder.Configuration, builder.Environment.IsDevelopment());
services.AddConfigurationServices(builder.Configuration);
services.AddWebServices();

services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/healthz");
});


app.Run();
