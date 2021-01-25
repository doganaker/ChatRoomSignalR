using ChatRoomSignalR.Models.Context;
using ChatRoomSignalR.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Controllers
{
    public class LoginController : Controller
    {
        private readonly ChatContext _chatContext;

        public LoginController(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        
        public IActionResult Login()
        
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            var user = _chatContext.AdminUsers.FirstOrDefault(x => x.EMail == model.Email && x.Password == model.Password);

          //  user.ConnectionID = 
            return Redirect("/Home/Index");
        }
    }
}
