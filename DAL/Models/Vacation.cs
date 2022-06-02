using System.Collections.Generic;

namespace DAL.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string HirerNames { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
        public bool IsBonus { get; set; }
        public int Experience { get; set; }
        public bool IsHigherEducation { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CityName { get; set; }
        public int HirerId { get; set; }
        public List<int> WorkerId { get; set; }
    }
}
