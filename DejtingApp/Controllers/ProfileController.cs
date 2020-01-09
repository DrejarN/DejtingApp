using DejtingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;

namespace DejtingApp.Controllers
{
    public class ProfileController : Controller
    {
        // Hämtar ProfileId på inloggad användare
        public int getUser()
        {
            var ctx = new AppDbContext();
            List<Profile> enLista = ctx.Profiles.ToList();
            Profile enprofil = enLista.FirstOrDefault(x => x.ApplicationUser == User.Identity.GetUserId());
            int id = enprofil.ProfileId;
            return id;
        }
        // GET: OwnProfile
        public ActionResult Index()
        {
            var ctx = new AppDbContext();
            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            int id = getUser();
            
            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == id).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == id).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == id).ToList();
            viewModel.ProfileViews = ctx.ProfileViews.Where(v => v.RecieveClickId == id).OrderByDescending(v => v.ProfileViewId).Take(5).ToList(); //OrderByDesc kanske ska filtrera på Recieveclicks?

            return View(viewModel);
        }

        // Get: Other profile & ticks profileViews

        public ActionResult Profilepage(int profileId, int currentUserId) //currentUserId == anropare || profileId = profil vi ska till
        {
            var ctx = new AppDbContext();

            //Ticker för ProfileViews.
            ProfileView profileView = new ProfileView() { RecieveClickId = profileId, SendClickId = currentUserId };
            ctx.ProfileViews.Add(profileView);
            ctx.SaveChanges();

            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == profileId).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == profileId).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == profileId).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ViewFriendList(int profileId)
        {
            var ctx = new AppDbContext();
            FriendListViewModel viewModel = new FriendListViewModel();

            var result = (from Friend in ctx.Friends
                          join Category in ctx.Categories on Friend.CategoryId equals Category.CategoryId
                          join Profile in ctx.Profiles on Friend.RecieverId equals Profile.ProfileId
                          where Friend.RecieverId != profileId
                          select new FriendListViewModel
                          {
                              ProfileId = Profile.ProfileId,
                              ImagePath = Profile.ImagePath,
                              Förnamn = Profile.Förnamn,
                              Efternamn = Profile.Efternamn,
                              CategoryId = Category.CategoryId,
                              CategoryName = Category.CategoryName,
                              Categories = ctx.Categories.ToList()

                          }).ToList();


            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (AppDbContext dbModel = new AppDbContext())
            {
                return View(dbModel.Profiles.Where(x => x.ProfileId == id).FirstOrDefault());
            }
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection profil)
        {
            try
            {
                using (AppDbContext dbModel = new AppDbContext())
                {
                    var result = dbModel.Profiles.SingleOrDefault(o => o.ProfileId == id);
                    result.Förnamn = Request["Förnamn"];
                    result.Efternamn = Request["Efternamn"];
                    result.Födelseår = Convert.ToDateTime(Request["Födelseår"]);
                    result.Description = Request["Description"];
      
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
