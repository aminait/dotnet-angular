using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ForHire.API.Models;

namespace ForHire.API.Data
{
    public class JobListingsRepository : IJobListingsRepository
    {
        private DataContext _context;

        public JobListingsRepository(DataContext context)
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

        public async Task<Company> GetCompany(int id)
        {
            var listing = (from jl in _context.JobListings
                           where jl.Id == id
                           select jl).FirstOrDefault();

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == listing.CompanyId);

            return company;
        }
    }
}