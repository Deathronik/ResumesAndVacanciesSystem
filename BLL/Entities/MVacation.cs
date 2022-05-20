using System.Collections.Generic;

namespace BLL.Entities
{
    class MVacation
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string HirerNames { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
        public bool IsBonus { get; set; }
        public int Experience { get; set; }
        public bool IsHigherEducation { get; set; }
        public List<string> Description { get; set; }
        public string CityName { get; set; }
        public string[][] WorkSchedule { get; set; }
        public int HirerId { get; set; }
        public int WorkerId { get; set; }
    }
}
