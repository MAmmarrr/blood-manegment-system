using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManegmentSystem.Models;
using System.Web.Http;

namespace BloodBankManegmentSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult Login()
        {
            return RedirectToAction("Login","Home");
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
                return RedirectToAction("Dashboard","Home");

            }
        }
    }
}