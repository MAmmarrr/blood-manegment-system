using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using BloodBankManegmentSystem.ViewModels;
using BloodBankManegmentSystem.Models;
using System;

namespace BloodBankManegmentSystem.Controllers
{
    public class AcceptorController : Controller
    {
        private MyDbContext _context;

        public AcceptorController()
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

            var viewModel = new AcceptorFormViewModel
            {

                Gender = Gender,

                BloodTypes = Bloodtype
            };

            return View("New", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Acceptors acceptor)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AcceptorFormViewModel
                {
                    Acceptor = acceptor,
                    BloodTypes = _context.BloodType.ToList(),
                    Gender = _context.Gender.ToList()
                };

                return View("New", viewModel);
            }

            if (acceptor.id == 0)
                _context.Acceptors.Add(acceptor);
            else
            {
                var DonorsInDb = _context.Acceptors.Single(c => c.id == acceptor.id);
                DonorsInDb.name = acceptor.name;
                DonorsInDb.BloodTypeId = acceptor.BloodTypeId;
                DonorsInDb.mobileNum = acceptor.mobileNum;
                DonorsInDb.email = acceptor.email;
                DonorsInDb.GenderId = acceptor.GenderId;
                DonorsInDb.age = acceptor.age;
                DonorsInDb.address = acceptor.address;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Acceptor");
        }
        public ViewResult Index()
        {
            var acceptors = _context.Acceptors.Include(c => c.BloodType).Include(c => c.Gender).ToList();

            return View(acceptors);
        }
        public ActionResult Edit(int id)
        {
            var acceptors = _context.Acceptors.SingleOrDefault(c => c.id == id);

            if (acceptors == null)
                return HttpNotFound();

            var viewModel = new AcceptorFormViewModel
            {

                Gender = _context.Gender.ToList(),
                Acceptor = acceptors,
                BloodTypes = _context.BloodType.ToList()
            };
            return View("New", viewModel);
        }
    }
}