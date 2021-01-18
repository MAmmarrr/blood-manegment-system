using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManegmentSystem.Models;
using BloodBankManegmentSystem.ViewModels;
using System.Data.Entity;
namespace BloodBankManegmentSystem.Controllers
{
    public class SampleController : Controller
    {
        private MyDbContext _context;

        public SampleController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Blood
        public ActionResult Index()
        {
            var samples = _context.Donors.Include(c => c.BloodType).ToList();

            return View(samples);

            }
    }
}