using System.Collections.Generic;
using DAL;
using AutoMapper;
using BLL.Entities;
using DAL.Models;
using BLL.Interfaces;

namespace BLL.Logics
{
    public class HirerLogic : IHirerLogic
    {
        private IMapper HirerMap = new MapperConfiguration(cfg => cfg.CreateMap<Hirer, MHirer>()).CreateMapper();
        private IUnitOfWork UnitOFWork;

        public HirerLogic(IUnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public List<MHirer> GetAll()
        {
            return HirerMap.Map<List<Hirer>, List<MHirer>>(UnitOFWork.Hirer.GetData());
        }
        public MHirer GetById(int id)
        {
            return HirerMap.Map<Hirer, MHirer>(UnitOFWork.Hirer.FindById(id));
        }
        public void DeleteById(int id)
        {
            foreach (MVacation vacation in GetById(id).Vacations)
                UnitOFWork.Vacation.RemoveAtId(vacation.Id);
            UnitOFWork.Hirer.RemoveAtId(id);
            UnitOFWork.Save();
        }
        public void Change(MHirer hirer)
        {
            UnitOFWork.Hirer.Update(new Hirer()
            {
                Id = hirer.Id,
                CompanyName = hirer.CompanyName,
                Names = hirer.Names,
                PhoneNumber = hirer.PhoneNumber,
                Email = hirer.Email,
                Password = hirer.Password,
                Vacations = HirerMap.Map<List<Vacation>>(hirer.Vacations),
                Resume = HirerMap.Map<List<Resume>>(hirer.Resume)
            });
            UnitOFWork.Save();
        }
        public void CreateVacation(int hirerID, MVacation vacation)
        {
            MHirer hirer = GetById(hirerID);
            UnitOFWork.Vacation.Add(new Vacation()
            {
                CompanyName = hirer.CompanyName,
                HirerNames = hirer.Names,
                JobTitle = vacation.JobTitle,
                Salary = vacation.Salary,
                IsBonus = vacation.IsBonus,
                Experience = vacation.Experience,
                IsHigherEducation = vacation.IsHigherEducation,
                PhoneNumber = hirer.PhoneNumber,
                Email = hirer.Email,
                Description = vacation.Description,
                CityName = vacation.CityName,
                HirerId = hirer.Id,
                WorkerId = new List<int>()
            });
            UnitOFWork.Save();
        }
        public void Create(MHirer hirer)
        {
            UnitOFWork.Hirer.Add(new Hirer() 
            {
                CompanyName = hirer.CompanyName,
                Names = hirer.Names,
                PhoneNumber = hirer.PhoneNumber,
                Email = hirer.Email,
                Password = hirer.Password,
                Vacations = new List<Vacation>(),
                Resume = new List<Resume>()
            });
            UnitOFWork.Save();
        }
    }
}
