using System;

namespace ForHire.API.Models
{
    public class JobListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
    }
}