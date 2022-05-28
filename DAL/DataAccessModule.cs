using DAL.Models;
using Ninject.Modules;

namespace DAL
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            var Context = new ResumesAndVacanciesSystemContext();

            Bind<IGenericRepository<Hirer>>().ToConstructor(x => new ContextRepository<Hirer>(Context));
            Bind<IGenericRepository<Resume>>().ToConstructor(x => new ContextRepository<Resume>(Context));
            Bind<IGenericRepository<Vacation>>().ToConstructor(x => new ContextRepository<Vacation>(Context));
            Bind<IGenericRepository<Worker>>().ToConstructor(x => new ContextRepository<Worker>(Context));

            Bind<IUnitOfWork>().ToConstructor
                (x => new UnitOfWork(Context, x.Inject<IGenericRepository<Hirer>>(), x.Inject<IGenericRepository<Resume>>(),
                x.Inject<IGenericRepository<Vacation>>(), x.Inject<IGenericRepository<Worker>>()));
        }
    }
}
