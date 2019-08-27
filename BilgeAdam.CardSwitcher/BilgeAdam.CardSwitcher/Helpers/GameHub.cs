using BilgeAdam.CardSwitcher.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeAdam.CardSwitcher.Helpers
{
    public class GameHub : Hub
    {
        public void SwitchCard(int location)
        {
            Clients.All.switchCard(location);
        }

        public void GetDesign()
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
            var designJson = JsonConvert.SerializeObject(design);
            Clients.All.setCardDesign(designJson);
        }
    }
}