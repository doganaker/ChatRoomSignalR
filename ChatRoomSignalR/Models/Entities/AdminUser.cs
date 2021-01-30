using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Models.Entities
{
    public class AdminUser
    {
        public int ID { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ConnectionID { get; set; }
        public bool OnlineStatus { get; set; }
    }
}
