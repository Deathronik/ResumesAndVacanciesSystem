using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    class MWorker
    {
        public int Id { get; set; }
        public string UserNames { get; set; }
        public string Communication { get; set; }
        public string DateOfBirth { get; set; }
        public List<MResume> Resumes { get; set; }
        public List<MVacation> Vacations { get; set; }
    }
}
