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
            var r = new Random();
            var list = new List<int>();
            //Kart sayısı kadar dön ve kartların indeksini önceden belirle
            for (int i = 1; i <= 36; i++)
            {
                list.Add(i);
            }

            //Kart ve yer için bir alan oluştur
            var design = new Dictionary<int, Point>();
            for (int i = 1; i <= 18; i++)
            {
                //listeden rasgele bir yer seç
                var p1 = list[r.Next(0, list.Count)];
                //seçilen yeri listeden sil (aynı yer tekrar gelmesin diye)
                list.Remove(p1);
                var p2 = list[r.Next(0, list.Count)];
                list.Remove(p2);

                design.Add(i, new Point(p1, p2));
            }
            return View(design);
        }
    }
}