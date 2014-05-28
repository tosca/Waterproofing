using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Waterproofing.Infastructure.Business;

namespace Waterproofing.Controllers
{
     
    public class ContactController : Controller
    {
        INotificationService _notificationService;

        public ContactController()
        {
            this._notificationService = new NotificationService();

        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Index(ProspectViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {
                var dtNow = DateTime.Now; 
                var prospect = new Prospect 
                {
                    Name = viewModel.Name, 
                    Email = viewModel.Email, 
                    Address = viewModel.Address, 
                    City = viewModel.City, 
                    Comment = viewModel.Comment, 
                    Company = viewModel.Company, 
                    Phone = viewModel.Phone, 
                    State = viewModel.State

                };
                //this._prospectService.SaveProspect(prospect);  
                _notificationService.SendEmail(prospect, new MailConfig()); 
                return RedirectToAction("ThankYou"); 
            }
            return View(viewModel); 
        }
         

        public ActionResult ThankYou()
        {
            return View(); 
        } 

    }


}
