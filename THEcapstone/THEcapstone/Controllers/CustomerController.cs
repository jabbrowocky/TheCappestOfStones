using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using THEcapstone.Models;
using System.Data.Entity;

namespace THEcapstone.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            CustInboxViewModel model = new CustInboxViewModel();
            foreach (Customer cust in db.Customers)
            {
                if (cust.UserId == userId)
                {
                    model.Cust = cust;
                    return View(model);
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
        public ActionResult Inbox (int? id)
        {
            
            CustInboxViewModel custy = new CustInboxViewModel();
            custy.Cust = db.Customers.Where(c => c.CustId == id).FirstOrDefault();
            custy.Cust.Inbox = db.Messages.Where(m => m.TargetId == custy.Cust.UserId).ToList();
            custy.Cust.Inbox = custy.Cust.Inbox.Where(d => d.Deleted == false).ToList();
            return View(custy);
        }
        public ActionResult ReadMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            CustInboxViewModel mod = new CustInboxViewModel();
            mod.Cust = db.Customers.Where(u => u.UserId == userId).FirstOrDefault();
            mod.Msg = db.Messages.Find(id);
            mod.Msg.Opened = true;

            return View(mod);
        }
        public ActionResult DeleteMsg(int? id)
        {
            var userId = User.Identity.GetUserId();

            CustInboxViewModel mod = new CustInboxViewModel();
            mod.Cust = db.Customers.Where(c => c.UserId == userId).FirstOrDefault();        
            mod.Msg = db.Messages.Find(id);
            mod.Msg.Deleted = true;
            db.Entry(mod.Msg).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Inbox", new { id = mod.Cust.CustId });
        }
        public ActionResult FindServices()
        {
            var userId = User.Identity.GetUserId();            
            
            FindServicesViewModel serv = new FindServicesViewModel();
            serv.Cust = db.Customers.Where(u => u.UserId == userId).FirstOrDefault();
            serv.Vet = db.Veterinarians.ToList();
            serv.Sitter = db.PetSitters.ToList();
            serv.Walker = db.DogWalkers.ToList();

            return View(serv);
        }
        public ActionResult ViewVetProfile(int? id)
        {
            var userId = User.Identity.GetUserId();
            ViewProfileModel model = new ViewProfileModel();
            model.Cust = db.Customers.Where(u => u.UserId == userId).FirstOrDefault();
            var vet = db.Veterinarians.Where(v => v.VetId == id).FirstOrDefault();
            model.VetProfile = db.VetProfiles.Where(p => p.ProfileId == vet.ProfileId).FirstOrDefault();

            return View(model);
           
        }
        public ActionResult ViewSitterProfile(int? id)
        {
            return View();
        }
        public ActionResult SendMsg(int? id, string name)
        {
            var userId = User.Identity.GetUserId();
            CustomerSendModel model = new CustomerSendModel();
            model.Cust = db.Customers.Where(u => u.UserId == userId).FirstOrDefault();
            switch (name)
            {
                case "Veterinarian":
                    model.Vet = db.Veterinarians.Where(p => p.ProfileId == id).FirstOrDefault();
                    model.Msg = new Message();
                    model.Msg.TargetId = model.Vet.UserId;
                    model.Msg.AuthorId = model.Cust.UserId;
                    break;
                default:
                    break;
            }
            
            return View(model);

        }
        [HttpPost]
        public ActionResult SendMsg(CustomerSendModel model)
        {
            Message message = model.Msg;
            message.TargetId = model.Vet.UserId;
            message.AuthorId = model.Cust.UserId;
            message.SentOn = DateTime.Today.Date;
            db.Messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index","Customer", model.Cust);
        }
    }
}