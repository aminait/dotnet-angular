using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForHire.API.Models
{
    public class JobApplication
    {
        public int AppId { get; set; }
        public string Status { get; set; }

        public DateTime DateApplied { get; set; }


        [ForeignKey("JobListing")]
        public int Id { get; set; }
        public virtual JobListing JobListing { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User Candidate { get; set; }
    }
}

