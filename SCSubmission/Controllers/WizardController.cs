using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCSubmission.Models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace SCSubmission.Controllers
{
    public class WizardController : Controller
    {
        //
        // GET: /Wizard/



        [HttpGet]
        public ActionResult CreateSubmission(String documentId)
        {
            ViewBag.Current = "Business";

            var item = DataService.GetItemOfBusiness(documentId);

            var submission = new Submission();
            submission.DocumentId = item.DocumentId;
            submission.ItemTitle = item.Title;
            submission.CommitteeName = item.CommitteeName;
            return View(submission);
        }

        [HttpPost]
        public ActionResult CreateSubmission(Submission model)
        {
            ViewBag.Current = "Business";

            var item = DataService.GetItemOfBusiness(model.DocumentId);
            model.ItemTitle = item.Title;
            model.CommitteeName = item.CommitteeName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Confirmation(Submission model)
        {
            ViewBag.Current = "Business";

            var item = DataService.GetItemOfBusiness(model.DocumentId);
            model.ItemTitle = item.Title;
            model.CommitteeName = item.CommitteeName;

            if (Request["action"] == "back")
            {
                return View("CreateSubmission", model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Complete(Submission model)
        {
            ViewBag.Current = "Business";

            

            return View(model);
        }


        

    }
}
