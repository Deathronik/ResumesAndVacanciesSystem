using System.Collections.Generic;

namespace DAL.Models
{
    class Worker
    {
        public int Id { get; set; }
        public string UserNames { get; set; }
        public string Communication { get; set; }
        public string DateOfBirth { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
