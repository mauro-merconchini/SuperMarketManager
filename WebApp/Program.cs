using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SuperMarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperMarketManagement"));
});

// Service Collection
// Singleton: there's only going to be one instance in the entire application (makes sense for the in-memory DB)
// Transient: there are going to be instances created and destroyed repeatedly (makes sense for viewing categories use case)
builder.Services.AddControllersWithViews();

// Categories Services
builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();

// Products Services
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

// Transactions Services
builder.Services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();

var app = builder.Build();

// Makes sure that middleware static files (such as the bootstrap lib) can load to the web app.
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();