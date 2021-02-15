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
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<SocialProfile> SocialProfiles { get; set; }

    }
}