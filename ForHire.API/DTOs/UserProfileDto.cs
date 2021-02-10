using System;
using System.Collections.Generic;
using ForHire.API.Models;

namespace ForHire.API.DTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string HeaderPhotoUrl { get; set; }
        public string CurrentPosition { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public DateTime Created { get; set; }
        public int Age { get; set; }
    }
}