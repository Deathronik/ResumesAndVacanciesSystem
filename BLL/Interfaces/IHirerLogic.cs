using BLL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IHirerLogic
    {
        List<MHirer> GetAll();
        MHirer GetById(int id);
        void DeleteById(int id);
        void Change(MHirer hirer);
        void CreateVacation(int hirerID, MVacation vacation);
        void Create(MHirer hirer);
    }
}
