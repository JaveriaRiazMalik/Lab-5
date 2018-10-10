using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    /// <summary>
    /// Contact View class is created in which we define attributes of public type
    /// </summary>
    public class ContactViewModel
    {
        // Attributes match to the given table
        public int ContactId { get; set; }

        public string ContactNumber { get; set; }

        [RegularExpression(@"^[a-z -']+$")]
        public string Type { get; set; }
        public int PersonId { get; set; }
        
    }
}