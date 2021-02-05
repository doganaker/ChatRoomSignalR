using ChatRoomSignalR.Models.Context;
using ChatRoomSignalR.Models.Entities;
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
            GetUser().ConnectionID = Context.ConnectionId;

            _chatcontext.SaveChanges();

            GetUser().OnlineStatus = true;

            _chatcontext.SaveChanges();

            string connectuserid = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("Onlineuser", connectuserid);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            GetUser().OnlineStatus = false;

            _chatcontext.SaveChanges();

            string connectuserid = Context.User.Claims.ToArray()[1].Value;

            Clients.All.SendAsync("Offlineuser", connectuserid);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string id, string connectionid, string message)
        {
            string msg = message;
            int clientId = Convert.ToInt32(id);
            int callerId = Convert.ToInt32(Context.User.Claims.ToArray()[1].Value);
            string userCid = Context.ConnectionId;

            await Clients.Caller.SendAsync("ReceiveMessage", userCid, msg);
            await Clients.Client(connectionid).SendAsync("ReceiveMessage", userCid, msg);

            Message text = new Message();
            text.Content = msg;
            text.CallerID = callerId;
            text.ClientID = clientId;

            _chatcontext = new ChatContext();
            _chatcontext.Messages.Add(text);
            _chatcontext.SaveChanges();
        }
      
        private AdminUser GetUser()
        {
            _chatcontext = new ChatContext();

            var email = Context.User.Claims.ToArray()[0].Value;

            var currentUser = _chatcontext.AdminUsers.FirstOrDefault(x => x.EMail == email);

            return currentUser;
        }
    }
}
