using System.Collections.Generic;

namespace BLL.Entities
{
    public class MWorker
    {
        public int Id { get; set; }
        public string Names { get; set; } // Прізвище + Ім'я + По батькові
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public List<MResume> Resumes { get; set; }
        public List<MVacation> Vacations { get; set; }
    }
}
