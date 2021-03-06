﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DejtingApp.Models;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Controllers
{
    [Authorize]
    public class MessageController : ApiController
    {
        [HttpGet]
        public List<MessageViewModel> lista()
        {
            using (var db = new AppDbContext())
            {
                var result = (from Message in db.Messages
                              join Profile in db.Profiles on Message.SenderId equals Profile.ProfileId
                              orderby Message.MessageCreated descending
                              select new MessageViewModel
                              {
                                  MessageID = Message.MessageId,
                                  MessageText = Message.MessageText,
                                  Förnamn = Profile.Förnamn,
                                  Efternamn = Profile.Efternamn,
                                  Datum = Message.MessageCreated,
                                  Reciever = Message.RecieverId
                              }).ToList();
                return result;
            }
        }

        [HttpPost]
        public void PostMessage(Message message)
        {
            try
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
            catch (Exception)
            {

            }

        }

    }
}
