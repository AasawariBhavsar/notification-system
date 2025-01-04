﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Models
{
    public class Notification
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string? Message { get; set; }
        public string? Attachment { get; set; }
    }
}
