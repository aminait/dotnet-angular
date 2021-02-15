using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ForHire.API.Models;

namespace ForHire.API.Data
{
    public class DataRepository : IDataRepository
    {
        private DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<int> DeleteUser(int? id)
        {
            int result = 0;

            if (_context != null)
            {
                //Find the post for specific post id
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user != null)
                {
                    //Delete that post
                    _context.Users.Remove(user);

                    //Commit the transaction
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }




    }
}