using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyDB")
        { }
        public DbSet<Hirer> Hirers { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
