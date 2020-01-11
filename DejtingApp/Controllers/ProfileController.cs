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
using Newtonsoft.Json;

namespace DejtingApp.Controllers
{
    [Authorize]
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
        [Authorize]
        public ActionResult Index()
        {
            var ctx = new AppDbContext();
            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            int id = getUser();
            
            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == id).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == id).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == id).ToList();
            viewModel.Interests = ctx.Interests.Where(i => i.ProfileId == id).ToList();
            viewModel.Image = ctx.Images.FirstOrDefault(i => i.ProfileId == id);

            return View(viewModel);
        }

        [Authorize]
        public ActionResult DeleteInterest(int id)
        {
            var db = new AppDbContext();
            var interest = db.Interests.FirstOrDefault(x => x.InterestId == id);
            db.Interests.Remove(interest);
            db.SaveChanges();
            return RedirectToAction("EditInterests");

        }

        // Get: OtherProfile
        [Authorize]
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

        [Authorize]
        public ActionResult Profilepage(int profileId)
        {
            var ctx = new AppDbContext();

            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == profileId).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == profileId).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == profileId).ToList();
            viewModel.Interests = ctx.Interests.Where(i => i.ProfileId == profileId).ToList();
            viewModel.Image = ctx.Images.FirstOrDefault(i => i.ProfileId == profileId);

            return View(viewModel);
        }

        [Authorize]
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
                              Förnamn = Profile.Förnamn,
                              Efternamn = Profile.Efternamn,
                              CategoryId = Category.CategoryId,
                              CategoryName = Category.CategoryName,
                              ImagePath = ctx.Images.FirstOrDefault(a => a.ProfileId == Profile.ProfileId).ImgPath
                          }).ToList();

            var categories = ctx.Categories.ToList();
            ViewBag.Category = new SelectList(categories, "CategoryId", "CategoryName");

            return View(result);
        }

        [Authorize]
        public ActionResult EditInterests()
        {
            int id = getUser();
            AppDbContext ctx = new AppDbContext();
            var result = ctx.Interests.Where(x => x.ProfileId == id).ToList();
            return View(result);
        }


        [Authorize]
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
        [Authorize]
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
                    result.Active = Convert.ToBoolean(Request["Active"].Split(',')[0]);
                    result.Description = Request["Description"];
      
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        // GET: Profile/Delete/5
        [Authorize]
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
        [Authorize]
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

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(Image imageModel)
        {
            string filename = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;

            imageModel.ImgPath = "~/Content/Images/" + filename;
           
            filename = Path.Combine(Server.MapPath("~/Content/Images/"), filename);
            imageModel.ImageFile.SaveAs(filename);


            using (AppDbContext db = new AppDbContext())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }

        public JsonSerializer CreateSerializer()
        {
            return new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        [Authorize]
        [HttpPost]
        public void Serialize() //(string filename, List<T> Lists)
        {
            int pId = getUser();
            AppDbContext ctx = new AppDbContext();
            List<Profile> profiles = new List<Profile>();
            profiles = ctx.Profiles.Where(x => x.ProfileId == pId).ToList();

            string filename = Server.MapPath(@"~/Content/SeralizedInfos/profileinfo.txt");
            try
            {
                var serializer = CreateSerializer();
                using (var sw = new StreamWriter(filename)) //@"C:\podFeeds\profileinfo.txt"
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, profiles);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
