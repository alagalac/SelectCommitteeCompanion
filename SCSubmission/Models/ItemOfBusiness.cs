using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCSubmission.Models
{
    public class ItemOfBusiness
    {
        public DateTime ClosingDate { get; set; }
        public DateTime OpeningDate { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String CommitteeName { get; set; }
        public String DocumentId { get; set; }
        public String CommitteeIconName { get; set; }
    }
}