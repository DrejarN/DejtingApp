using DejtingApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class InterestController : Controller
    {
        [HttpPost]
        public ActionResult CreateNewInterest(Interest interest)
        {
            var db = new AppDbContext();
            int id = getUser();
            var newinterest = new Interest
            {

                InterestName = interest.InterestName,
                ProfileId = id
            };
            db.Interests.Add(newinterest);
            db.SaveChanges();
            return RedirectToAction("EditInterests", "Profile") ;
        }

        [HttpGet]
        public string DoWeMatch(int id)
        {
            int pid = getUser();
            var ctx = new AppDbContext();
            var viewerInt = (from interests in ctx.Interests where interests.ProfileId == pid select interests.InterestName).ToList();
            var profileInt = (from interest in ctx.Interests where interest.ProfileId == id select interest.InterestName).ToList();

            var result = viewerInt.Where(a => profileInt.Any(b => b == a)).ToList();

            return result.FirstOrDefault();
        }
        public int getUser()
        {
            var ctx = new AppDbContext();
            List<Profile> enLista = ctx.Profiles.ToList();
            Profile enprofil = enLista.FirstOrDefault(x => x.ApplicationUser == User.Identity.GetUserId());
            int id = enprofil.ProfileId;
            return id;
        }
    }
}