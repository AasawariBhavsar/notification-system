using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class NotificationRequest : Notification
    {
        public string DeliveryMethod { get; set; }
    }
}
