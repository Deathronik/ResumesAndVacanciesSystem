using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    class MResume
    {
        public int Id { get; set; }
        public string UserNames { get; set; }
        public string JobTitle { get; set; }
        public double OfferedSalary { get; set; }
        public string DateOfBirth { get; set; }
        public int Experience { get; set; }
        public bool IsHigherEducation { get; set; }
        public string Communication { get; set; }
        public List<string> Description { get; set; }
        public List<string> CharacterInfo { get; set; }
        public int WorkerId { get; set; }
        public int HirerId { get; set; }
    }
}
