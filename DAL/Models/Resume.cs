﻿using System.Collections.Generic;

namespace DAL.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string UserNames { get; set; }
        public string JobTitle { get; set; }
        public double OfferedSalary { get; set; }
        public string DateOfBirth { get; set; }
        public int Experience { get; set; }
        public bool IsHigherEducation { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CharacterInfo { get; set; }
        public int WorkerId { get; set; }
        public List<int> HirerId { get; set; }
    }
}
