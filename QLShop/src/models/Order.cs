using QLShop.src.models.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShop.src.models.order
{
    class Order
    {
        public List<Product> Products = new List<Product>();
        public float Total { get; set; }

        public void AddProduct(Product product)
        {
            bool duplicateFound = false;

            foreach (Product item in Products)
            {
                if (item.Id == product.Id)
                {
                    duplicateFound = true;
                    item.Quantity++;
                }
            }

            if (!duplicateFound)
            {
                Products.Add(product);
            }

            CalculateTotal();
        }

        public void AddManyProducts(List<Product> newProducts)
        {
            foreach (Product newProduct in newProducts)
            {
                AddProduct(newProduct);
            }
        }

        public void Cancel()
        {
            Products.Clear();
            CalculateTotal();
        }

        public void CalculateTotal()
        {
            Total = 0;

            foreach (Product product in Products)
            {
                Total += product.Price;
            }
        }
    }
}
