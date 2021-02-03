using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Models.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public Nullable<int> CallerID { get; set; }
        public Nullable<int> ClientID { get; set; }
    }
}
