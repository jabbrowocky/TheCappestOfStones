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
        // GET: Veterinarian
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeterinarianCreate model)
        {
            return View();
        }
    }
}