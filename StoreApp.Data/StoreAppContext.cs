using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Config;
using StoreApp.Entities.Models;
using System.Reflection;


namespace StoreApp.Data
{
    public class StoreAppContext : DbContext
    {
        

        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base (options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        //public DbSet<Category> Categories { get; set; }

        //public DbSet<Order> Orders { get; set; }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // YORUM SATIRLARINDAKİ GİBİ TANIMLAMAMIZA GEREK KALMADI tek satırda çözüldü

        }

    }
}
