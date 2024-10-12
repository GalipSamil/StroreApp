using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities.Models
{
    public class  Cart
    { 
    public List<CartLine> Lines {  get; set; }

    public Cart()
    {
        Lines = new List<CartLine>();
        
    }
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = Lines.Where(ı => ı.Product.ProductId.Equals(product.ProductId))
            .FirstOrDefault();

            if(line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });

            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)  =>
            Lines.RemoveAll(ı => ı.Product.ProductId.Equals(product.ProductId));

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();

    }
}
 