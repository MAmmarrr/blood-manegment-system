using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManegmentSystem.Models;

namespace BloodBankManegmentSystem.Dtos
{
    public class AcceptorsDto
    {
        public int id { get; set; }
        public String name { get; set; }
        public String mobileNum { get; set; }
        public String email { get; set; }
        public byte GenderId { get; set; }

        public GenderDto Gender { get; set; }
        [Min18YearsIfDonor]
        public int age { get; set; }
        public String address { get; set; }
        public String Message { get; set; }
        public string donationTime { get; set; }
        public byte BloodTypeId { get; set; }

        public BloodTypeDto BloodType { get; set; }
    }
}