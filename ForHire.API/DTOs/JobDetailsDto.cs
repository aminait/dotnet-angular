using System;

namespace ForHire.API.DTOs
{
    public class JobDetailsDto : JobPreviewDto
    {
        public string Type { get; set; }
        public string Seniority { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CompanySize { get; set; }
    }
}