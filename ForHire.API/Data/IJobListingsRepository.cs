using System.Collections.Generic;
using System.Threading.Tasks;
using ForHire.API.Models;
namespace ForHire.API.Data
{
    public interface IJobListingsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<JobListing>> GetJobListings();
        Task<JobListing> GetJobListing(int id);
        Task<List<Tag>> GetJobListingTags(int id);
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int companyId);
        Task<List<SocialProfile>> GetCompanySocialProfiles(int companyId);
    }
}