using System;

namespace ForHire.API.DTOs
{
    public class MessageReturnDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessageSent { get; set; }
        public string Content { get; set; }
        public MessageReturnDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}