﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using THEcapstone.Models;

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
            DogWalker walker = dawgWalker;
            return View(walker);
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

            return View();
        }
    }

}