using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using BloodBankManegmentSystem.ViewModels;
using BloodBankManegmentSystem.Models;
using System;

namespace BloodBankManegmentSystem.Controllers
{
    public class DonorController : Controller
    { 
        private MyDbContext _context;
        
        public DonorController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var Gender = _context.Gender.ToList();
            var Bloodtype = _context.BloodType.ToList();

            var viewModel = new DonorFormViewModel
            {

                Gender = Gender,

                BloodTypes = Bloodtype
            };

            return View("New", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donors donor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DonorFormViewModel
                {
                    Donor = donor,
                    BloodTypes = _context.BloodType.ToList(),
                    Gender = _context.Gender.ToList()
                };

                return View("New", viewModel);
            }
            
            if (donor.id == 0)
                _context.Donors.Add(donor);
            else
            {
                var DonorsInDb = _context.Donors.Single(c => c.id == donor.id);
                DonorsInDb.name = donor.name;
                DonorsInDb.BloodTypeId = donor.BloodTypeId;
                DonorsInDb.mobileNum = donor.mobileNum;
                DonorsInDb.email = donor.email;
                DonorsInDb.GenderId = donor.GenderId;
                DonorsInDb.age = donor.age;
                DonorsInDb.address = donor.address;
                DonorsInDb.Message = donor.Message;
                DonorsInDb.donationTime = DateTime.Now.ToString();
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Donor");
        }
        public ViewResult Index()
        {
            var donors = _context.Donors.Include(c =>c.BloodType).Include(c=>c.Gender).ToList();
          
            return View(donors);
        }
        public ActionResult Edit(int id)
        {
            var donors = _context.Donors.SingleOrDefault(c => c.id == id);
           
            if (donors == null)
                return HttpNotFound();

            var viewModel = new DonorFormViewModel
            {

                Gender = _context.Gender.ToList(),
                Donor = donors,
                BloodTypes = _context.BloodType.ToList()
            };
            return View("New", viewModel);
        }

       
    }
}