using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DejtingApp.Models;

namespace DejtingApp.Controllers
{
    public class MessageController : ApiController
    {
        AppDbContext ctx = new AppDbContext();
        public List<Message> lista = new List<Message>();

        [HttpGet]
        public IEnumerable<Message> GetAllMessages(int id)
        {
            lista = ctx.Messages.Where(o => o.RecieverId == id).ToList();
            return lista;
        }

        public IHttpActionResult GetMessage(int id)
        {
            var product = lista.FirstOrDefault((p) => p.RecieverId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public void PostMessage(Message message)
        {

            using (var db = new AppDbContext())
            {
                DateTime now = DateTime.Now;
                //var from = db.Users.Single(u => u.Id == message.SenderId);
                //var to = db.Profiles.FirstOrDefault(u => u.ProfileId == message.RecieverId).ProfileId;
                var newMessage = new Message() { MessageText = message.MessageText, MessageCreated = now, SenderId = message.SenderId, RecieverId = message.RecieverId };
                db.Messages.Add(newMessage);
                db.SaveChanges();
            }
        }

    }
}
