using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;
using BLL.Interfaces;

namespace BLL.Logics
{
    public class WorkerLogic : IWorkerLogic
    {
        private IMapper WorkerMap = new MapperConfiguration(cfg => cfg.CreateMap<Worker, MWorker>()).CreateMapper();
        private IUnitOfWork UnitOFWork;
        public WorkerLogic(IUnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public List<MWorker> GetAll()
        {
            return WorkerMap.Map<List<Worker>, List<MWorker>>(UnitOFWork.Worker.GetData());
        }
        public MWorker GetById(int id)
        {
            return WorkerMap.Map<Worker, MWorker>(UnitOFWork.Worker.FindById(id));
        }
        public void DeleteById(int id)
        {
            foreach (MResume resume in GetById(id).Resumes)
                UnitOFWork.Resume.RemoveAtId(resume.Id);
            UnitOFWork.Worker.RemoveAtId(id);
            UnitOFWork.Save();
        }
        public void Change(MWorker worker)
        {
            UnitOFWork.Worker.Update(new Worker
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
        public void CreateResume(int workerID, MResume resume)
        {
            MWorker worker = GetById(workerID);
            UnitOFWork.Resume.Add(new Resume()
            {
                UserNames = worker.Names,
                JobTitle = resume.JobTitle,
                OfferedSalary = resume.OfferedSalary,
                DateOfBirth = worker.DateOfBirth,
                Experience = resume.Experience,
                IsHigherEducation = resume.IsHigherEducation,
                PhoneNumber = worker.PhoneNumber,
                Email = worker.Email,
                Description = resume.Description,
                CharacterInfo = resume.CharacterInfo,
                WorkerId = worker.Id,
                HirerId = new List<int>()
            });
            UnitOFWork.Save();
        }
        public void Create(MWorker worker)
        {
            UnitOFWork.Worker.Add(new Worker
            {
                Names = worker.Names,
                PhoneNumber = worker.PhoneNumber,
                Email = worker.Email,
                DateOfBirth = worker.DateOfBirth,
                Password = worker.Password,
                Resumes = new List<Resume>(),
                Vacations = new List<Vacation>()
            });
            UnitOFWork.Save();
        }
    }
}
