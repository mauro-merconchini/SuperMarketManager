var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Makes sure that middleware static files (such as the bootstrap lib) can load to the web app.
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();