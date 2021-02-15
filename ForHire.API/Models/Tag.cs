using System;

namespace ForHire.API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual JobListing JobListing { get; set; }
        public virtual int JobListingId { get; set; }
    }
}