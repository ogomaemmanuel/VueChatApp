using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueChatApp.Features.Chat.Models;
using VueChatApp.Hubs;

namespace VueChatApp.Features.Chat.Services
{
   public interface IChatService
    {
        Task<OutgoingChatMessageViewModel> SendMessageAsync(IncommingChatMessageViewModel incommingChatMessageViewModel);
        Task<dynamic> GetGifAsync();
        Task<dynamic> SearchGifAsync(GifSearchQuery gifSearchQuery);

        Task StartCall(WebRtcMessage webRtcMessage);

        Task AnswerCall(WebRtcMessage webRtcMessage);
    }
}
