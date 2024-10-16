﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Config
{
    public class CategoryConfig :IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);
            builder.Property(p=>p.CategoryName).IsRequired();
            builder.HasData(
                new Category() { CategoryId = 1, CategoryName = "Books"},
                new Category() { CategoryId = 2, CategoryName = "Electronics"}
            );
        }

    }
}
