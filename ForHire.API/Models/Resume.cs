using System;

namespace ForHire.API.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}