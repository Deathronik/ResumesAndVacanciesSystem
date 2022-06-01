using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL;
using DAL.Models;

namespace BLLTesting.Mocks
{
    class MockVacationRepository : IGenericRepository<Vacation>
    {
        private List<Vacation> Vacations = new List<Vacation>();
        public void Add(Vacation item)
        {
            Vacations.Add(item);
        }
        public Vacation FindById(int id)
        {
            return Vacations.Find(x => x.Id == id);
        }
        public List<Vacation> GetByFunc(Func<Vacation, bool> predicate)
        {
            return null;
        }
        public List<Vacation> GetData()
        {
            return Vacations;
        }
        public List<Vacation> GetData(params Expression<Func<Vacation, object>>[] includeProperties)
        {
            return null;
        }
        public void RemoveAtId(int id)
        {
            Vacations.Remove(Vacations.Find(x => x.Id == id));
        }
        public void Update(Vacation item)
        {
            Vacations[Vacations.FindIndex(x => x.Id == item.Id)] = item;
        }
    }
}
