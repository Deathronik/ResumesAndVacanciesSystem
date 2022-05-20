using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private DbSet<Entity> DBSet;
        public GenericRepository(DbContext context)
        {
            DBSet = context.Set<Entity>();
        }
        public void Add(Entity data)
        {
            DBSet.Add(data);
        }
        public List<Entity> GetData()
        {
            return DBSet.AsNoTracking().ToList();
        }
        private IQueryable<Entity> Include(params Expression<Func<Entity, object>>[] includeProperties)
        {
            IQueryable<Entity> query = DBSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public List<Entity> GetData(params Expression<Func<Entity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        public Entity FindById(int id)
        {
            return DBSet.Find(id);
        }
        public void RemoveAtId(int id)
        {
            DBSet.Remove(DBSet.Find(id));
        }
    }
}
