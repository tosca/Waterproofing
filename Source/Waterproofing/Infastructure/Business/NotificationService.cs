using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Waterproofing.Infastructure.Business
{
    public class NotificationService : INotificationService
    { 
        public void SendEmail(Entities.Prospect prospect, MailConfig mailConfig)
        {
            throw new NotImplementedException();
        }
    }
    public class MailConfig
    {
        public string ToEmail { get; set; }
        public string MailGunApiKey { get; set; }
    }

}