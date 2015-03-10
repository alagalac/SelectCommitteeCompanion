using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SCSubmission.Models
{
    public class Submission
    {
        public String DocumentId { get; set; }

        public String ItemTitle { get; set; }

        public String CommitteeName { get; set; }

        [DisplayName("Name of Submitter")]
        public String OrganisationName { get; set; }

        [Required]
        [DisplayName("Contact Name")]
        public String ContactName { get; set; }

        [DisplayName("Position in Organisation (if applicable)")]
        public String Position { get; set; }

        [DisplayName("Organisation (if applicable)")]
        public String Organisation { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public String EmailAddress { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public String PhoneNumber { get; set; }

        [DisplayName("Alternative Phone Number")]
        public String AlternativePhoneNumber { get; set; }

        [Required]
        [DisplayName("Region")]
        public String Region { get; set; }

        [DisplayName("Submission Content")]
        public String SubmissionContent { get; set; }

        public HttpPostedFileBase File { get; set; }

        [Required]
        [DisplayName("Would you like to be heard in person?")]
        public Boolean PresentToCommittee { get; set; }

        [DisplayName("Message to committee staff")]
        public String MessageToCommitteeStaff { get; set; }
    }
}