using Microsoft.AspNetCore.SignalR;

namespace GPI.Presentation.Hubs;

public class SignalRClient : Hub
{
    public override Task OnConnectedAsync()
    {
        string connectionId = Context.ConnectionId;
        return base.OnConnectedAsync();
    }
}