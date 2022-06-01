using System.Collections.Generic;

namespace DAL.Models
{
    public class Hirer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Names { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Vacation> Vacations { get; set; }
        public List<Resume> Resume { get; set; }
    }
}
