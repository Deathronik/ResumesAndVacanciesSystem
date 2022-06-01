using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IAccountLogic
    {
        Account GetAccount(string email, string password);
    }
}
