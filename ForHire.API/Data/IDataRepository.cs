using System.Collections.Generic;
using System.Threading.Tasks;
using ForHire.API.Models;

namespace ForHire.API.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<int> DeleteUser(int? id);
        Task<Message> GetMessage(int id);
        Task<IEnumerable<Message>> GetMessagesForuser();
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}