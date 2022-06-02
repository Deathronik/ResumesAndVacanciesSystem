using System.Collections.Generic;

namespace BLL.Entities
{
    public class MVacation
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string HirerNames { get; set; } // Прізвище + Ім'я роботодавця  + По батькові
        public string JobTitle { get; set; } // Назва роботи
        public double Salary { get; set; }
        public bool IsBonus { get; set; } // Чи є премії і т.д.
        public int Experience { get; set; } // Потрібний досвід роботи
        public bool IsHigherEducation { get; set; } // Чи потрібна вища освіта
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Description { get; set; }
        public string CityName { get; set; }
        public int HirerId { get; set; }
        public List<int> WorkerId { get; set; }
    }
}
