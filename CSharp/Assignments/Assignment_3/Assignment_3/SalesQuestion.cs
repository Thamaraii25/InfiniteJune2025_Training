using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    /*
     3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
            - Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty *Price
            - Pass the other information like SalesNo, Productno, Price,Qty and Dateof sale through constructor
            - call the show data method to display the values without an object.
     */

    class Saledetails
    {

        public string SalesNo;
        public string ProductNo;
        public int Price;
        public DateTime DateOfSale;
        public int Quantity;
        public int TotalAmount;

        public Saledetails(string salesNo, string productNo, int price, DateTime dateOfSale, int qty)
        {
            this.SalesNo = salesNo;
            this.ProductNo = productNo;
            this.Price = price;
            this.DateOfSale = dateOfSale;
            this.Quantity = qty;
        }
        
        public void Sales(int qty, int price)
        {
            TotalAmount = (qty * price);
        }

        public static void showData(Saledetails s)
        {
        Console.WriteLine("**** Details *****");
        Console.WriteLine("Sales No: {0}", s.SalesNo);
        Console.WriteLine("Product No: {0}",s.ProductNo);
        Console.WriteLine("Date of Sale: {0}",s.DateOfSale);
        Console.WriteLine("Price: {0}",s.Price);
        Console.WriteLine("Quantity: {0}",s.Quantity);
        Console.WriteLine("Total Amount: {0}", s.TotalAmount);
        }


    }


    class SalesQuestion
    {
        public static void Main()
        {
            Saledetails obj = new Saledetails("AB123","RQA865",90,Convert.ToDateTime("09-8-2025"),20);
            obj.Sales(obj.Quantity, obj.Price);
            Saledetails.showData(obj);

            Console.Read();
        }
    }
}
