using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Features.AccessControl.Models
{
    public class SystemUserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{ FirstName} {LastName}";
        public bool IsOnline { get; set; }
    }
}
