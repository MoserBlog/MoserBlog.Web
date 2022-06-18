using MoserBlog.Application;
using MoserBlog.Persistence;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;

services.AddApplicationServices();
services.AddPersistenceServices(builder.Configuration);


builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
