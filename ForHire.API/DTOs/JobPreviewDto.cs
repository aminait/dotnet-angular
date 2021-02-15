using System;

namespace ForHire.API.DTOs
{
    public class JobPreviewDto
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string TimePosted { get; set; }
        public bool IsRecruiting { get; set; }
    }
}