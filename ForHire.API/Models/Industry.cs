using System;

namespace ForHire.API.Models
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual JobListing JobListing { get; set; }
        public virtual int JobListingId { get; set; }
    }
}