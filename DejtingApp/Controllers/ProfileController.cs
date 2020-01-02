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
        AppDbContext db = new AppDbContext();
        // GET: Profile
        // Ska hantera profil, intressen
        public ActionResult Index(int? profileId)
        {
            if (profileId == null) { profileId = 1; }; //hårdkodar in pga finns ej real thing

            var ctx = new AppDbContext();
            var ctx1 = new ApplicationDbContext();

            //var quet2 = ctx.Messages.ToList();

            //var quueeryy =
            //    (from p in ctx.Profiles
            //     join pp in ctx.ProfilePages on p.ProfileID equals pp.ProfileId
            //     join m in ctx.Messages on pp.ProfilePageId equals m.RecieverId
            //     where p.ProfileID == profileId
            //     select new ProfilePageIndexViewModel
            //     {
            //         profilePage = pp,
            //         profile = p,
            //         Messages = m
            //         //Messages = m.ToList()
            //         //Messages = m.ToList()
            //         //Messages = ctx.Messages.ToList().FindAll(x => x.RecieverId == profileId)
            //     }).ToList();

            var vM = new ProfilePageIndexViewModel
            {
                profilePage = ctx.ProfilePages.ToList().Find(x => x.ProfilePageId == profileId),
                profile = ctx.Profiles.ToList().Find(x => x.ProfileID == profileId),
                Messages = ctx.Messages.ToList().FindAll(x => x.RecieverId == profileId)
            };

            return View(vM);
        }

        //public ActionResult Index()
        //{
        //    var ctx = new AppDbContext();
        //    var ctx1 = new ApplicationDbContext();
        //    var vM = new ProfilePageViewModel
        //    {
        //        ProfilePages = ctx.ProfilePages.ToList(),
        //        Profiles = ctx.Profiles.ToList()
        //    };

        //    return View(vM);
        //}

        public ActionResult IndexUser(int? userId)
        {
            var ctx = new AppDbContext();
            var vM = new ProfilePageViewModel
            {
                ProfilePages = ctx.ProfilePages.ToList(),
                Profiles = ctx.Profiles.ToList()
            };

            return View(vM);
        }


        //public ActionResult getMessageName()
        //{
        //    var senderName = db.Profiles.
        //    Join(db.ProfilePages, u => u.ProfileID, uir => uir.ProfilePageId,
        //(u, uir) => new { u, uir }).
        //Join(db.Messages, r => r.uir.ProfilePageId, ro => ro.SenderId, (r, ro) => new { r, ro })
        //.Where(m => m.ro.SenderId == 1);
        //    .Where(m => m.r.u.UserId == 1)
        //    .Select(m => new AddUserToRole
        //    {
        //        UserName = m.r.u.UserName,
        //        RoleName = m.ro.RoleName
        //    });




            //         var senderName = db.Messages.Include(u => u.).        .Include(u => u.UserProfile).Include(u => u.Roles)
            // .Select(m => new
            //{
            //    UserName = u.UserProfile.UserName,
            //    RoleName = u.Roles.RoleName
            //});
        //    return View();
        //}

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