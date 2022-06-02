using System.Collections.Generic;

namespace BLL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }
    }
}
