using System;

namespace ForHire.API.Models
{
    public class SocialProfile
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }

        public virtual Company Company { get; set; }
        public virtual int CompanyId { get; set; }
    }
}