using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace StoreApp.Data
{
    public class StoreAppContextFactory : IDesignTimeDbContextFactory<StoreAppContext>
    {
        public StoreAppContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = Path.Combine(currentDirectory, "..", "StoreApp");

            Console.WriteLine($"Current Directory: {currentDirectory}");
            Console.WriteLine($"Base Path: {basePath}");
            Console.WriteLine($"Expected appsettings.json Path: {Path.Combine(basePath, "appsettings.json")}");

            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                throw new FileNotFoundException("appsettings.json not found", Path.Combine(basePath, "appsettings.json"));
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<StoreAppContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlite(connectionString);

            return new StoreAppContext(builder.Options);
        }
    }
}
