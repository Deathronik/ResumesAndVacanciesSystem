using System.Collections.Generic;

namespace DAL.Models
{
    class Hirer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string HirerNames { get; set; }
        public string Communication { get; set; }
        public List<Vacation> Vacations { get; set; }
        public List<Resume> Resume { get; set; }
    }
}
