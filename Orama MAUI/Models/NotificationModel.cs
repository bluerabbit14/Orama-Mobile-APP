using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orama.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string profilePic { get; set; }
        public string senderName { get; set; }
        public string description { get; set; }
        public string type{ get; set; }
        public DateTime createdAt { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
