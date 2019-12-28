using DejtingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class MessageController : Controller
    {
        AppDbContext ctx = new AppDbContext();

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // CREATE: Message

        [HttpPost]
        public ActionResult createMessage(Message msg)
        {
            ctx.Messages.Add(msg);
            ctx.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        // GET: MessageJson

        public JsonResult getMessage(string id)
        {
            List<Message> messages = new List<Message>();
            messages = ctx.Messages.ToList();
            return Json(messages, JsonRequestBehavior.AllowGet);
        }
    }
}