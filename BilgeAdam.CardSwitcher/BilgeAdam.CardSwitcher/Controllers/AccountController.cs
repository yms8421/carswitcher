using BilgeAdam.CardSwitcher.Models;
using BilgeAdam.CardSwitcher.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if (loggedInUser != null)
            {
                FormsAuthentication.SetAuthCookie(loggedInUser.UserName, false);
                Session["UserId"] = loggedInUser.Id;
                //Oturum aç ve oyun alanına yönlendir
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Kullanıcı adı veya parola yanlış";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}