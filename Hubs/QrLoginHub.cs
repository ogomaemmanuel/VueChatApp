using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using VueChatApp.Features.QrCode;

namespace VueChatApp.Hubs
{
    public class QrLoginHub:Hub
    {
        private IQrCodeGeneratorService _codeGeneratorService;

        public QrLoginHub(IQrCodeGeneratorService codeGeneratorService)
        {
            _codeGeneratorService = codeGeneratorService;
        }

        public async Task GetCode()
        {
           var code= await _codeGeneratorService.Generate();

           Clients.Client(Context.ConnectionId).SendAsync("LoginCode",code);
          
        }
        
    }
}