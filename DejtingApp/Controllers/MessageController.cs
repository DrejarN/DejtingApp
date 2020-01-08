using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DejtingApp.Models;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public List<Message> lista()
        {
            using (var db = new AppDbContext())
            {
                var result = db.Messages.ToList();
                return result;
            }
        }

        public void PostMessage(Message message)
        {

            using (var db = new AppDbContext())
            {
                var userID = User.Identity.GetUserId();
                var profil = db.Profiles.FirstOrDefault(o => o.ApplicationUser == userID);
                DateTime now = DateTime.Now;
                var newMessage = new Message() { MessageText = message.MessageText, MessageCreated = now, SenderId = profil.ProfileId, RecieverId = message.RecieverId };
                db.Messages.Add(newMessage);
                db.SaveChanges();
            }
        }

    }
}
