using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Candy.Hubs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
            await JoinRoom("default");
        }

        public async Task JoinRoom(string roomName)
        {
            //
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.User(Context.User.Identity.Name).SendAsync("receiveMessage", "connected to room " + roomName);
        }
    }
}