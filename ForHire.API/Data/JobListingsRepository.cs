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

        public async Task<IEnumerable<JobListing>> GetSavedJobListings()
        {
            var savedJobListings = await _context.JobListings.Where(jl => jl.IsSaved).ToListAsync();
            return savedJobListings;
        }


        public async Task<List<Tag>> GetJobListingTags(int id)
        {
            // select from tags where joblistingid == id
            var tags = await _context.Tags.Where(tag => tag.JobListingId == id).ToListAsync();
            return tags;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> GetCompany(int companyId)
        {

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            return company;
        }

        public async Task<List<SocialProfile>> GetCompanySocialProfiles(int companyId)
        {
            var profiles = await _context.SocialProfiles.Where(profile => profile.CompanyId == companyId).ToListAsync();
            return profiles;
        }
    }
}