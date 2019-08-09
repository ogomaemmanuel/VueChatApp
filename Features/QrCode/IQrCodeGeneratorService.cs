using System;
using System.Threading.Tasks;

namespace VueChatApp.Features.QrCode
{
    public interface IQrCodeGeneratorService
    {
        Task <String> Generate(String connetcionId);
    }
}