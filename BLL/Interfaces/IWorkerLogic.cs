using BLL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IWorkerLogic
    {
        List<MWorker> GetAll();
        MWorker GetById(int id);
        void DeleteById(int id);
        void Change(MWorker worker);
        void CreateResume(int workerID, MResume resume);
        void Create(MWorker worker);
    }
}
