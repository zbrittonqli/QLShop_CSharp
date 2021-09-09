using NUnit.Framework;
using QLShop.src.models.order;
using QLShop.src.models.product;
using System.Collections.Generic;

namespace QLShop
{
    public class OrderTests
    {
        [Test]
        public void CalculateTotalTest()
        {
            List<Product> products = new List<Product> {
                new Product("Television",  300.01f),
                new Product("Couch",  400.01f),
                new Product("Table",  200.01f)
            };

            Order order = new Order();
            order.Products = products;
            order.CalculateTotal();

            Assert.AreEqual(900.03f, order.Total);
        }

        [Test]
        public void CalculateTotalNoProductsTest()
        {
            Order order = new Order();
            order.CalculateTotal();

            Assert.AreEqual(0, order.Products.Count);
            Assert.AreEqual(0f, order.Total);
        }

        [Test]
        public void AddProductTest()
        {
            Order order = new Order();
            order.AddProduct(new Product("Television", 300.01f));

            Assert.AreEqual(1, order.Products.Count);
            Assert.AreEqual("Television", order.Products[0].Name);
            Assert.AreEqual(300.01f, order.Products[0].Price);
        }

        [Test]
        public void AddManyProductsTest()
        {
            List<Product> products = new List<Product> {
                new Product("Television",  300.01f),
                new Product("Couch", 400.01f),
                new Product("Table", 200.01f)
            };

            Order order = new Order();
            order.AddManyProducts(products);

            Assert.AreEqual(3, order.Products.Count);
            Assert.AreEqual("Television", order.Products[0].Name);
            Assert.AreEqual(300.01f, order.Products[0].Price);
            Assert.AreEqual("Couch", order.Products[1].Name);
            Assert.AreEqual(400.01f, order.Products[1].Price);
            Assert.AreEqual("Table", order.Products[2].Name);
            Assert.AreEqual(200.01f, order.Products[2].Price);
            Assert.AreEqual(900.03f, order.Total);
        }
    }
}