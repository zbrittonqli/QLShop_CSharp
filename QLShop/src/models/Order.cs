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
                    item.Count++;
                }
            }

            if (!duplicateFound)
            {
                Products.Add(product);
            }

            CalculateTotal();
        }

        public void AddManyProducts(List<Product> products)
        {
            bool duplicateFound = false;

            foreach (Product item in Products)
            {
                foreach (Product newProduct in products)
                {
                    if (item.Id == newProduct.Id)
                    {
                        duplicateFound = true;
                        item.Count++;
                    }
                }
            }

            if (!duplicateFound)
            {
                Products.AddRange(products);
            }

            CalculateTotal();
        }

        public void Cancel()
        {
            Products.Clear();
            CalculateTotal();
        }

        public void CalculateTotal()
        {
            foreach (Product product in Products)
            {
                Total += product.Price;
            }
        }
    }
}
