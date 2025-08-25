using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Challenge_9.Models;

namespace Code_Challenge_9.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        NorthWindDBEntities db = new NorthWindDBEntities();

        public ActionResult Index()
        {
            List<Customer> customersList = db.Customers.ToList();
            return View(customersList);
        }

        public ActionResult customersBelongsToGermany()
        {
            var res = (from c in db.Customers 
                       where c.Country == "Germany"
                       select c).ToList();
            return View(res);
        }

        public ActionResult customerByOrderId()
        {
            var res = (from o in db.Orders
                       where o.OrderID == 10248
                       select o.Customer).First();
            return View(res);
        }
    }
}