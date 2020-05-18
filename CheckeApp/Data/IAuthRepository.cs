using System.Threading.Tasks;
using CheckeApp.Models;

namespace CheckeApp.Data
{
    public interface IAuthRepository
    {
         Task<Account> Register(Account user, string password);
         Task<Account> Login(string username, string password);
         Task<bool> UserExist(string username);
    }
}