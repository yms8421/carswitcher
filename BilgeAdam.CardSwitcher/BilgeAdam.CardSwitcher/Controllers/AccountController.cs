using BilgeAdam.CardSwitcher.Models;
using BilgeAdam.CardSwitcher.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.CardSwitcher.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = new UserRepository();
            var loggedInUser = user.Get(i => i.UserName == model.UserName && i.Password == model.Password);
            //Oturum aç ve oyun alanına yönlendir
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}