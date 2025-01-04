using Microsoft.Extensions.Logging;
using NotificationSystem.Builders;
using NotificationSystem.Contexts;
using NotificationSystem.Models;
using NotificationSystem.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Services
{
    public class NotificationService
    {
        private readonly ILogger _logger;
        public NotificationService(ILogger logger)
        {
            _logger = logger;
        }
        public Notification BuildNotification(NotificationRequest input)
        {
            var builder = new NotificationBuilder();
            return builder
                .SetRecipient(input.Recipient)
                .SetSubject(input.Subject)
                .SetMessage(input.Message)
                .AddAttachment(input.Attachment)
                .Build();
        }

        public string GetDeliveryMethod(NotificationContext context, string deliveryMethod)
        {
            switch (deliveryMethod.ToLower())
            {
                case "email":
                    context.SetSender(new EmailSender(_logger));
                    return "email";
                case "sms":
                    context.SetSender(new SmsSender(_logger));
                    return "sms";
                case "push":
                    context.SetSender(new PushNotificationSender(_logger));
                    return "push";
                default:
                    throw new ArgumentException("Invalid delivery method.");
            }
        }

        public void Send(NotificationContext context, Notification notification)
        {
            context.SendNotification(notification);
        }
    }
}
