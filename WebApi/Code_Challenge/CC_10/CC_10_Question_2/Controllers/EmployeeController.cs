using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC_10_Question_2.Models;


namespace CC_10_Question_2.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        NorthWindDBEntities1 db = new NorthWindDBEntities1();

        [HttpGet]
        [Route("getEmployee")]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }


        [HttpGet]
        [Route("orders/{id}")]
        public IHttpActionResult GetOrders(int id)
        {
            var orders = (from o in db.Orders
                          where o.EmployeeID == id
                          select o).ToList();

            return Ok(orders);
        }

        [HttpGet]
        [Route("byCountry/{country}")]
        public IHttpActionResult GetCustBasedOnCountry(string country)
        {
            var customers = db.fn_GetCustomer_ByCountry(country).ToList();

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }

}
