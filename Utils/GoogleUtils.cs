namespace Task4_0.Utils
{
    public static class GoogleUtils
    {
        public static GoogleSettings GetGoogleSettings() => ConfigReader.GetValue<GoogleSettings>("googleSettings");
        public static async Task<GoogleMessage?> GetGmailLatestMessageId(string? access_token) {
            var googleMessagesUrl = GoogleUtils.GetGoogleSettings().GetMessagesUrl();
            var messages = await HttpUtils.Get<GoogleMessages>(googleMessagesUrl, access_token);
            return messages?.Messages.FirstOrDefault();
        }

        public static async Task<EmailModel?> GetEmailBody(string? access_token, string? emailId){
            var messageApiUrl = GoogleUtils.GetGoogleSettings().GetMessageWithIdUrl(emailId);
            return await HttpUtils.Get<EmailModel>(messageApiUrl, access_token);
        }

        public static async Task<AccessToken?> GetGoogleToken(string? authCode){
            var googleAuthUrlWithoutCode = GoogleUtils.GetGoogleSettings().GetTokenUrl();
            var googleAuthUrlWithCode = $"{googleAuthUrlWithoutCode}code={authCode}";
            return await HttpUtils.Post<AccessToken>(googleAuthUrlWithCode);
        }
    }
}