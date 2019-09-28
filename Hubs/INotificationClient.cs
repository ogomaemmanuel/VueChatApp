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
        Task WebRtcSignal(WebRtcMessage webRtcOffer);
      
    }

  public class WebRtcMessage
  {
      public String To { get; set; }
      public String From { get; set; }
      public String Type { get; set; }//can be offer, answer,candidate,hung-up
      public Object Sdp { get; set; }
      public Object Candidate { get; set; }
  }
}
