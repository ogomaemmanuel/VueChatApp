using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VueChatApp.Data;
using VueChatApp.Features.Chat.Entities;
using VueChatApp.Features.Chat.Models;
using VueChatApp.Features.DocumentsManager.Documents.Controllers;
using VueChatApp.Features.DocumentsManager.Documents.Entities;
using VueChatApp.Hubs;
using static System.Net.Mime.MediaTypeNames;

namespace VueChatApp.Features.Chat.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatDbContext _dbContext;
        private readonly HttpClient _httpClient;
        protected readonly LinkGenerator _linkGenerator;
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;
        public  ChatService(ChatDbContext dbContext, 
            IHubContext<NotificationHub, INotificationClient> hubContext,
            HttpClient httpClient,
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor

            ) {
            _dbContext = dbContext;
            _hubContext = hubContext;
            _httpClient = httpClient;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;


        }
        public async Task<OutgoingChatMessageViewModel> SendMessageAsync(IncommingChatMessageViewModel incommingChatMessageViewModel)
        {
            var chatMessage = new ChatMessage()
            {
                Message = incommingChatMessageViewModel.Message,
                ToId = incommingChatMessageViewModel.To.Id,
                FromId = incommingChatMessageViewModel.From.Id,
                Type=incommingChatMessageViewModel.Type,
            };


            if (incommingChatMessageViewModel.IsTypeSet) {
                switch (incommingChatMessageViewModel.Type) {
                    case "img":
                        var bytes = Convert.FromBase64String(chatMessage.Message.Replace("data:image/png;base64,", ""));
                        File.WriteAllBytes($"Uploads/Images/{Guid.NewGuid()}.png", bytes);
                        break;
                    case "video":
                        var fileName = Guid.NewGuid().ToString();
                        var ext = Path.GetExtension(incommingChatMessageViewModel.Video.FileName);
                        var videoUploadPath = $"Uploads/Videos/{fileName}{ext}";
                        var document = new Document {
                            ContentType = incommingChatMessageViewModel.Video.ContentType,
                            Ext = ext,
                            Name = fileName,
                            Path= videoUploadPath
                        };
                       chatMessage.Message = _linkGenerator.GetPathByAction(nameof(DocumentsController.Get),
                            "documents",
                            new {name= fileName }
                            );
                        using (var stream = new FileStream(videoUploadPath, FileMode.Create))
                        {
                            await incommingChatMessageViewModel.Video.CopyToAsync(stream);
                        }
                        await _dbContext.AddAsync(document);
                        break;
                    default:
                        break;
                }


            }

            
            await _dbContext.AddAsync(chatMessage);
           await _dbContext.SaveChangesAsync();
            var outGoingMessage = new OutgoingChatMessageViewModel
            {
                Id = chatMessage.Id,
                FromId = chatMessage.FromId,
                ToId = chatMessage.ToId,
                Message = chatMessage.Message,
                CreatedAt = chatMessage.CreatedAt,
                UpdatedAt = chatMessage.UpdatedAt,
                FromUserName = incommingChatMessageViewModel.From.UserName,
                ToUserName = incommingChatMessageViewModel.To.UserName,
                Type= incommingChatMessageViewModel.Type,
            };
            await this._hubContext.Clients
                .User(incommingChatMessageViewModel.To.Id.ToString())
                .MessageToUser(outGoingMessage);
            return outGoingMessage;
        }

        public async Task<dynamic> GetGifAsync() {
            var response = await _httpClient.GetAsync("https://api.tenor.com/v1/trending?key=LIVDSRZULELA&anon_id=3a76e56901d740da9e59ffb22b988242");
            var dataAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(dataAsString);


        }

        public async Task<dynamic> SearchGifAsync(GifSearchQuery gifSearchQuery)
        {
            var url = $"https://api.tenor.com/v1/search?q={gifSearchQuery.Q}&key=LIVDSRZULELA&limit=8&anon_id=3a76e56901d740da9e59ffb22b988242";
            var response = await _httpClient.GetAsync(url);
            var dataAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(dataAsString);
        }
    }
}
