using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreApp.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product { ProductId = 1, CategoryId = 2,ImageUrl="/images/1.jpg", ProductName = "Computer", Price = 17000, ShowCase = false},
                new Product { ProductId = 2, CategoryId = 2,ImageUrl="/images/2.jpg" ,ProductName = "Keyboard", Price = 1000, ShowCase = false},
                new Product { ProductId = 3, CategoryId = 2,ImageUrl="/images/3.jpg" ,ProductName = "Mouse", Price = 500, ShowCase = false},
                new Product { ProductId = 4, CategoryId = 2,ImageUrl="/images/4.jpg" ,ProductName = "Monitor", Price = 7000, ShowCase = false},
                new Product { ProductId = 5, CategoryId = 2,ImageUrl="/images/5.jpg" ,ProductName = "Desk", Price = 1500, ShowCase = false},
                new Product { ProductId = 6, CategoryId = 2,ImageUrl="/images/6.jpg" ,ProductName = "History", Price = 150 ,ShowCase = false},
                new Product { ProductId = 7, CategoryId = 2,ImageUrl="/images/7.jpg" ,ProductName = "Hamlet", Price = 100, ShowCase = false},
                new Product { ProductId = 8, CategoryId = 1, ImageUrl ="/images/8.jpg" ,ProductName = "Xp-Pen", Price = 150, ShowCase = true},
                new Product { ProductId = 9, CategoryId = 2, ImageUrl ="/images/9.jpg" ,ProductName = "Galaxy FE", Price = 6000, ShowCase = true},
                new Product { ProductId = 10, CategoryId = 1, ImageUrl = "/images/10.jpg" ,ProductName = "HP Mouse", Price = 125, ShowCase = true}

            );
        }
    }
}
