using BilgeAdam.CardSwitcher.Filters;
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
    }
}