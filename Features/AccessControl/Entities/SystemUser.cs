using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Features.Chat.Entities;

namespace VueChatApp.Features.AccessControl.Entities
{
    public class SystemUser : IdentityUser<int> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [InverseProperty("From")]
        public ICollection<ChatMessage> SentMessages { get; set; }
        [InverseProperty("To")]
        public ICollection<ChatMessage> ReceivedMessages { get; set; }

    }
   
}
