﻿using System.Collections.Generic;

namespace BLL.Entities
{
    public class MResume
    {
        public int Id { get; set; }
        public string UserNames { get; set; } // Прізвище + Ім'я  + По батькові
        public string JobTitle { get; set; } // Назва роботи
        public double OfferedSalary { get; set; }
        public string DateOfBirth { get; set; }
        public int Experience { get; set; } // Досвід роботи
        public bool IsHigherEducation { get; set; } // Чи є вища освіта
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; } // Описується де і коли працював/отримав освіту + біографія
        public string CharacterInfo { get; set; } // Характеристика людини
        public int WorkerId { get; set; }
        public List<int> HirerId { get; set; }
    }
}
