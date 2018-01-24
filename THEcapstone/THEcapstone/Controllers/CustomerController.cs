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
                    return View(custy);
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
                Customer toAdd = new Customer();
                toAdd.UserId = userId;
                toAdd.CustFirstName = customer.Cust.CustFirstName;
                toAdd.CustLastName = customer.Cust.CustLastName;
                customer.Address.StateId = customer.State.Id;                
                var address = CreateAddress(customer.Address);
                toAdd.AddressId = address.AddressId;
                db.Customers.Add(toAdd);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Customer");
        }
        private Addresses CreateAddress (Addresses address)
        {
            Addresses Address = new Addresses();
            Address.StateId = address.StateId;
            Address.Street = address.Street;
            Address.City = address.City;
            Address.ZipCode = address.ZipCode;
            db.Addresses.Add(Address);
            db.SaveChanges();
            return Address;
        }
       
    }
}