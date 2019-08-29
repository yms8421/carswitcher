using BilgeAdam.CardSwitcher.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BilgeAdam.CardSwitcher.Helpers
{
    public class GameHub : Hub
    {
        static GameHub()
        {
            Users = new List<string>();
        }
        public static List<string> Users { get; set; }
        public void SwitchCard(int location)
        {
            Clients.Others.switchCard(location);
        }

        public void Match(int location1, int location2)
        {
            Clients.Others.matchCards(location1, location2);
        }

        public void ChangeTurn()
        {
            Clients.Others.getTurn();
        }

        public void TurnBackCards(int location1, int location2)
        {
            Clients.Others.turnBackCards(location1, location2);
        }
        public void GetDesign(string userName)
        {
            var r = new Random();
            var list = new List<int>();
            //Kart sayısı kadar dön ve kartların indeksini önceden belirle
            for (int i = 1; i <= 36; i++)
            {
                list.Add(i);
            }

            //Kart ve yer için bir alan oluştur
            var design = new Dictionary<int, Location>();
            for (int i = 1; i <= 18; i++)
            {
                //listeden rasgele bir yer seç
                var p1 = list[r.Next(0, list.Count)];
                //seçilen yeri listeden sil (aynı yer tekrar gelmesin diye)
                list.Remove(p1);
                var p2 = list[r.Next(0, list.Count)];
                list.Remove(p2);

                design.Add(i, new Location(p1, p2));
            }
            var designJson = JsonConvert.SerializeObject(design);
            Clients.All.setCardDesign(designJson);
            Users.Add(userName);
            Clients.All.refreshPlayers(Users);
        }

        public void Disconnect(string userName)
        {
            Users.Remove(userName);
            Clients.All.refreshPlayers(Users);
        }
    }
}