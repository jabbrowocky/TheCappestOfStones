using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using THEcapstone.Models;

namespace THEcapstone.Controllers
{
    
    public class VeterinarianController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Veterinarian
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            foreach (Veterinarian vet in db.Veterinarians)
            {
                if (vet.UserId == userId)
                {
                    return View();
                }
                
            }
            return RedirectToAction("Create","Veterinarian");

        }
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                VeterinarianCreate model = new VeterinarianCreate();
                model.States = db.States.Select(m => m).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(VeterinarianCreate model)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                Veterinarian Veterino = new Veterinarian();
                Veterino.UserId = userId;
                Veterino.VetName = model.Vet.VetName;
                model.Address.StateId = model.State.Id;
                var Addy = CreateAddress(model.Address);
                Veterino.AddressId = Addy.AddressId;
                db.Veterinarians.Add(Veterino);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Veterinarian");
        }
        private Addresses CreateAddress(Addresses address)
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