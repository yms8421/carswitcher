using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilgeAdam.CardSwitcher.Repository
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        T Get(Expression<Func<T, bool>> expression);
        void Add(T item);
        void Update(T item);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression);
    }
}
