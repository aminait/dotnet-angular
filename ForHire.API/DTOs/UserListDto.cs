using System;
using System.Collections.Generic;
using ForHire.API.Models;

namespace ForHire.API.DTOs
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string CurrentPosition { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}