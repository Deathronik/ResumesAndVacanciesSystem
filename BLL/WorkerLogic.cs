using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;

namespace BLL
{
    class WorkerLogic
    {
        private IMapper WorkerMap = new MapperConfiguration(cfg => cfg.CreateMap<Worker, MWorker>()).CreateMapper();
        private UnitOfWork UnitOFWork;
        public WorkerLogic(UnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public MWorker GetById(int id)
        {
            return WorkerMap.Map<Worker, MWorker>(UnitOFWork.Worker().FindById(id));
        }
        public void DeleteById(int id)
        {
            foreach (MResume resume in GetById(id).Resumes)
                UnitOFWork.Resume().RemoveAtId(resume.Id);
            UnitOFWork.Worker().RemoveAtId(id);
            UnitOFWork.Save();
        }
        public List<MVacation> GetOferedVacations(int workerId) // Повертає список всіх запропонованих ваканцій даного працівника
        {
            return WorkerMap.Map<Worker, MWorker>(UnitOFWork.Worker().FindById(workerId)).Vacations;
        }
        public void OfferResume(int resumeId, int hirerId) // Передає роботодавцю резюме
        {
            UnitOFWork.Hirer().FindById(hirerId).Resume.Add(UnitOFWork.Resume().FindById(resumeId));
            UnitOFWork.Save();
        }
        public List<MResume> GetWorkerResumes(int workerId) // Повертає список всіх резюме даного працівника
        {
            return WorkerMap.Map<Worker, MWorker>(UnitOFWork.Worker().FindById(workerId)).Resumes;
        }
        public void CreateResume(int workerID, string jobTitle, double offeredSalary, int experience, bool isHigherEducation, 
            List<string> description, List<string> characterInfo)
        {
            MWorker worker = GetById(workerID);
            WorkerMap.Map<Worker>(UnitOFWork.Worker().FindById(workerID)).Resumes.Add(new Resume() 
            { 
                UserNames = worker.Names, 
                JobTitle = jobTitle,
                OfferedSalary = offeredSalary,
                DateOfBirth = worker.DateOfBirth,
                Experience = experience,
                IsHigherEducation = isHigherEducation,
                PhoneNumber = worker.PhoneNumber,
                Email = worker.Email,
                Description = description,
                CharacterInfo = characterInfo
            });
            UnitOFWork.Save();
        }
        public void Create(string names, string phoneNumber, string email, string dateOfBirth)
        {
            UnitOFWork.Worker().Add(new Worker()
            {
                Names = names,
                PhoneNumber = phoneNumber,
                Email = email,
                DateOfBirth = dateOfBirth,
                Resumes = new List<Resume>(),
                Vacations = new List<Vacation>()
            });
            UnitOFWork.Save();
        }
        public static List<string> GetWorkerInfo(MWorker worker)
        {
            List<string> data = new List<string>();
            data.Add("Працівник: " + worker.Names);
            data.Add("Дата народження: " + worker.DateOfBirth);
            data.Add("Номер телефону: " + worker.PhoneNumber);
            data.Add("Електронна пошта: " + worker.Email);
            return data;
        }
    }
}
