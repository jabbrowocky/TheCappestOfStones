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
                    VetProfileViewModel model = new VetProfileViewModel();
                    model.Vet = vet;
                    return View(model);
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
        public ActionResult CreateProfile(int? id)
        {
            VetProfileViewModel model = new VetProfileViewModel();
            foreach (Veterinarian vet in db.Veterinarians)
            {
                if (vet.VetId == id)
                {

                    model.Vet = vet;
                }
            }
            return View(model);   
        }

        [HttpPost]
        public ActionResult CreateProfile(VetProfileViewModel model)
        {
            var userId = User.Identity.GetUserId();
            VetProfile prof = new VetProfile();
            if (ModelState.IsValid)
            {
                prof.UserDescription = model.VetProfile.UserDescription;
                prof.StaffDescription = model.VetProfile.StaffDescription;
                prof.ServicesDescription = model.VetProfile.ServicesDescription;
                if(model.VetProfile.ShowMap == true)
                {
                    prof.ShowMap = true;
                    prof.MapAddress = model.VetProfile.MapAddress;
                }
                db.VetProfiles.Add(prof);
                db.SaveChanges();
                AddProfileToVet(prof);
            }
            return RedirectToAction("Index","Veterinarian");
        }
        private void AddProfileToVet(VetProfile model)
        {
            Veterinarian addTo = new Veterinarian();
            foreach (Veterinarian vet in db.Veterinarians)
            {
                if (User.Identity.GetUserId() == vet.UserId)
                {
                   addTo  = vet;
                }
            }
            addTo.ProfileId = model.ProfileId;
            db.SaveChanges();
        }
    }
}