using System.Threading.Tasks;

namespace VueChatApp.Hubs
{
    public interface IQrLoginClient
    {
        Task AuthDetails(object authToken);
        //json connectionId and token created
        Task LoginCode(string loginCode);
    }
}