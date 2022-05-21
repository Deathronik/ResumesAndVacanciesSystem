using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;

namespace BLL
{
    class HirerLogic
    {
        private IMapper HirerMap = new MapperConfiguration(cfg => cfg.CreateMap<Hirer, MHirer>()).CreateMapper();
        private UnitOfWork UnitOFWork;

        public HirerLogic(UnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public List<MHirer> GetAll()
        {
            return HirerMap.Map<List<Hirer>, List<MHirer>>(UnitOFWork.Hirer().GetData());
        }
        public MHirer GetById(int id)
        {
            return HirerMap.Map<Hirer, MHirer>(UnitOFWork.Hirer().FindById(id));
        }
        public void DeleteById(int id)
        {
            foreach (MVacation vacation in GetById(id).Vacations)
                UnitOFWork.Vacation().RemoveAtId(vacation.Id);
            UnitOFWork.Hirer().RemoveAtId(id);
            UnitOFWork.Save();
        }
        public List<MResume> GetOferedResumes(int hirerId) // Повертає список всіх запропонованих резюме даного роботодавця
        {
            return HirerMap.Map<Hirer, MHirer>(UnitOFWork.Hirer().FindById(hirerId)).Resume;
        }
        public void OfferVacation(int vacationId, int workerId) // Передає працівнику ваканцію
        {
            UnitOFWork.Worker().FindById(workerId).Vacations.Add(UnitOFWork.Vacation().FindById(vacationId));
            UnitOFWork.Save();
        }
        public List<MVacation> GetHirerVacations(int hirerId) // Повертає список всіх ваканцій даного роботодавця
        {
            return HirerMap.Map<Hirer, MHirer>(UnitOFWork.Hirer().FindById(hirerId)).Vacations;
        }
        public void CreateVacation(int hirerID, string jobTitle, double salary, bool isBonus, int experience, bool isHigherEducation, 
            List<string> description, string cityName, List<string> workSchedule)
        {
            MHirer hirer = GetById(hirerID);
            HirerMap.Map<Hirer>(UnitOFWork.Hirer().FindById(hirerID)).Vacations.Add(new Vacation()
            {
                CompanyName = hirer.CompanyName,
                HirerNames = hirer.Names,
                JobTitle = jobTitle,
                Salary = salary,
                IsBonus = isBonus,
                Experience = experience,
                IsHigherEducation = isHigherEducation,
                PhoneNumber = hirer.PhoneNumber,
                Email = hirer.Email,
                Description = description,
                CityName = cityName,
                WorkSchedule = workSchedule
            });
            UnitOFWork.Save();
        }
        public void Create(string companyName, string names, string phoneNumber, string email)
        {
            UnitOFWork.Hirer().Add(new Hirer() 
            {
                CompanyName = companyName,
                Names = names,
                PhoneNumber = phoneNumber,
                Email = email,
                Vacations = new List<Vacation>(),
                Resume = new List<Resume>()
            });
            UnitOFWork.Save();
        }
        public static List<string> GetInfo(MHirer hirer)
        {
            List<string> data = new List<string>();
            data.Add("Роботодавець: " + hirer.Names);
            data.Add("Назва компанії: " + hirer.CompanyName);
            data.Add("Номер телефону: " + hirer.PhoneNumber);
            data.Add("Електронна пошта: " + hirer.Email);
            return data;
        }
    }
}
