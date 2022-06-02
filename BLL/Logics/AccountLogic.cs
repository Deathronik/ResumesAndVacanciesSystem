using System.Collections.Generic;
using AutoMapper;
using DAL;
using BLL.Interfaces;
using BLL.Entities;
using DAL.Models;

namespace BLL.Logics
{
    public class AccountLogic : IAccountLogic
    {
        private IUnitOfWork UnitOFWork;
        private IMapper HirerMap = new MapperConfiguration(cfg => cfg.CreateMap<Hirer, MHirer>()).CreateMapper();
        private IMapper WorkerMap = new MapperConfiguration(cfg => cfg.CreateMap<Worker, MWorker>()).CreateMapper();

        public AccountLogic(IUnitOfWork unitOfWork)
        {
            UnitOFWork = unitOfWork;
        }
        public Account GetAccount(string email, string password)
        {
            MHirer haccount = HirerMap.Map<List<Hirer>, List<MHirer>>(UnitOFWork.Hirer.GetData()).Find(x => x.Email == email);
            if (haccount != null && haccount.Password == password)
            {
                return new Account()
                {
                    Id = haccount.Id,
                    Names = haccount.Names,
                    PhoneNumber = haccount.PhoneNumber,
                    Email = haccount.Email,
                    Password = haccount.Password,
                    AccountType = 1
                };
            }
            else
            {
                MWorker waccount = WorkerMap.Map<List<Worker>, List<MWorker>>(UnitOFWork.Worker.GetData()).Find(x => x.Email == email);
                if (waccount != null && waccount.Password == password)
                {
                    return new Account()
                    {
                        Id = waccount.Id,
                        Names = waccount.Names,
                        PhoneNumber = waccount.PhoneNumber,
                        Email = waccount.Email,
                        Password = waccount.Password,
                        AccountType = 2
                    };
                }
                else
                    return null;
            }
        }
    }
}
