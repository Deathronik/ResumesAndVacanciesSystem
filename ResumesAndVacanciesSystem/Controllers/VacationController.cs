using BLL.Entities;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace ResumesAndVacanciesSystem.Controllers
{
    public class VacationController : ApiController
    {
        private readonly IVacationLogic vacationLogic;
        public VacationController(IVacationLogic vacationLogic)
        {
            this.vacationLogic = vacationLogic;
        }

        // GET api/Vacation 
        public IEnumerable<MVacation> Get()
        {
            return vacationLogic.GetAll();
        }

        public IEnumerable<MVacation> Get(string jobTitle, double salary, int experience, bool noHigherEducation)
        {
            return vacationLogic.GetFilteredData(jobTitle, salary, experience, noHigherEducation);
        }

        // GET api/Vacation/5
        public MVacation Get(int id)
        {
            return vacationLogic.GetById(id);
        }

        public void Post(int vacationID, int workerID)
        {
            vacationLogic.OfferVacation(vacationID, workerID);
        }

        // PUT api/Vacation/5
        public void Put([FromBody] MVacation Vacation)
        {
            vacationLogic.Change(Vacation);
        }

        // DELETE api/Vacation/5
        public void Delete(int id)
        {
            vacationLogic.DeleteById(id);
        }
    }
}