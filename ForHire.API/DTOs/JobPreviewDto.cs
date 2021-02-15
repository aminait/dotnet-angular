using System;

namespace ForHire.API.DTOs
{
    public class JobPreviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string TimePosted { get; set; }
        public bool IsRecruiting { get; set; }
        public bool IsHidden { get; set; }
        public bool IsSaved { get; set; }
        public bool isExpanded { get; set; }
    }
}