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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Added on")]
        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        [Display(Name = "Home City")]
        public string HomeCity { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        [Display(Name = "FaceBook Account Id")]
        public string FaceBookAccountId { get; set; }

        [Display(Name = "LinkedIn Id")]
        public string LinkedInId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Updated On")]
        public DateTime UpdateOn { get; set; }
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        [Display(Name = "Twitter Id")]
        public string TwitterId { get; set; }

        [RegularExpression(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$",
        ErrorMessage = "Please enter correct email address")]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }













    }
}