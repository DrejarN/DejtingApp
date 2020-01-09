using DejtingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class ProfileViewController : ApiController
    {
        public void TickProfileCount(ProfileView profileView)
        {
            var ctx = new AppDbContext();

            //Ticker för ProfileViews.
            ProfileView pView = new ProfileView()
            { 
                SendClickId = profileView.SendClickId, RecieveClickId = profileView.RecieveClickId
            };

            ctx.ProfileViews.Add(pView);
            ctx.SaveChanges();

        }
    }
}