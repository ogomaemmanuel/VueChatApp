using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueChatApp.Features.Chat.Models;
using VueChatApp.Features.Chat.Services;
using VueChatApp.Hubs;

namespace VueChatApp.Features.Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }
        public async Task<IActionResult> Post(IncommingChatMessageViewModel chatMessageViewModel)
        {
            var sentMessage = await 
                this._chatService.SendMessageAsync(chatMessageViewModel);
            return new OkObjectResult(sentMessage);
        }
        [HttpPost("video-chat")]
        public async Task<IActionResult> PostVideo([FromForm]IncommingChatMessageViewModel chatMessageViewModel)
        {
            var sentMessage = await
                this._chatService.SendMessageAsync(chatMessageViewModel);
            
            return new OkObjectResult(sentMessage);
        }

        [HttpGet("gifs", Name = "GetGifs")]
        public async Task<IActionResult> GetGifs()
        {
            var gifs = await
                this._chatService.GetGifAsync();
            return new OkObjectResult(gifs);
        }
        [HttpGet("search", Name = "SearchGifs")]
        [AllowAnonymous]
        public async Task<IActionResult> GifSearch([FromQuery]GifSearchQuery gifSearchQuery)
        {
            var gifs = await
                this._chatService.SearchGifAsync(gifSearchQuery);
            return new OkObjectResult(gifs);
        }

        public async Task<IActionResult> StartCall(WebRtcMessage webRtcMessage)
        {
            await _chatService.StartCall(webRtcMessage);
            return Ok();
        }
        public async Task<IActionResult> AnswerCall(WebRtcMessage webRtcMessage)
        {
             await _chatService.AnswerCall(webRtcMessage);
             return Ok();
        }
        
        
    }
}