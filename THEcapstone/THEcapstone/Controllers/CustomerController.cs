using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using THEcapstone.Models;

namespace THEcapstone.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Customer custy;
            foreach (Customer cust in db.Customers)
            {
                if (cust.UserId == userId)
                {
                    custy = cust;
                    return View();
                }
            }
            
            return RedirectToAction("Create");
        }

        public ActionResult Create()
        {

            
                
            if (User.Identity.IsAuthenticated)
            {
                CustomerCreateModel model = new CustomerCreateModel();
                model.StateList = db.States.Select(m => m).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]       
        public ActionResult Create(CustomerCreateModel customer)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                customer.Cust.UserId = userId;
                customer.State.Id = customer.Address.StateId;
                var address = CreateAddress(customer.Address);                
                address.AddressId = customer.Cust.AddressId;
                db.Customers.Add(customer.Cust);
                db.SaveChanges();
            }
            return View();
        }
        private Addresses CreateAddress (Addresses address)
        {
            
            db.Addresses.Add(address);
            db.SaveChanges();
            return address;
        }
       
    }
}