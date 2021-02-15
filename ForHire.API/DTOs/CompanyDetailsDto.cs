using System;
using System.Collections.Generic;
using ForHire.API.Models;

namespace ForHire.API.DTOs
{
    public class CompanyDetailsDto
    {
        public string PhotoUrl { get; set; }
        public string CompanyName { get; set; }
        public string Tagline { get; set; }
        public string CompanySize { get; set; }
        public string Description { get; set; }
        public string Field { get; set; }
        public string City { get; set; }
        public string Country { get; set; }



    }
}