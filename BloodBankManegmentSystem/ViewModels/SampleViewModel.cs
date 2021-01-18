using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManegmentSystem.Models;

namespace BloodBankManegmentSystem.ViewModels
{
    public class SampleViewModel
    {
        public BloodType samples { get; set; }
        public List<Donors> donors { get; set; }
    }
}