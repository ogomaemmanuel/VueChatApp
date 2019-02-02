using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Features.AccessControl.Models;

namespace VueChatApp.Features.Chat.Models
{
    public class IncommingChatMessageViewModel
    {
        public string Message { get; set; }
        public SystemUserViewModel From { get; set; }
        public SystemUserViewModel To { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Type { get; set; }
        public bool IsTypeSet => !String.IsNullOrWhiteSpace(Type);
        public IFormFile Video { get; set; }
    }
}
