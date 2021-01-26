using ChatRoomSignalR.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatContext _chatcontext;
        private readonly HttpContext _context;

        public ChatHub(ChatContext chatcontext, HttpContext context)
        {
            _chatcontext = chatcontext;
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            var id = Context.ConnectionId;

            var email = _context.User.Claims.ToArray()[0].Value;
            
            var currentUser = _chatcontext.AdminUsers.FirstOrDefault(x => x.EMail == email);

            currentUser.ConnectionID = id;

            _chatcontext.SaveChanges();

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var email = _context.User.Claims.ToArray()[0].Value;

            var currentUser = _chatcontext.AdminUsers.FirstOrDefault(x => x.EMail == email);

            currentUser.ConnectionID = "";

            _chatcontext.SaveChanges();

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            string msg = message;
            await Clients.Client("connectionid").SendAsync("ReceiveMessage", msg);
        }
    }
}
