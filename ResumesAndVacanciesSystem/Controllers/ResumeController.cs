using BLL.Entities;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ResumesAndVacanciesSystem.Controllers
{
    public class ResumeController : ApiController
    {
        private readonly IResumeLogic resumeLogic;
        public ResumeController(IResumeLogic resumeLogic)
        {
            this.resumeLogic = resumeLogic;
        }

        // GET api/Resume 
        public IEnumerable<MResume> Get()
        {
            return resumeLogic.GetAll();
        }

        public IEnumerable<MResume> Get(string jobTitle, double offeredsalary, int experience, bool higherEducation)
        {
            return resumeLogic.GetFilteredResume(jobTitle, offeredsalary, experience, higherEducation);
        }

        // GET api/Resume/5
        public MResume Get(int id)
        {
            return resumeLogic.GetById(id);
        }

        // Put api/Resume/5
        public void Put([FromBody] MResume resume)
        {
            resumeLogic.Change(resume);
        }


        // POST api/Resume?resumeID={resumeID}&hirerID={hirerID}
        public void Post(int resumeID, int hirerID)
        {
            resumeLogic.OfferResume(resumeID, hirerID);
        }

        // DELETE api/Resume/5
        public void Delete(int id)
        {
            resumeLogic.DeleteById(id);
        }
    }
}