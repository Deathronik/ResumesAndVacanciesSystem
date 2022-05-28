using DAL.Models;

namespace DAL
{
    public class UnitOfWork
    {
        private MyDBContext DBContext = new MyDBContext();
        private IGenericRepository<Hirer> HirerRepository;
        private IGenericRepository<Resume> ResumeRepository;
        private IGenericRepository<Vacation> VacationRepository;
        private IGenericRepository<Worker> WorkerRepository;

        public IGenericRepository<Hirer> Hirer()
        {
            if (HirerRepository == null)
                HirerRepository = new GenericRepository<Hirer>(DBContext);
            return HirerRepository;
        }
        public IGenericRepository<Resume> Resume()
        {
            if (ResumeRepository == null)
                ResumeRepository = new GenericRepository<Resume>(DBContext);
            return ResumeRepository;
        }
        public IGenericRepository<Vacation> Vacation()
        {
            if (VacationRepository == null)
                VacationRepository = new GenericRepository<Vacation>(DBContext);
            return VacationRepository;
        }
        public IGenericRepository<Worker> Worker()
        {
            if (WorkerRepository == null)
                WorkerRepository = new GenericRepository<Worker>(DBContext);
            return WorkerRepository;
        }
        public void Save()
        {
            DBContext.SaveChanges();
        }
    }
}
