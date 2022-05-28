using DAL.Models;

namespace DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Hirer> Hirer { get; }
        IGenericRepository<Resume> Resume { get; }
        IGenericRepository<Vacation> Vacation { get; }
        IGenericRepository<Worker> Worker { get; }

        void Save();
        void Dispose();
    }
}
