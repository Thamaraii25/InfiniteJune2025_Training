using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 2. Create a Class called Products with Productid, Product Name, Price. 
  Accept 10 Products, sort them based on the price, and display the sorted Products.
 */

namespace CodeChallenge_2
{
    class ProductsQuestion
    {
        static void Main(string[] args)
        {
            Product productObj = new Product();

            Console.WriteLine("Enter No. of Products u want to add:\n");
            int totalProducts = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < totalProducts; i++)
            {
                Console.WriteLine($"\nEnter Product {i + 1} Details:\n");

                Console.Write("Input Product Id: ");
                int I_ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input Product Name: ");
                string I_ProductName = Console.ReadLine();

                Console.Write("Input Product Price: ");
                int I_Price = Convert.ToInt32(Console.ReadLine());

                productObj.AddProductData(new Product
                {
                    ProductId = I_ProductId,
                    ProductName = I_ProductName,
                    Price = I_Price
                });
            }
            Console.WriteLine("\n");
            productObj.DisplayProducts();


            Console.Read();
        }
    }

    class Product : IComparable<Product>
    {
        private int productId;
        private string productName;
        private int price;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int CompareTo(Product p)
        {
            return this.Price.CompareTo(p.Price); 
        }

       List<Product> products = new List<Product>();

        public void AddProductData(Product product)
        {
            products.Add(product);
        }

        public void DisplayProducts()
        {
            products.Sort(); 

            Console.WriteLine("Products Sorted Based on Price:");
            foreach (var item in products)
            {
                Console.WriteLine($"Product ID: {item.ProductId}, Product Name: {item.ProductName}, Product Price: {item.Price}");
            }
        }
    }
}
