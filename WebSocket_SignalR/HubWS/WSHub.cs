
using Microsoft.AspNetCore.SignalR;

namespace WebSocket_SignalR.HubWS
{
    public sealed class WSHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            int i = 0;
            while (true)
            {
                await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} Joined   --- {i++}");
                await Task.Delay(2000);
            }
        }

        public async Task send(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} {message}");
        }
    }
}
