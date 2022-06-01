using System.Web.Http;
using BLL.Entities;
using BLL.Interfaces;

namespace ResumesAndVacanciesSystem.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountLogic accountLogic;
        public Account GetAccount(string email, string password)
        {
            return accountLogic.GetAccount(email, password);
        }
    }
}
