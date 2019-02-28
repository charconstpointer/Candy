using System.Threading.Tasks;
using Candy.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using TableDependency.SqlClient.Base;

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
        }

        public async Task SendGroupMessage(string roomName, string message)
        {
            await Clients.Groups(roomName).SendAsync("receiveMessage", message);
        }
    }
}