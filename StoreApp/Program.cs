using DevExpress.Services.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer.Dac.Extensibility;
using Services;
using Services.Contracts;
using StoreApp.Data;
using StoreApp.Data.Contracts;
using StoreApp.Data.Migrations;
using StoreApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app, app.Environment);




//builder.Services.AddControllersWithViews();

app.Run();
app.UseStaticFiles();



void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllersWithViews();

    // Add DbContext configuration
    services.AddDbContext<StoreAppContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IRepositoryManager, RepositoryManager>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IServiceManager, Services.ServiceManager>();
    services.AddScoped<IProductService, ProductManager>();
    services.AddScoped<ICategoryService, CategoryManager>();
    


}

void Configure(WebApplication app, IWebHostEnvironment environment)
{
    if (!environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute("default","{controller =Home},{action=index}/{id?}");

    });

}

void ApplyMigrationsAndSeed(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<StoreAppContext>();
        context.Database.Migrate();
    }
}