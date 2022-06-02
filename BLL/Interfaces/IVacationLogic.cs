using BLL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IVacationLogic
    {
        List<MVacation> GetAll();
        MVacation GetById(int id);
        void DeleteById(int id);
        void Change(MVacation vacation);
        void OfferVacation(int vacationId, int workerId);
        List<MVacation> GetHirerVacations(int hirerId);
        List<MVacation> GetOferedVacations(int workerId);
        List<MVacation> GetFilteredData(string jobTitle, double salary, int experience, bool noHigherEducation);
    }
}
