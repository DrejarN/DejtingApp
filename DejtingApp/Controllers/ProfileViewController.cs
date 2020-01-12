using DejtingApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DejtingApp.Controllers
{
    [Authorize]
    public class ProfileViewController : ApiController
    {
        [HttpGet]
        public List<ViewsListViewModel> Viewslista()
        {
                using (var db = new AppDbContext())
                {
                    var pid = getUser();
                    var result = (from Profile in db.Profiles
                                  join ProfileView in db.ProfileViews on Profile.ProfileId equals ProfileView.SendClickId
                                  where ProfileView.RecieveClickId == pid
                                  orderby ProfileView.ProfileViewId descending
                                  select new ViewsListViewModel
                                  {
                                      Förnamn = Profile.Förnamn,
                                      Efternamn = Profile.Efternamn

                                  }).Take(5).ToList();
                    return result;
                }
            
            
        }

        [HttpDelete]
        public int getUser()
        {
            var ctx = new AppDbContext();
            List<Profile> enLista = ctx.Profiles.ToList();
            Profile enprofil = enLista.FirstOrDefault(x => x.ApplicationUser == User.Identity.GetUserId());
            int id = enprofil.ProfileId;
            return id;
        }

        [HttpPost]
        public void TickProfileCount(ProfileView profileView)
        {
            try
            {
                var ctx = new AppDbContext();

                var profilId = getUser();

                //Ticker för ProfileViews.
                ProfileView pView = new ProfileView()
                {
                    SendClickId = profilId,
                    RecieveClickId = profileView.RecieveClickId
                };

                ctx.ProfileViews.Add(pView);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                
            }

        }
    }
}