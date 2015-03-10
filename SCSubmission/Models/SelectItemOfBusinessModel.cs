using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCSubmission.Models
{
    public class SelectItemOfBusinessModel
    {
        public IEnumerable<ItemOfBusiness> ItemsOfBusiness { get; set; }
        public String SelectedItemOfBusiness { get; set; }
    }
}