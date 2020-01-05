using DejtingApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public ActionResult AddFriend(int? profileId)
        {
            var ctx = new AppDbContext();
            var RecieverId = profileId; //Inget hämtas: null
            var sender = User.Identity.GetUserId();
            var SenderId = (from Profile in ctx.Profiles
                            where Profile.ApplicationUser == sender
                            orderby Profile.ProfileId
                            select profileId).First(); //Inget hämtas: null

             FriendRequest friendRequest = new FriendRequest { SenderId = SenderId, RecieverId = RecieverId };

            ctx.FriendRequests.Add(friendRequest);
            ctx.SaveChanges();

            return Content("Hiho");
        }


        // GET: Search Results
        public ActionResult SearchResults(string input) 
        {
            var ctx = new AppDbContext();
            //var profiles = ctx.Profiles.ToList();
            var results = ctx.Profiles.Where(u => u.Förnamn.Contains(input)).ToList(); //&& ctx.Profiles.Where(z => z.Active.Equals(true))
            //var searchResults = new IEnumerable<SearchViewModel>;


            return View();
        }

        // POST: Search Results

        public ActionResult Search(string input)
        {
            var ctx = new AppDbContext();
            var results = ctx.Profiles.Where(u => u.Förnamn.Contains(input)).ToList(); //&& ctx.Profiles.Where(z => z.Active.Equals(true))

            return View(results);
        }


        //public ActionResult SearchUser()
        //{
        //    var ctx = new AppDbContext();
        //    var viewModel = new SearchViewModel
        //    {
        //        Profiles = ctx.Profiles.ToList()
        //    };

        //    return View(viewModel);
        //}

        //public ActionResult Profile()
        //{
        //    ViewBag.Message = "Your profile page";

        //    return View();
        //}
    }
}