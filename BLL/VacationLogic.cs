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
        public MVacation GetById(int id)
        {
            return VacationMap.Map<Vacation, MVacation>(UnitOFWork.Vacation().FindById(id));
        }
        public void DeleteById(int id)
        {
            UnitOFWork.Vacation().RemoveAtId(id);
            UnitOFWork.Save();
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
