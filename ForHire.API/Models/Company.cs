using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ForHire.API.Models
{
    public class Company {
        public int CompanyId { get; set; }
        public string PhotoUrl { get; set; }
        public string CompanyName { get; set; }
        public string Tagline { get; set; }
        public int CompanySize { get; set; }
        public string Description { get; set; }
        public string Field { get; set; }
        public virtual ICollection<SocialProfile> SocialProfiles { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<JobListing> JobListings { get; set; }
    }
}