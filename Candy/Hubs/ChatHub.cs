using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Candy.Hubs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message messageBody)
        {
            await Clients.All.SendAsync("receiveMessage", messageBody);
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

    public partial class Message
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
    
}