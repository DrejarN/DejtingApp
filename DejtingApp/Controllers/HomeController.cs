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
        public int getUser()
        {
            var ctx = new AppDbContext();
            List<Profile> enLista = ctx.Profiles.ToList();
            Profile enprofil = enLista.FirstOrDefault(x => x.ApplicationUser == User.Identity.GetUserId());
            int id = enprofil.ProfileId;
            return id;
        }

        public ActionResult Index()
        {
            var ctx = new AppDbContext();
            var results = ctx.Profiles.Take(3).ToList();
            var VM = new ExampleUserViewModel();
            VM.Profiles = results;

            return View(VM);
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

        //Send friend request to user 
        public ActionResult AddFriend(int profileIdd, string button)
        {
            var ctx = new AppDbContext();
            var RecieverId = profileIdd; 
            var senderId = getUser();

            FriendRequest friendRequest = new FriendRequest { SenderId = senderId, RecieverId = RecieverId };

            ctx.FriendRequests.Add(friendRequest);
            ctx.SaveChanges();

            if (button.Equals("profil"))
            {
                return RedirectToAction("Profilepage", "Profile", new { profileId = profileIdd});
            }
            else
            {
                return RedirectToAction("Search", "Home");
            }
        }

        // GET: Search Results

        public ActionResult Search(string input)
        {
            var ctx = new AppDbContext();
            var results = ctx.Profiles.Where(u => u.Förnamn.Contains(input) && u.Active == true).ToList(); //&& ctx.Profiles.Where(z => z.Active.Equals(true))

            return View(results);
        }

    }
}