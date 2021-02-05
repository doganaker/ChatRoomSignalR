using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Models.Entities
{
    public class Message
    {
        public int ID { get; set; }
        public int CallerID { get; set; }
        public int ClientID { get; set; }
        public string Content { get; set; }
        public string Time { get; set; } = DateTime.Now.ToString("HH:mm");
    }
}
