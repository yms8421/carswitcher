using BilgeAdam.CardSwitcher.Data.Entites;
using System.Data.Entity;

namespace BilgeAdam.CardSwitcher.Data.Context
{
    public class GameContext : DbContext
    {
        public GameContext() : base("gameConnStr")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
    }
}
