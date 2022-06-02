using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL;
using DAL.Models;

namespace BLLTesting.Mocks
{
    class MockWorkerRepository : IGenericRepository<Worker>
    {
        private List<Worker> Workers = new List<Worker>();
        public void Add(Worker item)
        {
            Workers.Add(item);
        }
        public Worker FindById(int id)
        {
            return Workers.Find(x => x.Id == id);
        }
        public List<Worker> GetByFunc(Func<Worker, bool> predicate)
        {
            return null;
        }
        public List<Worker> GetData()
        {
            return Workers;
        }
        public List<Worker> GetData(params Expression<Func<Worker, object>>[] includeProperties)
        {
            return null;
        }
        public void RemoveAtId(int id)
        {
            Workers.Remove(Workers.Find(x => x.Id == id));
        }
        public void Update(Worker item)
        {
            Workers[Workers.FindIndex(x => x.Id == item.Id)] = item;
        }
    }
}
