using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DejtingApp.Models;

namespace DejtingApp.Controllers
{
    public class PersonController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var ctx = new AppDbContext();
            var viewModel = new ProfilePageViewModels
            {
                Profiles = ctx.Profiles.ToList()
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult RegisterUser(Profile model)
        {
            var ctx = new AppDbContext();
            ctx.Profiles.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}