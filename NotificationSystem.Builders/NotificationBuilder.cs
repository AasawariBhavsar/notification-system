using NotificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Builders
{
    public class NotificationBuilder
    {
        private readonly Notification _notification = new Notification();

        public NotificationBuilder SetRecipient(string recipient)
        {
            _notification.Recipient = recipient;
            return this;
        }

        public NotificationBuilder SetSubject(string subject)
        {
            _notification.Subject = subject;
            return this;
        }

        public NotificationBuilder SetMessage(string message)
        {
            _notification.Message = message;
            return this;
        }

        public NotificationBuilder AddAttachment(string attachment)
        {
            _notification.Attachment = attachment;
            return this;
        }

        public Notification Build()
        {
            return _notification;
        }
    }
}
