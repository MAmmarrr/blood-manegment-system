using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBankManegmentSystem.Models;

namespace BloodBankManegmentSystem.ViewModels
{
    public class AcceptorFormViewModel
    {
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public Acceptors Acceptor { get; set; }

        public IEnumerable<Gender> Gender { get; set; }
    }
}