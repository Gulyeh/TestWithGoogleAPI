namespace Task4_0.Steps
{
    [Binding]
    public class ApiStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public ApiStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Given(@"I send POST request to google token url with code saved as '([^']*)' and save access token from response as '([^']*)'")]
        public async Task GivenISendPOSTRequestToGoogleAuthUrlWithCodeSavedAsAndSaveAccessTokenFromResponseAs(string authorizationCode, string accessToken)
        {     
            var authCode = scenarioContext[authorizationCode].ToString();
            var accessTokenModel = await GoogleUtils.GetGoogleToken(authCode);
            scenarioContext[accessToken] = accessTokenModel?.Access_Token;
        }

        [Given(@"I send GET request to Gmail Messages API with access token saved as '([^']*)' and save email ID from response as '([^']*)'")]
        public async Task GivenISendGETRequestToGmailMessagesAPIWithAccessTokenSavedAsAndSaveEmailIDFromResponseAs(string accessToken, string latestEmailId)
        {        
            var access_Token = scenarioContext[accessToken].ToString();
            var latestMessage = await GoogleUtils.GetGmailLatestMessageId(access_Token);
            scenarioContext[latestEmailId] = latestMessage?.Id;
        }

        [When(@"I send GET request to Gmail Messages API with access token saved as '([^']*)' and Id saved as '([^']*)' and save response body as '([^']*)'")]
        public async Task WhenISendGETRequestToGmailMessagesAPIWithAccessTokenSavedAsAndIdSavedAsAndSaveResponseBodyAs(string accessToken, string latestEmailId, string emailBody)
        {
            var emailId = scenarioContext[latestEmailId].ToString();
            var access_Token = scenarioContext[accessToken].ToString();
            var body = await GoogleUtils.GetEmailBody(access_Token, emailId);
            scenarioContext[emailBody] = body?.GetEmailBody();
        }

        [When(@"I get access_token saved as '([^']*)' and every (.*) seconds I try up to (.*) seconds to find different email Id than saved as '([^']*)' and save new one as '([^']*)' if found")]
        public async Task WhenIGetAccess_TokenSavedAsAndEverySecondsITryUpToSecondsToFindDifferentEmailIdThanSavedAsAndSaveNewOneAsIfFound(string accessToken, int sleepTime, int timeInSeconds, string emailIdLocator, string newEmailIdLocator)
        {
            var olderEmailId = scenarioContext[emailIdLocator].ToString();
            var newEmailId = string.Empty;
            var access_Token = scenarioContext[accessToken].ToString();

            if (olderEmailId == string.Empty || olderEmailId is null) return;

            while (timeInSeconds > 0 && !olderEmailId.Equals(newEmailId) && newEmailId == string.Empty)
            {
                var latestMessage = await GoogleUtils.GetGmailLatestMessageId(access_Token);
                if(!olderEmailId.Equals(latestMessage?.Id)) newEmailId = latestMessage?.Id;
                Thread.Sleep(sleepTime * 1000);
                timeInSeconds--;
            }

            if (newEmailId != string.Empty) scenarioContext[newEmailIdLocator] = newEmailId;
            else scenarioContext[newEmailIdLocator] = olderEmailId;
        }
    }
}