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
    public class PetSitterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: PetSitter
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var sitter = db.PetSitters.Where(d => d.UserId == userId).FirstOrDefault();
            if (sitter == null)
            {
                                
                return RedirectToAction("Create", "PetSitter");
            }
            PSViewModel model = new PSViewModel();
            model.Sitter = sitter;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                PSCreateModel model = new PSCreateModel();
                model.Sitter = new PetSitter();
                model.StateList = db.States.Select(m => m).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(PSCreateModel formObject)
        {
            var userId = User.Identity.GetUserId();
            PetSitter toAdd = new PetSitter();
            if (ModelState.IsValid)
            {
                toAdd.UserId = userId;
                toAdd.SitterFirstName = formObject.Sitter.SitterFirstName;
                toAdd.SitterLastName = formObject.Sitter.SitterLastName;
                formObject.Address.StateId = formObject.State.Id;
                var address = CreateAddress(formObject.Address);
                toAdd.AddressId = address.AddressId;
                db.PetSitters.Add(toAdd);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "PetSitter", toAdd);
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
                PSViewModel pS = new PSViewModel();
                PetSitter petSitter = db.PetSitters.Where(u => u.SitterId == id).FirstOrDefault();
                pS.Sitter = petSitter;
                return View(pS);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult CreateProfile(PSViewModel psModel)
        {
            var userId = User.Identity.GetUserId();
            PetSitterProfile profile = new PetSitterProfile();
            if (ModelState.IsValid)
            {
                profile.BriefDescription = psModel.SitterProf.BriefDescription;
                profile.SitterFirstName = psModel.SitterProf.SitterFirstName;
                profile.SitterLastName = psModel.SitterProf.SitterLastName;
                profile.CityName = psModel.SitterProf.CityName;
                profile.ExperienceDescription = psModel.SitterProf.ExperienceDescription;
                db.SitterProfiles.Add(profile);
                db.SaveChanges();
                AddProfileToSitter(profile);
            }

            return RedirectToAction("Index", "PetSitter");
        }
        private void AddProfileToSitter(PetSitterProfile model)
        {
            PetSitter addTo = new PetSitter();
            var userId = User.Identity.GetUserId();
            addTo = db.PetSitters.Where(u => u.UserId == userId).FirstOrDefault();
            addTo.ProfileId = model.Id;
            db.SaveChanges();
        }
        public ActionResult ViewProfile(int? id)
        {
            var userId = User.Identity.GetUserId();
            PSViewModel model = new PSViewModel();
            model.Sitter = db.PetSitters.Where(d => d.UserId == userId).FirstOrDefault();
            model.SitterProf = db.SitterProfiles.Where(u => u.Id == id).FirstOrDefault();
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
            PSViewModel model = new PSViewModel();
            model.Sitter = db.PetSitters.Where(m => m.SitterId == id).FirstOrDefault();
            model.Sitter.Inbox = db.Messages.Where(e => e.TargetId == model.Sitter.UserId).ToList();
            model.Sitter.Inbox = model.Sitter.Inbox.Where(d => d.Deleted == false).ToList();
            return View(model);
        }
        public ActionResult ReadMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            PSViewModel model = new PSViewModel();
            model.Msg = db.Messages.Find(id);
            model.Msg.Opened = true;
            db.Entry(model.Msg).State = EntityState.Modified;
            db.SaveChanges();
            model.Sitter = db.PetSitters.Where(u => u.UserId == userId).FirstOrDefault();
            model.SitterProf = db.SitterProfiles.Where(p => p.Id == model.Sitter.ProfileId).FirstOrDefault();


            return View(model);
        }
        public ActionResult DeleteMsg(int? id)
        {
            var userId = User.Identity.GetUserId();
            PSViewModel model = new PSViewModel();
            model.Sitter = db.PetSitters.Where(u => u.UserId == userId).FirstOrDefault();
            model.SitterProf = db.SitterProfiles.Where(u => u.Id == model.Sitter.ProfileId).FirstOrDefault();
            Message msg = db.Messages.Find(id);
            msg.Deleted = true;
            db.Entry(msg).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Inbox", new { id = model.Sitter.SitterId });
        }
        public ActionResult ReplyToMessage(int? id)
        {
            var userId = User.Identity.GetUserId();
            PSViewModel model = new PSViewModel();
            model.Msg = db.Messages.Where(i => i.MsgId == id).FirstOrDefault();
            model.Sitter = db.PetSitters.Where(u => u.UserId == userId).FirstOrDefault();
            return View(model);

        }
        [HttpPost]
        public ActionResult ReplyToMessage(PSViewModel modelObject)
        {
            Message mess = new Message();
            mess.MsgText = modelObject.Msg.MsgText;
            mess.TargetId = modelObject.Msg.AuthorId;
            mess.AuthorId = modelObject.Sitter.UserId;
            mess.SentOn = DateTime.Today.Date;
            db.Messages.Add(mess);
            db.SaveChanges();
            PetSitter sitter = db.PetSitters.Where(u => u.UserId == modelObject.Sitter.UserId).FirstOrDefault();
            return RedirectToAction("Inbox", new { id = sitter.SitterId });
        }
        public ActionResult ClientRequests (int? id)
        {
            return View();
        }
    }
}
