using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    /// <summary>
    /// Person View class is created in which we define attributes of public type
    /// </summary>
    public class PersonViewModel
    {
        //Attributes match to the given table in database


        //[System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string MiddleName { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }

        public string HomeAddress { get; set; }

        [RegularExpression(@"^[0-9A-Za-z ]+$")]
        public string HomeCity { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        public string FaceBookAccountId { get; set; }

        
        public string LinkedInId { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateOn { get; set; }
        public string ImagePath { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        public string TwitterId { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        public string EmailId { get; set; }













    }
}