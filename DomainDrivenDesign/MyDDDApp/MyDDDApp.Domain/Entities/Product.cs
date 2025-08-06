using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
