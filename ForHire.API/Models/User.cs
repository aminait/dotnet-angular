using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace ForHire.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhotoUrl { get; set; }
        public string HeaderPhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentPosition { get; set; }
        public int YearsOfExperience { get; set; }

        // [ForeignKey("Keyword")]
        // public int RoleOfInterestId { get; set; }
        public virtual ICollection<Keyword> RolesOfInterest { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SocialProfile> SocialProfiles { get; set; }
        public string Achievements { get; set; }

        // [ForeignKey("ResumeSection")]
        // public int EducationId { get; set; }
        public virtual Resume Resume { get; set; }
        public virtual ICollection<ResumeSection> Education { get; set; }

        // [ForeignKey("ResumeSection")]
        // public int ExperienceId { get; set; }
        public virtual ICollection<ResumeSection> Experience { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime LastActive { get; set; }

        // [ForeignKey("Keyword")]
        // public int SkillId { get; set; }
        public virtual ICollection<Keyword> Skills { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
        public DateTime Created { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}