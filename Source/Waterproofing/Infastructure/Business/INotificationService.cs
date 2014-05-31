using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Waterproofing.Infastructure.Entities;

namespace Waterproofing.Infastructure.Business
{
    public interface INotificationService
    {
        void SendEmail( Prospect prospect, MailConfig mailConfig);
    }
}