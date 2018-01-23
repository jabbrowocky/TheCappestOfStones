using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THEcapstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var userId = User.Identity.GetUserId();
            
            if (User.IsInRole("Customer"))
            {                
                return RedirectToAction("Index", "Customer");
            }
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
        public ActionResult ApproveRole(string id)
        {
            var user = (from data in db.Users where data.Id == id select data).First();
            var role = (from data in db.Users where data.Id == id select data.RoleToAdd).FirstOrDefault().ToString();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            userManager.AddToRole(user.Id, role);            
            db.SaveChanges();
            user.RoleToAdd = null;
            db.SaveChanges();
            return RedirectToAction("Admin","Home");
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