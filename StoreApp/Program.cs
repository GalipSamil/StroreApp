using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Data;
using StoreApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app, app.Environment);




//builder.Services.AddControllersWithViews();

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllersWithViews();

    // Add DbContext configuration
    services.AddDbContext<StoreAppContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
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

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
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