using Plugins.DataStore.InMemory;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Service Collection
// Singleton: there's only going to be one instance in the entire application (makes sense for the in-memory DB)
// Transient: there are going to be instances created and destroyed repeatedly (makes sense for viewing categories use case)
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();

var app = builder.Build();

// Makes sure that middleware static files (such as the bootstrap lib) can load to the web app.
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();