using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    interface IGenericRepository<Entity> where Entity : class
    {
        void Add(Entity item);
        List<Entity> GetData();
        List<Entity> GetData(params Expression<Func<Entity, object>>[] includeProperties);
        Entity FindById(int id);
        Entity GetDataAt(int num);
        Entity GetDataAt(int num, params Expression<Func<Entity, object>>[] includeProperties);
        void RemoveAtId(int id);
    }
}
