using System.Collections.Generic;

namespace BLL.Entities
{
    class MHirer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string HirerNames { get; set; }
        public string Communication { get; set; }
        public List<MVacation> Vacations { get; set; }
        public List<MResume> Resume { get; set; }
    }
}
