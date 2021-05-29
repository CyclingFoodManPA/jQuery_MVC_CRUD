// https://www.aspsnippets.com/Articles/MVC-jQuery-CRUD-Select-Insert-Edit-Update-and-Delete-using-jQuery-AJAX-and-JSON-in-ASPNet-MVC.aspx

#region usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jQuery_MVC_CRUD.Context;

#endregion usings

namespace jQuery_MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CustomerEntities _db = new CustomerEntities();
            List<Customer> customers = _db.Customers.ToList();

            return View(customers);
        }

        [HttpPost]
        public JsonResult InsertCustomer(Customer customer)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return Json(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers
                    where c.CustomerId == customer.CustomerId
                    select c).FirstOrDefault();
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Country = customer.Country;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int customerId)
        {
            using (CustomerEntities entities = new CustomerEntities())
            {
                Customer customer = (from c in entities.Customers
                    where c.CustomerId == customerId
                    select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }

            return new EmptyResult();
        }
    }
}
