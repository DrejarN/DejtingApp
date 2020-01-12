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
    public class InterestController : Controller
    {
        [HttpPost]
        public ActionResult CreateNewInterest(Interest interest)
        {
            try
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
                return RedirectToAction("EditInterests", "Profile");
            }
            catch (Exception)
            {

                return RedirectToAction("GenericError", "ErrorHandler");

            }
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

        [Authorize]
        public ActionResult FindMatch()
        {
            try
            {
                if (User.Identity.GetUserId() == null) { return RedirectToAction("Register", "Account"); }

                int pid = getUser();
                var ctx = new AppDbContext();
                var intressen = (from interests in ctx.Interests where interests.ProfileId == pid select interests.InterestName).ToList();
                var matches = (from interests in ctx.Interests where intressen.Contains(interests.InterestName) && interests.ProfileId != pid select interests).ToList();
                List<int> ids = matches.Select(o => o.ProfileId).ToList();
                var uniqueId = ids.GroupBy(a => a).Select(b => b.First()).ToList();
                var profiles = (from Profiles in ctx.Profiles where ids.Contains(Profiles.ProfileId) select Profiles);

                return View(profiles);
            }
            catch (Exception)
            {

                return RedirectToAction("GenericError", "ErrorHandler");

            }
        }
    }
}