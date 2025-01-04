using NotificationSystem.Interfaces;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Contexts
{
    public class NotificationContext
    {
        private INotificationSender _sender;

        public void SetSender(INotificationSender sender)
        {
            _sender = sender;
        }

        public void SendNotification(Notification notification)
        {
            _sender.Send(notification);
        }
    }
}
