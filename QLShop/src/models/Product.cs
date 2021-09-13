using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShop.src.models.product
{
    class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }

        public Product(Guid id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
