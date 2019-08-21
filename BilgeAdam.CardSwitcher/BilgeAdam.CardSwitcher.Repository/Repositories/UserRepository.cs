using BilgeAdam.CardSwitcher.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BilgeAdam.CardSwitcher.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IRepository<User>, IDisposable
    {
        public void Add(User item)
        {
            item.Id = Guid.NewGuid();
            item.RecordDate = DateTime.Now;
            Table.Add(item);
            Save();
        }

        public void Dispose()
        {
            Close();
        }

        public User Get(Guid id)
        {
            return Table.FirstOrDefault(i => i.Id == id);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return Table.Where(expression).FirstOrDefault();
        }

        public IEnumerable<User> GetList(Expression<Func<User, bool>> expression)
        {
            return Table.Where(expression).ToList();
        }

        public void Update(User item)
        {
            var entity = Get(item.Id);
            entity.LooseCount = item.LooseCount;
            entity.WinCount = item.WinCount;
            entity.DrawCount = item.DrawCount;
            entity.Point = item.Point;
            Save();
            //EF Connected mode
            //Bkz. Disconnected mode (işlediğiniz)
        }
    }
}
