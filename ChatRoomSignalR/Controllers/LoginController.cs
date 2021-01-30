using ChatRoomSignalR.Models.Context;
using ChatRoomSignalR.Models.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = _chatContext.AdminUsers.FirstOrDefault(x => x.EMail == model.Email && x.Password == model.Password);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, user.ID.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.error = "You do not exist!!";
                return View();
            }
        }

        
    }
}
