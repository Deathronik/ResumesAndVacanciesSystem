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
        public List<MResume> GetAll()
        {
            return ResumeMap.Map<List<Resume>, List<MResume>>(UnitOFWork.Resume().GetData());
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
        // Повертає відфільтровані резюме (якщо в jobTitle передати "none", назва роботи не буде ураховуватись, якщо в offeredsalary передати 0 заробітня плата
        // не буде ураховуватись, так само в experience, higherEducation відповідає чи потрібно шукати резюме в якій є вища освіта, якщо передати 
        // true буде шукати з вищою освітою
        public List<MResume> GetFilteredResume(string jobTitle, double offeredsalary, int experience, bool higherEducation)
        {
            bool isjobTitle, issalary, isexperience, isHigherEducation;
            List<MResume> data = new List<MResume>();
            foreach(MResume resume in ResumeMap.Map<List<Resume>, List<MResume>>(UnitOFWork.Resume().GetData()))
            {
                if (jobTitle != "none")
                {
                    if (jobTitle == resume.JobTitle)
                        isjobTitle = true;
                    else
                        isjobTitle = false;
                }
                else
                    isjobTitle = true;
                if (offeredsalary != 0)
                {
                    if (offeredsalary <= resume.OfferedSalary)
                        issalary = true;
                    else
                        issalary = false;
                }
                else
                    issalary = true;
                if (experience != 0)
                {
                    if (experience >= resume.Experience)
                        isexperience = true;
                    else
                        isexperience = false;
                }
                else
                    isexperience = true;
                if (higherEducation)
                {
                    if (resume.IsHigherEducation)
                        isHigherEducation = true;
                    else
                        isHigherEducation = false;
                }
                else
                    isHigherEducation = true;
                if (isjobTitle && issalary && isexperience && isHigherEducation)
                    data.Add(resume);
            }
            return data;
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
