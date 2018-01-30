using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using THEcapstone.Models;
using System.Net;
using System.Data.Entity;

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
                    Veterinarian model = vet;
                    VetProfileViewModel mod = new VetProfileViewModel();
                    mod.Vet = model;

                    return View(mod);
                }

            }

            return RedirectToAction("Create", "Veterinarian");

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

            return RedirectToAction("Index", "Veterinarian");
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
                if (model.VetProfile.ShowMap == true)
                {
                    prof.ShowMap = true;
                    prof.MapAddressStreet = model.VetProfile.MapAddressStreet;
                    prof.MapAddressCity = model.VetProfile.MapAddressCity;
                    prof.MapAddressState = model.VetProfile.MapAddressState;
                }
                db.VetProfiles.Add(prof);
                db.SaveChanges();
                AddProfileToVet(prof);
            }

            return RedirectToAction("Index", "Veterinarian");
        }
        private void AddProfileToVet(VetProfile model)
        {
            Veterinarian addTo = new Veterinarian();
            foreach (Veterinarian vet in db.Veterinarians)
            {
                if (User.Identity.GetUserId() == vet.UserId)
                {
                    addTo = vet;
                }
            }
            addTo.ProfileId = model.ProfileId;
            db.SaveChanges();
        }
        public ActionResult ViewProfile(int? id)
        {
            var userId = User.Identity.GetUserId();
            VetProfileViewModel model = new VetProfileViewModel();
            Veterinarian vet = db.Veterinarians.Where(e => e.UserId == userId).FirstOrDefault();
            VetProfile prof = db.VetProfiles.Where(v => v.ProfileId == id).FirstOrDefault();
            model.Vet = vet;
            model.VetProfile = prof;

            return View(model);
        }
        //public ActionResult EditProfile(int? id)
        //{
        //    var userId = User.Identity.GetUserId();
        //    VetProfileViewModel model = new VetProfileViewModel();
        //    VetProfile prof = db.VetProfiles.Find(id);
        //    Veterinarian vet = db.Veterinarians.Where(v => v.UserId == userId).FirstOrDefault() ;
        //    model.VetProfile = prof;
        //    model.Vet = vet;

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult EditProfile(VetProfileViewModel elModel)
        //{

        //    return View();
        //}
        public ActionResult Inbox(int? id)
        {
            
            VetProfileViewModel model = new VetProfileViewModel();
            model.Vet = db.Veterinarians.Where(m => m.VetId == id).FirstOrDefault();
            model.VetProfile = db.VetProfiles.Where(u => u.ProfileId == model.Vet.ProfileId).FirstOrDefault();
            model.Vet.Inbox = db.Messages.Where(e => e.TargetId == model.Vet.UserId).ToList();
            model.Vet.Inbox = model.Vet.Inbox.Where(d => d.Deleted == false).ToList();
            return View(model);
        }
        public ActionResult ReadMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            VetProfileViewModel model = new VetProfileViewModel();
            model.Msg = db.Messages.Find(id);
            model.Msg.Opened = true;
            model.Vet = db.Veterinarians.Where(u => u.UserId == userId).FirstOrDefault();
            model.VetProfile = db.VetProfiles.Where(p => p.ProfileId == model.Vet.ProfileId).FirstOrDefault();
            

            return View(model);
        }
        public ActionResult DeleteMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            VetProfileViewModel model = new VetProfileViewModel();
            model.Vet = db.Veterinarians.Where(u => u.UserId == userId).FirstOrDefault();
            model.VetProfile = db.VetProfiles.Where(u => u.ProfileId == model.Vet.ProfileId).FirstOrDefault();
            Message msg = db.Messages.Find(id);
            msg.Deleted = true;
            db.Entry(msg).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Inbox", new { id = model.Vet.VetId });
        }

    }
}