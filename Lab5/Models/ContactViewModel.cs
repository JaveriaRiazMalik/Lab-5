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

        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Type { get; set; }
        public int PersonId { get; set; }
        
    }
}