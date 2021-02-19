using System;
using Microsoft.AspNetCore.Http;

namespace ForHire.API.DTOs
{
    public class ResumeUploadDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public ResumeUploadDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}