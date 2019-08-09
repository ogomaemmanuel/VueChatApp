using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRCoder;
using VueChatApp.Data;

namespace VueChatApp.Features.QrCode
{
    public class QrCodeGeneratorService : IQrCodeGeneratorService
    {
        private readonly ChatDbContext _dbContext;

        public QrCodeGeneratorService(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Generate(String connectionId)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            var uniqueToken = Guid.NewGuid().ToString();
            var tokenDict = new Dictionary<String,String>()
            {
                {"token",uniqueToken},
                {"connectionId",connectionId}
            };
            
           
            QRCodeData qrCodeData =
                qrGenerator.CreateQrCode(JsonConvert.SerializeObject(tokenDict), QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            var bitmapBytes = BitmapToBytes(qrCodeImage); //Convert bitmap into a byte array
            String base64Image = Convert.ToBase64String(bitmapBytes);
            Entities.QrCode qrCodeEntity = new Entities.QrCode();
            var token=$"data:image/png;base64,{base64Image}";
            qrCodeEntity.Token = token;
            await _dbContext.QrCodes.AddAsync(qrCodeEntity);
            await _dbContext.SaveChangesAsync();
            return token;
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}