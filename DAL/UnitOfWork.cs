using DAL.Models;
using System;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ResumesAndVacanciesSystemContext DBContext;
        public IGenericRepository<Hirer> Hirer { get; }
        public IGenericRepository<Resume> Resume { get; }
        public IGenericRepository<Vacation> Vacation { get; }
        public IGenericRepository<Worker> Worker { get; }

        private bool Disposed;
        public UnitOfWork(ResumesAndVacanciesSystemContext dbContext, IGenericRepository<Hirer> hirerRepository, IGenericRepository<Resume> resumeRepository, IGenericRepository<Vacation> vacationRepository,
        IGenericRepository<Worker> workerRepository)
        {
            DBContext = dbContext;
            Hirer = hirerRepository;
            Resume = resumeRepository;
            Vacation = vacationRepository;
            Worker = workerRepository;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
                DBContext.Dispose();
            Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                DBContext.SaveChanges();
            } while (saveFailed);
        }
    }
}
