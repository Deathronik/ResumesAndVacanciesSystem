using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        void Add(Entity item);
        List<Entity> GetData();
        List<Entity> GetData(params Expression<Func<Entity, object>>[] includeProperties);
        Entity FindById(int id);
        List<Entity> GetByFunc(Func<Entity, bool> predicate);
        void RemoveAtId(int id);
        void Update(Entity item);
    }
}
