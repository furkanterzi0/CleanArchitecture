using ProductApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Entities
{
    public class Product: BaseEntity
    {
        public String Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}
