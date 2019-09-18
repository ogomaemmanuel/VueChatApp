using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Features.AccessControl.Entities;

namespace VueChatApp.Features.Chat.Entities
{
    public class ChatMessage
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public long ToId { get; set; }
        [ForeignKey("ToId")]
        public SystemUser To { get; set; }
        public long FromId { get; set; }
        [ForeignKey("FromId")]
        public SystemUser From { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }=DateTime.UtcNow;
    }
}
