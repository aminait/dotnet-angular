using System;

namespace ForHire.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhotoUrl { get; set; }
        public string HeaderPhotoUrl { get; set; }
        public string CurrentPosition { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public DateTime Created { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}