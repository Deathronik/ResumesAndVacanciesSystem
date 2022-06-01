using Ninject;
using Ninject.Modules;
using BLL.Logics;
using BLL.Interfaces;
using DAL;

namespace BLL
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            var unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
            Bind<IHirerLogic>().ToConstructor(x => new HirerLogic(unitOfWork));
            Bind<IResumeLogic>().ToConstructor(x => new ResumeLogic(unitOfWork));
            Bind<IVacationLogic>().ToConstructor(x => new VacationLogic(unitOfWork));
            Bind<IWorkerLogic>().ToConstructor(x => new WorkerLogic(unitOfWork));
            Bind<IAccountLogic>().ToConstructor(x => new AccountLogic(unitOfWork));
        }
    }
}
