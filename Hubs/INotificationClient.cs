using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueChatApp.Hubs
{
  public  interface INotificationClient
    {
        Task MessageToUser(Object outgoingMessage);
        Task UpdatedUserList(Object onlineUsers);
    }
}
