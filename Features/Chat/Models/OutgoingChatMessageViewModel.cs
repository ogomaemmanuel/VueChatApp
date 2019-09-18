using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.Chat.Models
{
    public class OutgoingChatMessageViewModel
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public long FromId { get; set; }
        public String FromUserName { get; set; }
        public long ToId { get; set; }
        public String ToUserName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<String> Attachments { get; set; }
        public string Url { get; set; }

    }
}
