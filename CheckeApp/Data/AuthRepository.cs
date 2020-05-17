using System.Threading.Tasks;
using CheckeApp.Models;

namespace CheckeApp.Data
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
        }

        public Task<bool> UserExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}