using Microsoft.AspNetCore.SignalR;

namespace ElectricStore.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAll(string user, string message)
        {
            await Clients.All.SendAsync("NewMessage", user, message);
        }
    }
}
