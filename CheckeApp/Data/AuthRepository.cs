using System.Threading.Tasks;
using CheckeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckeApp.Data
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Account> Login(string username, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == username);

            if (account == null)
                return null;

            if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
                return null;

            return account;
        }

        public async Task<Account> Register(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _context.Accounts.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != PasswordHash[i])
                        return false;
                }
            }

            return true;
        }
    }
}