using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBankManegmentSystem.Models
{
    public class Acceptors
    {
            public int id { get; set; }
            [Required]
            [StringLength(255)]
            public String name { get; set; }

            [Required(ErrorMessage = "Required")]
            [Display(Name = "Home Phone")]

            [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$",
                       ErrorMessage = "Entered phone format is not valid.")]
            public String mobileNum { get; set; }

            [Display(Name = "Email address")]
            [Required(ErrorMessage = "Required")]
            public String email { get; set; }
            public Gender Gender { get; set; }
            [Display(Name = "Gender")]
            public byte GenderId { get; set; }
            [Required]
            public int? age { get; set; }
            public String address { get; set; }
            public BloodType BloodType { get; set; }
            [Display(Name = "Blood Group")]
            public byte BloodTypeId { get; set; }

        
    }
}