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
            viewModel.Interests = ctx.Interests.Where(i => i.ProfileId == id).ToList();

            return View(viewModel);
        }

        public ActionResult DeleteInterest(int id)
        {
            var db = new AppDbContext();
            var interest = db.Interests.FirstOrDefault(x => x.InterestId == id);
            db.Interests.Remove(interest);
            db.SaveChanges();
            return RedirectToAction("EditInterests");

        }

        [HttpPost]
        public ActionResult CreateNewInterest()
        {
            var db = new AppDbContext();
            int id = getUser();
            var interest = new Interest
            {
                InterestName = Request["Text"],
                ProfileId = id
            };
            db.Interests.Add(interest);
            db.SaveChanges();
            return RedirectToAction("EditInterests");
        }

        // Get: OtherProfile
        [HttpPost]
        public void DeleteMessage(int id)
        {
            using (var db = new AppDbContext())
            {
                var result = db.Messages.ToList();
                var message = result.FirstOrDefault(o => o.MessageId == id);
                db.Messages.Remove(message);
                db.SaveChanges();
            }
        }
        public ActionResult Profilepage(int profileId)
        {
            var ctx = new AppDbContext();

            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == profileId).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == profileId).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == profileId).ToList();
            viewModel.Interests = ctx.Interests.Where(i => i.ProfileId == profileId).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult ViewFriendList(int profileId)
        {
            var ctx = new AppDbContext();
            FriendListViewModel viewModel = new FriendListViewModel();

            var result = (from Friend in ctx.Friends
                          join Category in ctx.Categories on Friend.CategoryId equals Category.CategoryId
                          join Profile in ctx.Profiles on Friend.SenderId equals Profile.ProfileId
                          where Friend.RecieverId == profileId
                          && Profile.Active == true
                          select new FriendListViewModel
                          {
                              ProfileId = Profile.ProfileId,
                              ImagePath = Profile.ImagePath,
                              Förnamn = Profile.Förnamn,
                              Efternamn = Profile.Efternamn,
                              CategoryId = Category.CategoryId,
                              CategoryName = Category.CategoryName,
                          }).ToList();

            var categories = ctx.Categories.ToList();
            ViewBag.Category = new SelectList(categories, "CategoryId", "CategoryName");

            return View(result);
        }

        public ActionResult EditInterests()
        {
            int id = getUser();
            AppDbContext ctx = new AppDbContext();
            var result = ctx.Interests.Where(x => x.ProfileId == id).ToList();
            return View(result);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (AppDbContext dbModel = new AppDbContext())
            {
                var profil = dbModel.Profiles.SingleOrDefault(x => x.ProfileId == id);
                var result = new EditViewModel
                {
                    Förnamn = profil.Förnamn,
                    Efternamn = profil.Efternamn,
                    Födelseår = profil.Födelseår,
                    Active = profil.Active,
                    Description = profil.Description,
                    Interests = dbModel.Interests.Where(x => x.ProfileId == id).ToList()
                };
                return View(result);
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

        [HttpPost]
        public ActionResult EditStatus(int id, FormCollection dropdownValues)
        {
            int loggedIn = getUser();
            var StatusName = dropdownValues["Category"].ToString();
            AppDbContext dbModel = new AppDbContext();
            if(StatusName != "")
            {   
                int cID = Int32.Parse(dropdownValues["Category"]);
                var result = dbModel.Friends.SingleOrDefault(o => o.RecieverId == loggedIn && o.SenderId == id);
                result.CategoryId = cID;
                dbModel.SaveChanges();
            }

            return RedirectToAction("ViewFriendList", new { profileId = loggedIn });
        }
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
