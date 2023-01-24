namespace Task4_0.Models
{
    public class GoogleSettings
    {
        public GoogleSettings()
        {
            AuthApi = string.Empty;
            TokenApi = string.Empty;
            MessagesApi = string.Empty;
            ClientId = string.Empty;
            Scopes = new List<string>();
            ClientId = string.Empty;
            ResponseType = string.Empty;
            RedirectUrl = string.Empty;
            GrantType = string.Empty;
            ClientSecret = string.Empty;
            LabelIds = new List<string>();
            Email = string.Empty;
            Password = string.Empty;
        }

        [JsonProperty("googleAuthApi")]
        public string AuthApi { private get; set; }
        [JsonProperty("googleTokenApi")]
        public string TokenApi { private get; set; }
        [JsonProperty("gmailMessagesApi")]
        public string MessagesApi { private get; set; }
        [JsonProperty("client_Id")]
        public string ClientId { private get; set; }
        [JsonProperty("scope")]
        public IEnumerable<string> Scopes { private get; set; }
        [JsonProperty("response_type")]
        public string ResponseType { private get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { private get; set; }
        [JsonProperty("grant_type")]
        public string GrantType { private get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { private get; set; }
        [JsonProperty("maxResults")]
        public int MaxResults { private get; set; }
        [JsonProperty("labelIds")]
        public IEnumerable<string> LabelIds { private get; set; }
        [JsonProperty("gmailEmail")]
        public string Email { get; set; }
        [JsonProperty("gmailPassword")]
        public string Password { get; set; }


        public string GetAuthUrl()
        {
            var builder = new StringBuilder();
            builder.Append($"{AuthApi}?");
            builder.Append($"client_id={ClientId}&");
            builder.Append($"redirect_uri={RedirectUrl}&");
            builder.Append($"response_type={ResponseType}");

            foreach (var scope in Scopes)
            {
                builder.Append($"&scope={scope}");
            }

            return builder.ToString();
        }

        public string GetTokenUrl()
        {
            var builder = new StringBuilder();
            builder.Append($"{TokenApi}?");
            builder.Append($"grant_type={GrantType}&");
            builder.Append($"client_id={ClientId}&");
            builder.Append($"client_secret={ClientSecret}&");
            builder.Append($"redirect_uri={RedirectUrl}&");

            return builder.ToString();
        }

        public string GetMessagesUrl()
        {
            var builder = new StringBuilder();
            builder.Append($"{MessagesApi}?");
            builder.Append($"maxResults={MaxResults}");

            foreach (var labelId in LabelIds)
            {
                builder.Append($"&labelIds={labelId}");
            }

            return builder.ToString();
        }

        public string GetMessageWithIdUrl(string? id) => $"{MessagesApi}/{id}";
    }
}