using Microsoft.EntityFrameworkCore;
using StoreApp.Data;
using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app, app.Environment);




//builder.Services.AddControllersWithViews();

app.Run();
app.UseStaticFiles();

app.ConfigureAndCheckMigrations();
app.ConfigureLocalization();




void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllersWithViews();

    // Add DbContext configuration
    /*services.AddDbContext<StoreAppContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));*/

    builder.Services.ConfigureDbContext(builder.Configuration);
    builder.Services.ConfigureRepositoryRegistration();
    builder.Services.ConfigureServiceRegistration();
    builder.Services.ConfigureRouting();
    builder.Services.ConfigureIdentity();


    

    services.AddAutoMapper(typeof(Program));
    services.AddRazorPages();   
    builder.Services.ConfigureSession();

}

void Configure(WebApplication app, IWebHostEnvironment environment)
{
    if (!environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    
    app.UseStaticFiles();
    app.UseSession();

    app.UseHttpsRedirection();
    app.ConfigureDefaultAdminUser();

    app.UseRouting();
    app.UseAuthorization();
    app.UseAuthentication();
   
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapAreaControllerRoute(
            name :"Admin",
            areaName : "Admin",
            pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );

        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapRazorPages();
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