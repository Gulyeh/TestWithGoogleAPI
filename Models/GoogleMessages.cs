namespace Task4_0.Models
{
    public class GoogleMessages
    {
        public GoogleMessages()
        {
            Messages = new List<GoogleMessage>();
        }

        [JsonProperty("messages")]
        public IEnumerable<GoogleMessage> Messages { get; set; }
    }

    public class GoogleMessage
    {
        public GoogleMessage()
        {
            Id = string.Empty;
        }

        public string Id { get; set; }
    }
}