namespace Task4_0.Models
{
    public class AccessToken
    {
        public AccessToken()
        {
            Access_Token = string.Empty;
        }

        [JsonProperty("access_token")]
        public string Access_Token { get; set; }
    }
}