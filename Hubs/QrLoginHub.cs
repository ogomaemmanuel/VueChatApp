using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using VueChatApp.Features.QrCode;

namespace VueChatApp.Hubs
{
    public class QrLoginHub:Hub<IQrLoginClient>
    {
        private IQrCodeGeneratorService _codeGeneratorService;

        public QrLoginHub(IQrCodeGeneratorService codeGeneratorService)
        {
            _codeGeneratorService = codeGeneratorService;
        }

        public async Task GetCode()
        {
           var code= await _codeGeneratorService.Generate(Context.ConnectionId);
           Clients.Client(Context.ConnectionId).LoginCode(code);
          
        }
        
    }
}