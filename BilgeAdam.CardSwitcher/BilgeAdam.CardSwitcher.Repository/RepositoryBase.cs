using BilgeAdam.CardSwitcher.Data.Context;
using System.Data.Entity;

namespace BilgeAdam.CardSwitcher.Repository
{
    public abstract class RepositoryBase<T> where T: class
    {
        private GameContext context;
        public RepositoryBase()
        {
            context = new GameContext();
            Table = context.Set<T>();
        }

        protected void Save()
        {
            context.SaveChanges();
        }

        protected void Close()
        {
            context.Dispose();
            context = null;
        }

        protected DbSet<T> Table { get; }
    }
}
