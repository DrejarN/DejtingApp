using DejtingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        // Ska hantera profil, intressen
        public ActionResult Index()
        {
            var ctx = new AppDbContext();
            var viewModel = new ProfileIndexViewModel
            {
                Profiles = ctx.Profiles.ToList()
            };

            return View(viewModel);
        }

        public ActionResult getDescription()
        {
            var ctx = new AppDbContext();
            var viewModel = new ProfilePageIndexViewModel
            {
                ProfilePages = ctx.ProfilePages.ToList()
            };

            return View(viewModel); 
        }

        //public ActionResult getProfile()
        //{
        //    var ctx = new AppDbContext();
        //    var viewModel = new ProfileIndexViewModel
        //    {
        //        Profiles = ctx.Profiles.ToList()
        //    };
        //    return View(viewModel);
        //}
    }
}