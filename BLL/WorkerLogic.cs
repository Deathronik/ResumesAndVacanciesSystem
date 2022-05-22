using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;

namespace BLL
{
    public class WorkerLogic
    {
        private IMapper WorkerMap = new MapperConfiguration(cfg => cfg.CreateMap<Worker, MWorker>()).CreateMapper();
        private UnitOfWork UnitOFWork;
        public WorkerLogic(UnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public List<MWorker> GetAll()
        {
            return WorkerMap.Map<List<Worker>, List<MWorker>>(UnitOFWork.Worker().GetData());
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
        public void Change(MWorker worker)
        {
            UnitOFWork.Worker().Update(new Worker()
            {
                Id = worker.Id,
                Names = worker.Names,
                PhoneNumber = worker.PhoneNumber,
                Email = worker.Email,
                DateOfBirth = worker.DateOfBirth,
                Resumes = WorkerMap.Map<List<Resume>>(worker.Resumes),
                Vacations = WorkerMap.Map<List<Vacation>>(worker.Vacations)
            });
            UnitOFWork.Save();
        }
        public void CreateResume(int workerID, string jobTitle, double offeredSalary, int experience, bool isHigherEducation, 
            List<string> description, List<string> characterInfo)
        {
            MWorker worker = GetById(workerID);
            UnitOFWork.Resume().Add(new Resume()
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
                CharacterInfo = characterInfo,
                WorkerId = worker.Id
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
