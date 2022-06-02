using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL;
using DAL.Models;

namespace BLLTesting.Mocks
{
    class MockResumeRepository : IGenericRepository<Resume>
    {
        private List<Resume> Resumes = new List<Resume>();
        public void Add(Resume item)
        {
            Resumes.Add(item);
        }
        public Resume FindById(int id)
        {
            return Resumes.Find(x => x.Id == id);
        }
        public List<Resume> GetByFunc(Func<Resume, bool> predicate)
        {
            List<Resume> resumes = new List<Resume>();
            foreach (Resume resume in Resumes)
                if (predicate(resume))
                    resumes.Add(resume);
            return resumes;
        }
        public List<Resume> GetData()
        {
            return Resumes;
        }
        public List<Resume> GetData(params Expression<Func<Resume, object>>[] includeProperties)
        {
            return null;
        }
        public void RemoveAtId(int id)
        {
            Resumes.Remove(Resumes.Find(x => x.Id == id));
        }
        public void Update(Resume item)
        {
            Resumes[Resumes.FindIndex(x => x.Id == item.Id)] = item;
        }
    }
}
