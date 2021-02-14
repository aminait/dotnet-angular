using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ForHire.API.Models
{
    public class JobListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Seniority { get; set; }
        public ICollection<Industry> Industries { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsRecruiting { get; set; }
        public DateTime DatePosted { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

