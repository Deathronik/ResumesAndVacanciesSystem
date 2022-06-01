using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL;
using DAL.Models;

namespace BLLTesting.Mocks
{
    class MockHirerRepository : IGenericRepository<Hirer>
    {
        private List<Hirer> Hirers = new List<Hirer>();
        public void Add(Hirer item)
        {
            Hirers.Add(item);
        }
        public Hirer FindById(int id)
        {
            return Hirers.Find(x => x.Id == id);
        }
        public List<Hirer> GetByFunc(Func<Hirer, bool> predicate)
        {
            return null;
        }
        public List<Hirer> GetData()
        {
            return Hirers;
        }
        public List<Hirer> GetData(params Expression<Func<Hirer, object>>[] includeProperties)
        {
            return null;
        }
        public void RemoveAtId(int id)
        {
            Hirers.Remove(Hirers.Find(x => x.Id == id));
        }
        public void Update(Hirer item)
        {
            Hirers[Hirers.FindIndex(x => x.Id == item.Id)] = item;
        }
    }
}
