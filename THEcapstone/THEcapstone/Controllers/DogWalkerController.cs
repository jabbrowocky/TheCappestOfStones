using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using THEcapstone.Models;
using System.Data.Entity;

namespace THEcapstone.Controllers
{
    public class DogWalkerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: DogWalker
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();            
            var dawgWalker = db.DogWalkers.Where(d => d.UserId == userId).FirstOrDefault();
            if (dawgWalker == null)
            {
                
                return RedirectToAction("Create", "DogWalker");
            }
            DWViewModel model = new DWViewModel();
            model.Walker = dawgWalker;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                DogWalkerCreateModel model = new DogWalkerCreateModel();
                model.Walker = new DogWalker();
                model.StateList = db.States.Select(m => m).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(DogWalkerCreateModel formObject)
        {
            var userId = User.Identity.GetUserId();
            DogWalker toAdd = new DogWalker();
            if (ModelState.IsValid)
            {                
                toAdd.UserId = userId;
                toAdd.WalkerFirstName = formObject.Walker.WalkerFirstName;
                toAdd.WalkerLastName = formObject.Walker.WalkerLastName;
                formObject.Address.StateId = formObject.State.Id;
                var address = CreateAddress(formObject.Address);
                toAdd.AddressId = address.AddressId;
                db.DogWalkers.Add(toAdd);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "DogWalker", toAdd);
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
            if (User.Identity.IsAuthenticated)
            {
                DWViewModel vM = new DWViewModel();
                DogWalker walkerModel = db.DogWalkers.Where(u => u.WalkerId == id).FirstOrDefault();
                vM.Walker = walkerModel;
                return View(vM);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult CreateProfile(DWViewModel vModel)
        {
            var userId = User.Identity.GetUserId();
            WalkerProfile profile = new WalkerProfile();
            if (ModelState.IsValid)
            {
                profile.UserDiscription = vModel.WalkerProf.UserDiscription;
                profile.WalkerFirstName = vModel.WalkerProf.WalkerFirstName;
                profile.WalkerLastName = vModel.WalkerProf.WalkerLastName;
                profile.DogTypePreference = vModel.WalkerProf.DogTypePreference;                
                db.WalkerProfiles.Add(profile);
                db.SaveChanges();
                AddProfileToWalker(profile);
            }

            return RedirectToAction("Index", "DogWalker");
        }
        private void AddProfileToWalker(WalkerProfile model)
        {
            DogWalker addTo = new DogWalker();
            var userId = User.Identity.GetUserId();
            addTo = db.DogWalkers.Where(u => u.UserId == userId).FirstOrDefault();
            addTo.ProfileId = model.Id;
            db.SaveChanges();
        }
        public ActionResult ViewProfile(int? id)
        {
            var userId = User.Identity.GetUserId();
            DWViewModel model = new DWViewModel();
            model.Walker = db.DogWalkers.Where(d => d.UserId == userId).FirstOrDefault();
            model.WalkerProf = db.WalkerProfiles.Where( u => u.Id == id).FirstOrDefault();
            return View(model);
        }
        public ActionResult Inbox(int? id)
        {

            //VetProfileViewModel model = new VetProfileViewModel();
            //model.Vet = db.Veterinarians.Where(m => m.VetId == id).FirstOrDefault();
            //model.VetProfile = db.VetProfiles.Where(u => u.ProfileId == model.Vet.ProfileId).FirstOrDefault();
            //model.Vet.Inbox = db.Messages.Where(e => e.TargetId == model.Vet.UserId).ToList();
            //model.Vet.Inbox = model.Vet.Inbox.Where(d => d.Deleted == false).ToList();
            //return View(model);
            DWViewModel model = new DWViewModel();
            model.Walker = db.DogWalkers.Where(m => m.WalkerId == id).FirstOrDefault();
            model.Walker.Inbox = db.Messages.Where(e => e.TargetId == model.Walker.UserId).ToList();
            model.Walker.Inbox = model.Walker.Inbox.Where(d => d.Deleted == false).ToList();
            return View(model);
        }
        public ActionResult ReadMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            DWViewModel model = new DWViewModel();
            model.Msg = db.Messages.Find(id);
            model.Msg.Opened = true;
            db.Entry(model.Msg).State = EntityState.Modified;
            db.SaveChanges();
            model.Walker = db.DogWalkers.Where(u => u.UserId == userId).FirstOrDefault();
            model.WalkerProf = db.WalkerProfiles.Where(p => p.Id == model.Walker.ProfileId).FirstOrDefault();


            return View(model);
        }
        public ActionResult DeleteMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            DWViewModel model = new DWViewModel();
            model.Walker = db.DogWalkers.Where(u => u.UserId == userId).FirstOrDefault();
            model.WalkerProf = db.WalkerProfiles.Where(u => u.Id == model.Walker.ProfileId).FirstOrDefault();
            Message msg = db.Messages.Find(id);
            msg.Deleted = true;
            db.Entry(msg).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Inbox", new { id = model.Walker.WalkerId });
        }
        public ActionResult ReplyToMessage(int? id)
        {
            var userId = User.Identity.GetUserId();
            DWViewModel model = new DWViewModel();
            model.Msg = db.Messages.Where(i => i.MsgId == id).FirstOrDefault();
            model.Walker = db.DogWalkers.Where(u => u.UserId == userId).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public ActionResult ReplyToMessage(DWViewModel modelObject)
        {
            Message mess = new Message();
            mess.MsgText = modelObject.Msg.MsgText;
            mess.TargetId = modelObject.Msg.AuthorId;
            mess.AuthorId = modelObject.Walker.UserId;
            mess.SentOn = DateTime.Today.Date;
            db.Messages.Add(mess);
            db.SaveChanges();
            Customer cust = db.Customers.Where(u => u.UserId == modelObject.Walker.UserId).FirstOrDefault();
            return RedirectToAction("Inbox", new { id = cust.CustId });
        }
        public ActionResult ClientRequests (int? id)
        {
            return View();
        }
    }

}