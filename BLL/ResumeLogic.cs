using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;

namespace BLL
{
    class ResumeLogic
    {
        private IMapper ResumeMap = new MapperConfiguration(cfg => cfg.CreateMap<Resume, MResume>()).CreateMapper();
        private UnitOfWork UnitOFWork;

        public ResumeLogic(UnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public MResume GetById(int id)
        {
            return ResumeMap.Map<Resume, MResume>(UnitOFWork.Resume().FindById(id));
        }
        public void DeleteById(int id)
        {
            UnitOFWork.Resume().RemoveAtId(id);
            UnitOFWork.Save();
        }
        public List<string> GetAllInfo()
        {
            List<string> data = new List<string>();
            int num = 0;
            foreach(MResume resume in ResumeMap.Map<List<Resume>, List<MResume>>(UnitOFWork.Resume().GetData()))
            {
                num += 1;
                data.Add("------------------------" + num + "№------------------------");
                data.AddRange(GetResumeInfo(resume));
            }
            return data;
        }
        public static List<string> GetResumeInfo(MResume resume)
        {
            List<string> data = new List<string>();
            data.Add(resume.UserNames);
            data.Add("Бажана посада: " + resume.JobTitle);
            data.Add("Бажана заробітна плата: " + resume.OfferedSalary);
            data.Add("Дата народження: " + resume.DateOfBirth);
            data.Add("Контактна інформація:");
            data.Add("  Номер телефону: " + resume.PhoneNumber);
            data.Add("  Електронна пошта: " + resume.Email);
            data.Add("Ключова інформація:");
            if (resume.Experience == 0)
                data.Add("  Без досвіду роботи");
            else
                data.Add("  Досвід роботи: " + resume.Experience);
            if (resume.IsHigherEducation)
                data.Add("  Має вищу освіту");
            else
                data.Add("  Без вищої освіти");
            data.Add("Характеристика і навички:");
            foreach (string line in resume.CharacterInfo)
                data.Add("  " + line);
            data.Add("Біографія:");
            foreach (string line in resume.Description)
                data.Add("  " + line);
            return data;
        }
        public static List<string> GetWorkSchedule(MVacation vacation) // Вивід графік роботи краще окремим меню, як доповнення
        {
            return vacation.WorkSchedule;
        }
    }
}
