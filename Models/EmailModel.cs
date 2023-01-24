namespace Task4_0.Models
{
    public class EmailModel
    {
        public EmailModel()
        {
            Payload = new Payload();
        }

        [JsonProperty("payload")]
        public Payload Payload { private get; set; }

        public string? GetEmailBody() => Payload.Parts.FirstOrDefault()?.Body.Data;
    }

    public class Payload
    {
        public Payload()
        {
            Parts = new List<Parts>();
        }

        [JsonProperty("parts")]
        public IEnumerable<Parts> Parts { get; set; }
    }

    public class Parts
    {
        public Parts()
        {
            Body = new Body();
        }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public class Body
    {
        public Body()
        {
            Data = string.Empty;
        }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}