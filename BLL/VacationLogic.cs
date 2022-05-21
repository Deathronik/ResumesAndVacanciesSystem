using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;

namespace BLL
{
    class VacationLogic
    {
        private IMapper VacationMap = new MapperConfiguration(cfg => cfg.CreateMap<Vacation, MVacation>()).CreateMapper();
        private UnitOfWork UnitOFWork;

        public VacationLogic(UnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public List<MVacation> GetAll()
        {
            return VacationMap.Map<List<Vacation>, List<MVacation>>(UnitOFWork.Vacation().GetData());
        }
        public MVacation GetById(int id)
        {
            return VacationMap.Map<Vacation, MVacation>(UnitOFWork.Vacation().FindById(id));
        }
        public void DeleteById(int id)
        {
            UnitOFWork.Vacation().RemoveAtId(id);
            UnitOFWork.Save();
        }
        // Повертає відфільтровані ваканції (якщо в jobTitle передати "none", назва роботи не буде ураховуватись, якщо в salary передати 0 заробітня плата
        // не буде ураховуватись, так само в experience, noHigherEducation відповідає чи потрібно шукати ваканцію в якій не потрібна вища освіта, якщо передати 
        // true буде шукати без вищої освіти
        public List<MVacation> GetFilteredData(string jobTitle, double salary, int experience, bool noHigherEducation)
        {
            bool isjobTitle, issalary, isexperience, isNoHigherEducation;
            List<MVacation> data = new List<MVacation>();
            foreach (MVacation vacation in VacationMap.Map<List<Vacation>, List<MVacation>>(UnitOFWork.Vacation().GetData()))
            {
                if(jobTitle != "none")
                {
                    if (jobTitle == vacation.JobTitle)
                        isjobTitle = true;
                    else
                        isjobTitle = false;
                }
                else
                    isjobTitle = true;
                if (salary != 0)
                {
                    if (salary <= vacation.Salary)
                        issalary = true;
                    else
                        issalary = false;
                }
                else
                    issalary = true;
                if (experience != 0)
                {
                    if (experience >= vacation.Experience)
                        isexperience = true;
                    else
                        isexperience = false;
                }
                else
                    isexperience = true;
                if (noHigherEducation)
                {
                    if (!vacation.IsHigherEducation)
                        isNoHigherEducation = true;
                    else
                        isNoHigherEducation = false;
                }
                else
                    isNoHigherEducation = true;
                if (isjobTitle && issalary && isexperience && isNoHigherEducation)
                    data.Add(vacation);
            }
            return data;
        }
        public List<string> GetAllInfo()
        {
            List<string> data = new List<string>();
            int num = 0;
            foreach (MVacation vacation in VacationMap.Map<List<Vacation>, List<MVacation>>(UnitOFWork.Vacation().GetData()))
            {
                num += 1;
                data.Add("------------------------" + num + "№------------------------");
                data.AddRange(GetVacationInfo(vacation));
            }
            return data;
        }
        public static List<string> GetVacationInfo(MVacation vacation)
        {
            List<string> data = new List<string>();
            data.Add("Запрошується на роботу: " + vacation.JobTitle);
            data.Add("Місто: " + vacation.CityName);
            data.Add("Назва компанії: " + vacation.CompanyName);
            data.Add("Роботодавець: " + vacation.HirerNames);
            data.Add("Заробітна плата: " + vacation.Salary);
            if (vacation.IsBonus)
                data.Add("Є премії і бонуси");
            else
                data.Add("Без премій і бонусів");
            data.Add("Потреби:");
            if (vacation.Experience == 0)
                data.Add("  Досвід роботи не потрібен");
            else
                data.Add("  Досвід роботи: " + vacation.Experience);
            if (vacation.IsHigherEducation)
                data.Add("  Потрібна вища освіта");
            else
                data.Add("  Вища освіта не потрібна");
            data.Add("Додаткова інформація:");
            data.AddRange(vacation.Description);
            data.Add("Контактна інформація:");
            data.Add("  Номер телефону: " + vacation.PhoneNumber);
            data.Add("  Електронна пошта: " + vacation.Email);
            return data;
        }
    }
}
