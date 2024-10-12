using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        
        public String ProductName { get; set; } = String.Empty;

        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }

        
        public decimal Price { get; set; }

        public int? CategoryId { get; init; }  // Foreign Key

        public Category? Category { get; set; }  // Navigation property

        public bool ShowCase { get; set; }
    }
}
