using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSubmission.Models;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;

namespace SCSubmission.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult SelectItemOfBusiness()
        {
            ViewBag.Current = "Business";

            var model = new SelectItemOfBusinessModel();
            model.ItemsOfBusiness = DataService.LoadItemsOfBusiness();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult WhatAreSelectCommittees()
        {
            ViewBag.Current = "About";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HowDoSelectCommitteesWork()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WhatIsTheSubmissionProcess()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FrequentlyAskedQuestions()
        {
            ViewBag.Current = "Faq";
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
