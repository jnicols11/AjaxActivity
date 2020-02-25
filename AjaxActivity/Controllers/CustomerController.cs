using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxActivity.Models;

namespace AjaxActivity.Controllers
{
    public class CustomerController : Controller
    {

        List<CustomerModel> customers;

        public CustomerController()
        {
            customers = new List<CustomerModel>();
            customers.Add(new CustomerModel(0, "Sherry", 37));
            customers.Add(new CustomerModel(1, "Jordan", 20));
            customers.Add(new CustomerModel(2, "Shad", 21));
            customers.Add(new CustomerModel(3, "Cyrus", 21));
            customers.Add(new CustomerModel(4, "Shaylah", 20));
            customers.Add(new CustomerModel(5, "Brandon", 24));
            customers.Add(new CustomerModel(6, "Tammy", 45));
        }//end default constructor

        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<CustomerModel>, CustomerModel> tuple;
            tuple = new Tuple<List<CustomerModel>, CustomerModel>(customers, customers[3]);

            return View("Customer", tuple);
        }//end index

        [HttpPost]
        public ActionResult OnSelectCustomer(string CustomerNumber)
        {
            int customerID = Int32.Parse(CustomerNumber);
            Tuple<List<CustomerModel>, CustomerModel> tuple;
            tuple = new Tuple<List<CustomerModel>, CustomerModel>(customers, customers[customerID]);

            return PartialView("~/Views/Shared/_CustomerDetails.cshtml", customers[customerID]);
        }//end OnSelectCustomer
    }//end controller class
}//end namespace