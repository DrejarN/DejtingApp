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
        // GET: Profile
        public ActionResult Index()
        {
            //using (AppDbContext dbModel = new AppDbContext())

            //{
            //    return View(dbModel.Profiles.ToList());
            //}

            var ctx = new AppDbContext();


            ProfilePageViewModels viewModel = new ProfilePageViewModels();

            int id = getUser();
            
            viewModel.Profiles = ctx.Profiles.Where(x => x.ProfileId == id).ToList();
            viewModel.Messages = ctx.Messages.Where(o => o.RecieverId == id).ToList();
            viewModel.Friends = ctx.Friends.Where(f => f.RecieverId == id).ToList();

            return View(viewModel);
        }

        public int getUser()
        {
            var ctx = new AppDbContext();
            List<Profile> enLista = ctx.Profiles.ToList();
            Profile enprofil = enLista.FirstOrDefault(x => x.ApplicationUser == User.Identity.GetUserId());
            int id = enprofil.ProfileId;
            return id;
        }

        //[HttpGet]
        //public ActionResult Add(int id)
        //{
        //    using (AppDbContext dbModel = new AppDbContext())
        //    {
        //        return View(dbModel.Profiles.Where(x => x.ProfileId == id).FirstOrDefault());
        //    }
        //}

        //[HttpPost]
        //public ActionResult Add(int id, HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //        try
        //        {

        //            using (AppDbContext dbModel = new AppDbContext())
        //            {
        //                var result = dbModel.Profiles.SingleOrDefault(o => o.ProfileId == id);
        //                result.ImagePath = Path.GetFileName(file.FileName);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.Message = "ERROR:" + ex.Message.ToString();
        //        }
        //    else
        //    {
        //        ViewBag.Message = "You have not specified a file.";
        //    }
        //    return RedirectToAction("Index");
        //}


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
