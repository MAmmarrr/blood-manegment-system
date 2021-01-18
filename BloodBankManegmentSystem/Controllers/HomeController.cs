using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManegmentSystem.Models;
using System.Data.Entity;
using BloodBankManegmentSystem.ViewModels;


namespace BloodBankManegmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext _context;

        public HomeController()
        {
            _context = new MyDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View("");
        }
        public ViewResult DonorList()
        {
            var donors = _context.Donors.Include(c => c.BloodType).Include(c => c.Gender).ToList();

            return View(donors);
        }
        public ViewResult AcceptorsList()
        {
            var acceptors = _context.Acceptors.Include(c => c.BloodType).Include(c => c.Gender).ToList();

            return View(acceptors);
        }
        public ActionResult SampleList()
        {
            var samples = _context.Donors.Include(c => c.BloodType).ToList();

            return View(samples);

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Auth(User user)
        {
            var email = user.Email.ToString().ToLower();

            if (email.Contains("admin"))
            {
                return RedirectToAction("Index", "Donor");
            }
            else
            {
                return Content(user.Email);

            }
        }
    }
}