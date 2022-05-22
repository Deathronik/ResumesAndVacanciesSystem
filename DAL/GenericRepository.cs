using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace DAL
{
    class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private DbSet<Entity> DBSet;
        private DbContext Context;
        public GenericRepository(DbContext context)
        {
            DBSet = context.Set<Entity>();
            Context = context;
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
        public List<Entity> GetByFunc(Func<Entity, bool> predicate)
        {
            return DBSet.AsNoTracking().Where(predicate).ToList();
        }
        public void RemoveAtId(int id)
        {
            DBSet.Remove(DBSet.Find(id));
        }
        public void Update(Entity item)
        {
            DBSet.AsNoTracking();
            Context.Set<Entity>().AddOrUpdate(item);
        }
    }
}
