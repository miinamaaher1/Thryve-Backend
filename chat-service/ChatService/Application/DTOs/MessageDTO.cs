﻿
using Domain.Entities;

namespace Application.DTOs
{
    public class MessageDTO
    {
        public string Id { get; set; } = string.Empty;
        public string ConversationId { get; set; } = string.Empty;
        public string SenderId { get; set; } = string.Empty;
        public ProfileDTO SenderProfile { get; set; }
        public string? Content { get; set; }
        public bool HasAttachment { get; set; }
        public Attachment? Attachment { get; set; }
        public bool Read {  get; set; }
        public DateTime TimeStamp { get; set; }
    }
}