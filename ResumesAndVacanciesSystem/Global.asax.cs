using BLL;
using Ninject;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ResumesAndVacanciesSystem
{
    public class WebApiApplication : HttpApplication
    {
        private IKernel _kernel;

        protected void Application_Start()
        {
            RegisterServices();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(_kernel);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        private void RegisterServices()
        {
            _kernel = new StandardKernel(new BusinessLogicModule());
        }
    }
}
