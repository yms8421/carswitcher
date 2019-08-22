using System;
using System.Web;
using System.Web.Mvc;

namespace BilgeAdam.CardSwitcher.Filters
{
    public class HasAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Kullanıcı giriş yapmadıysa
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("/Account/Login");
            }
        }
    }
}