using System.Threading.Tasks;
using Candy.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Candy.Hubs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task JoinRoom(string nick, string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
//            await Clients.User(Context.User.Identity.Name).SendAsync(new Message(){Body = "b", Name = "n"});
        }//http://localhost:5000/chat

        public async Task SendGroupMessage(string roomName, string message)
        {
            await Clients.Groups(roomName).SendAsync("receiveMessage", message);
        }
    }
}