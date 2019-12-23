using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        // Ska hantera profil, intressen
        public ActionResult Index()
        {
            return View();
        }
    }
}