using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using ForHire.API.Models;

namespace ForHire.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<JobListing> JobListings { get; set; }

    }
}