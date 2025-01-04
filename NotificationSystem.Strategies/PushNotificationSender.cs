using Microsoft.Extensions.Logging;
using NotificationSystem.Interfaces;
using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Strategies
{
    public class PushNotificationSender : INotificationSender
    {
        private readonly ILogger _logger;

        public PushNotificationSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(Notification notification)
        {
            _logger.LogInformation($"Push notification sent to {notification.Recipient}: {notification.Message}");
        }
    }
}
