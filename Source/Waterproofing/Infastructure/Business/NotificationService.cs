using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Waterproofing.Infastructure.Business
{
    public class NotificationService : INotificationService
    { 
        public void SendEmail(Entities.Prospect prospect, MailConfig mailConfig)
        {
            mailConfig = new MailConfig { MailGunApiKey = GetMailGunApiKey(), ToEmail = GetEmailTo() };

            var from = string.Format("{0} <{1}>", prospect.Name, "noreply@indbat.com");
            var to = mailConfig.ToEmail;
            var body = string.Format("Name:{0}<br /> Address:{1}<br /> City:{2}<br /> State:{3}<br /> Zip:{4}<br /> Phone:{5}<br /> Email:{6}<br /> Company:{7}<br /> Comments:{8}<br /> ",
                prospect.Name, prospect.Address,
                prospect.City, prospect.State, prospect.Zip, prospect.Phone, prospect.Email, prospect.Company, prospect.Comment);


            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator = new HttpBasicAuthenticator("api", mailConfig.MailGunApiKey);

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "app594.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("subject", "contact me");
            request.AddParameter("text", body);
            request.AddParameter("html", "<html>" + body + "</html>");
            request.Method = Method.POST;
            var response = client.Execute(request);
            return;
        }



        public static string GetMailGunApiKey()
        {
            var ret = "";
            if (ConfigurationManager.AppSettings["MAILGUN_API_KEY"] != null)
            {
                ret = ConfigurationManager.AppSettings["MAILGUN_API_KEY"];
            }
            return ret;
        }
        public static string GetEmailTo()
        {
            var ret = "";
            if (ConfigurationManager.AppSettings["MAILGUN_EMAIL_TO"] != null)
            {
                ret = ConfigurationManager.AppSettings["MAILGUN_EMAIL_TO"];
            }
            return ret;
        }

    }
    public class MailConfig
    {
        public string ToEmail { get; set; }
        public string MailGunApiKey { get; set; }
    }

}