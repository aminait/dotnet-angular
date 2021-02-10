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

        public async Task<IEnumerable<JobListing>> GetJobListings()
        {
            var listings = await _context.JobListings.ToListAsync();
            return listings;
        }

        public async Task<JobListing> GetJobListing(int id)
        {
            var listing = await _context.JobListings.FirstOrDefaultAsync(jl => jl.Id == id);

            return listing;
        }
    }
}