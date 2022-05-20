using System.Collections.Generic;

namespace DAL.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
