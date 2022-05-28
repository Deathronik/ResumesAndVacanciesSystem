using System.Collections.Generic;

namespace BLL.Entities
{
    public class MHirer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Names { get; set; } // Прізвище + Ім'я + По батькові
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<MVacation> Vacations { get; set; }
        public List<MResume> Resume { get; set; }
    }
}
