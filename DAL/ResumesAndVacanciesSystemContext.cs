using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class ResumesAndVacanciesSystemContext : DbContext
    {
        public ResumesAndVacanciesSystemContext() : base("MyDB")
        { }
        public DbSet<Hirer> Hirers { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
