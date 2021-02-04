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

        public Nullable<int> CallerID { get; set; }
        [ForeignKey("CallerID")]
        public AdminUser Caller { get; set; }

        public Nullable<int> ClientID { get; set; }
        [ForeignKey("ClientID")]
        public AdminUser Client { get; set; }

        public string Content { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
