using BLL.Entities;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace ResumesAndVacanciesSystem.Controllers
{
    public class HirerController : ApiController
    {
        private readonly IHirerLogic hirerLogic;
        public HirerController(IHirerLogic hirerLogic)
        {
            this.hirerLogic = hirerLogic;
        }

        // GET api/Hirer 
        public IEnumerable<MHirer> Get()
        {
            return hirerLogic.GetAll();
        }

        // GET api/Hirer/5
        public MHirer Get(int id)
        {
            return hirerLogic.GetById(id);
        }

        // POST api/Hirer
        public void Post([FromBody] MHirer hirer)
        {
            hirerLogic.Create(hirer);
        }


        // POST api/Hirer?hirerID={hirerID}
        public void Post(int hirerID, [FromBody] MVacation vacation)
        {
            hirerLogic.CreateVacation(hirerID, vacation);
        }

        // PUT api/Hirer/5
        public void Put([FromBody] MHirer hirer)
        {
            hirerLogic.Change(hirer);
        }

        // DELETE api/Hirer/5
        public void Delete(int id)
        {
            hirerLogic.DeleteById(id);
        }
    }
}