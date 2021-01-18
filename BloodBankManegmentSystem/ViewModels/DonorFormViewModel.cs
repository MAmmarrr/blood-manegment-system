using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManegmentSystem.Models;

namespace BloodBankManegmentSystem.ViewModels
{
    public class DonorFormViewModel
    {
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public Donors Donor { get; set; }

        public IEnumerable<Gender> Gender { get; set; }
    }
}