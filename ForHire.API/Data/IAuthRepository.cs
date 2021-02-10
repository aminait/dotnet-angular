using System.Threading.Tasks;
using ForHire.API.Models;

namespace ForHire.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string email, string password);
         Task<bool> UserExists(string username);
    }
}