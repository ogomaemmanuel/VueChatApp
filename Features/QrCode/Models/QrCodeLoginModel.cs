using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VueChatApp.Features.QrCode.Models
{
    public class QrCodeLoginModel
    {
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}