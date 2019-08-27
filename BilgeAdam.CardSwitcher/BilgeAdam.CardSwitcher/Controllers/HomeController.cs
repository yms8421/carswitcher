using BilgeAdam.CardSwitcher.Filters;
using BilgeAdam.CardSwitcher.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BilgeAdam.CardSwitcher.Controllers
{
    [HasAccess]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Players()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }
    }
}