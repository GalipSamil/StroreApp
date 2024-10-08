﻿using Microsoft.EntityFrameworkCore;
using StoreApp.Entities.Models;


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

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Computer", Price = 17000 },
                new Product { ProductId = 2, ProductName = "Keyboard", Price = 1000 },
                new Product { ProductId = 3, ProductName = "Mouse", Price = 500 },
                new Product { ProductId = 4, ProductName = "Monitor", Price = 7000 },
                new Product { ProductId = 5, ProductName = "Desk", Price = 1500 }
            );

            modelBuilder.Entity<Category>()
            .HasData(
                new Category() { CategoryId = 1, CategoryName = "Book"},
                new Category() { CategoryId = 2, CategoryName = "Electronic"}
                );
        }

    }
}
