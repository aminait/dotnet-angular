using System;
using ForHire.API.Models;
using System.Collections.Generic;


namespace ForHire.API.DTOs
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string HeaderPhotoUrl { get; set; }
        public string Description { get; set; }
        public string CurrentPosition { get; set; }
        public int YearsOfExperience { get; set; }
        public virtual ICollection<Keyword> Skills { get; set; }
        public virtual ICollection<Keyword> RolesOfInterest { get; set; }
        public virtual ICollection<SocialProfile> SocialProfiles { get; set; }
        public virtual ICollection<ResumeSection> Education { get; set; }
        public virtual ICollection<ResumeSection> Experience { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}