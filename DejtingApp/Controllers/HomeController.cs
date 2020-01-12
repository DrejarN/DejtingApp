using DejtingApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            try
            {
                var ctx = new AppDbContext();
                var results = (from Profile in ctx.Profiles
                               select new ExampleUserViewModel
                               {
                                   ProfileId = Profile.ProfileId,
                                   Förnamn = Profile.Förnamn,
                                   Födelseår = Profile.Födelseår,
                                   ImagePath = ctx.Images.FirstOrDefault(a => a.ProfileId == Profile.ProfileId).ImgPath

                               }).Take(4).ToList();

                return View(results);
            }
            catch (Exception)
            {

                return RedirectToAction("GenericError", "ErrorHandler");

            }
        }

        //Send friend request to user 
        public ActionResult AddFriend(int profileIdd, string button)
        {
            try
            {
                var ctx = new AppDbContext();
                var RecieverId = profileIdd;
                var senderId = getUser();

                FriendRequest friendRequest = new FriendRequest { SenderId = senderId, RecieverId = RecieverId };

                ctx.FriendRequests.Add(friendRequest);
                ctx.SaveChanges();

                if (button.Equals("profil"))
                {
                    return RedirectToAction("Profilepage", "Profile", new { profileId = profileIdd });
                }
                else
                {
                    return RedirectToAction("Search", "Home");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("GenericError", "ErrorHandler");

            }
        }

        // GET: Search Results

        public ActionResult Search(string input)
        {
            try
            {
                var ctx = new AppDbContext();

                var result = (from Profile in ctx.Profiles
                              where Profile.Förnamn.Contains(input) && Profile.Active == true
                              select new SearchViewModel
                              {
                                  ImagePath = ctx.Images.FirstOrDefault(a => a.ProfileId == Profile.ProfileId).ImgPath,
                                  ProfileId = Profile.ProfileId,
                                  Förnamn = Profile.Förnamn,
                                  Efternamn = Profile.Efternamn,
                                  Födelseår = Profile.Födelseår

                              }).ToList();

                return View(result);
            }
            catch (Exception)
            {

                return RedirectToAction("GenericError", "ErrorHandler");

            }

        }
    }
}