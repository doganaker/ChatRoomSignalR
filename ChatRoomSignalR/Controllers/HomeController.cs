using ChatRoomSignalR.Models.Context;
using ChatRoomSignalR.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChatContext _chatcontext;

        public HomeController(ChatContext chatcontext)
        {
            _chatcontext = chatcontext;
        }

        public IActionResult Index()
        {
            ViewBag.id = Convert.ToInt32(HttpContext.User.Claims.ToArray()[1].Value);
            ViewBag.Name = HttpContext.User.Claims.ToArray()[0].Value;
            List<AdminUser> users = _chatcontext.AdminUsers.ToList();

            return View(users);
        }

        public JsonResult User(int id)
        {
            var user = _chatcontext.AdminUsers.Find(id);
            return Json(user);
        }

        [Route("GetChat/{callerId}/{clientId}")]
        public JsonResult GetChat(int callerId, int clientId)
        {
            List<Message> chat = _chatcontext.Messages.Where(q => (q.CallerID == callerId && q.ClientID == clientId) || (q.CallerID == clientId && q.ClientID == callerId)).ToList();

            return Json(chat);
        }
    }
}




//https://localhost:44320/Home/GetChat/?callerId=10&clientId=1
