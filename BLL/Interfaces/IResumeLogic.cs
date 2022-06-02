using BLL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IResumeLogic
    {
        List<MResume> GetAll();
        MResume GetById(int id);
        void DeleteById(int id);
        void Change(MResume resume);
        void OfferResume(int resumeId, int hirerId);
        List<MResume> GetOferedResumes(int hirerId);
        List<MResume> GetWorkerResumes(int workerId);
        List<MResume> GetFilteredResume(string jobTitle, double offeredsalary, int experience, bool higherEducation);
    }
}
