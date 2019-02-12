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
    
//    public partial class Message
//    {
//        public static Message FromJson(string json) => JsonConvert.DeserializeObject<Message>(json, Converter.Settings);
//    }
//
//    public static class Serialize
//    {
//        public static string ToJson(this Message self) => JsonConvert.SerializeObject(self, Converter.Settings);
//    }
//
//    internal static class Converter
//    {
//        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
//        {
//            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
//            DateParseHandling = DateParseHandling.None,
//            Converters = {
//                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
//            },
//        };
//    }
}