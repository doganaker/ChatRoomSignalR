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
        private ChatContext _chatcontext;

        public override Task OnConnectedAsync()
        {
            _chatcontext = new ChatContext();

            var email = Context.User.Claims.ToArray()[0].Value;

            var currentUser = _chatcontext.AdminUsers.FirstOrDefault(x => x.EMail == email);

            currentUser.ConnectionID = Context.ConnectionId;

            _chatcontext.SaveChanges();

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message, string connectionid)
        {
            string msg = message;
            await Clients.Client(connectionid).SendAsync("ReceiveMessage", msg);
        }
    }
}
