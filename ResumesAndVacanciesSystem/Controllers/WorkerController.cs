using BLL.Entities;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ResumesAndVacanciesSystem.Controllers
{
    public class WorkerController : ApiController
    {
        private readonly IWorkerLogic workerLogic;
        public WorkerController(IWorkerLogic workerLogic)
        {
            this.workerLogic = workerLogic;
        }

        // GET api/Worker 
        public IEnumerable<MWorker> Get()
        {
            return workerLogic.GetAll();
        }

        // GET api/Worker/5
        public MWorker Get(int id)
        {
            return workerLogic.GetById(id);
        }

        // POST api/Worker
        public void Post([FromBody] MWorker worker)
        {
            workerLogic.Create(worker);
        }

        // POST api/Worker?workerID={workerID}
        public void Post(int workerID, [FromBody] MResume resume)
        {
            workerLogic.CreateResume(workerID, resume);
        }

        // PUT api/Worker/5
        public void Put([FromBody] MWorker worker)
        {
            workerLogic.Change(worker);
        }

        // DELETE api/Worker/5
        public void Delete(int id)
        {
            workerLogic.DeleteById(id);
        }
    }
}