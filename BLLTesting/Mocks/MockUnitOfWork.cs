using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLLTesting.Mocks
{
    class MockUnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Hirer> Hirer { get; }
        public IGenericRepository<Resume> Resume { get; }
        public IGenericRepository<Vacation> Vacation { get; }
        public IGenericRepository<Worker> Worker { get; }
        public MockUnitOfWork()
        {
            Hirer = new MockHirerRepository();
            Resume = new MockResumeRepository();
            Vacation = new MockVacationRepository();
            Worker = new MockWorkerRepository();
        }

        public void Dispose()
        { }
        public void Save()
        { }
    }
}
