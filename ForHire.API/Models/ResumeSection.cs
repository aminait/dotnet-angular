using System;

namespace ForHire.API.Models
{
    public class ResumeSection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

        // public int EducationId { get; set; }
        // public int ExperienceId { get; set; }


    }
}