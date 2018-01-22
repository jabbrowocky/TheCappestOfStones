using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THEcapstone.Models;
using Microsoft.AspNet.Identity;

namespace THEcapstone.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            //var test = (from x in db.Users where x.Id == " " select x);
            return View();
        }
        public ActionResult Admin()
        {

            
            if (User.IsInRole("Admin"))
            {
                var unassignedUsers = (from u in db.Users where u.RoleToAdd != "Customer" && u.RoleToAdd != null select u).ToList();
                return View(unassignedUsers);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}