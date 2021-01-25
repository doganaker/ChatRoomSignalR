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
            List<AdminUser> users = _chatcontext.AdminUsers.ToList();

            return View(users);
        }
    }
}
