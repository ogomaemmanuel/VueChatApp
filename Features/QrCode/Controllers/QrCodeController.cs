using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VueChatApp.Features.QrCode.Controllers
{
    [Route("api/qrcode")]
    public class QrCodeController : Controller
    {
        private readonly IQrCodeGeneratorService _codeGenerator;

        public QrCodeController(IQrCodeGeneratorService codeGenerator)
        {
            _codeGenerator = codeGenerator;
        }

        [HttpGet()]
        public async Task<IActionResult> get()
        {
            String qrCode = await _codeGenerator.Generate();
            return new ObjectResult(qrCode);
        }
    }
}