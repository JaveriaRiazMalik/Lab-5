using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        public string ContactNumber { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
        
    }
}