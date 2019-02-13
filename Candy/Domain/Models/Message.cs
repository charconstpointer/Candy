using Newtonsoft.Json;

namespace Candy.Domain.Models
{
    public class Message
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}