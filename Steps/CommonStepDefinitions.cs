namespace Task4_0.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly RedirectPage redirectPage;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            redirectPage = new RedirectPage();

        }

        [When(@"I navigate to url")]
        public void WhenINavigateToUrl()
        {
            var url = ConfigReader.GetValue<string>("url");
            AqualityServices.Browser.GoTo(url);
        }

        [Given(@"I navigate to url saved as '([^']*)'")]
        [When(@"I navigate to url saved as '([^']*)'")]
        public void GivenINavigateToUrlSavedAs(string url)
        {
            var savedUrl = scenarioContext[url].ToString();
            AqualityServices.Browser.GoTo(savedUrl);
        }

        [Given(@"I form google auth URL and save as '([^']*)'")]
        public void GivenIFormGoogleAuthURLAndSaveAs(string googleAuthUrl)
        {
            scenarioContext[googleAuthUrl] = GoogleUtils.GetGoogleSettings().GetAuthUrl();
        }

        [Given(@"I save url parameter '([^']*)' as '([^']*)'")]
        public void GivenISaveUrlParameterAs(string code, string authorizationCode)
        {
            scenarioContext[authorizationCode] = redirectPage.WaitAndGetParamFromUrl(code);
        }

        [When(@"I convert email body saved as '([^']*)' from Base to HTML and save as '([^']*)'")]
        public void WhenIConvertEmailBodySavedAsFromBaseToHTMLAndSaveAs(string emailBody, string emailBody1)
        {
            var base64Body = scenarioContext[emailBody].ToString();
            scenarioContext[emailBody1] = ConverterUtils.Base64ToHTML(base64Body);
        }

        [When(@"I find confirmation link in body saved as '([^']*)' and save as '([^']*)'")]
        public void WhenIFindConfirmationLinkInBodySavedAsAndSaveAs(string emailBody, string confirmationLink)
        {
            var emailHtmlBody = (HtmlDocument)scenarioContext[emailBody];
            var link = emailHtmlBody.DocumentNode.SelectSingleNode("//a[@target='_blank']").Attributes["href"].Value;
            scenarioContext[confirmationLink] = link;
        }

        [Then(@"Email Ids saved as '([^']*)' and '([^']*)' are equal")]
        public void ThenEmailIdsSavedAsAndAreEqual(string latestEmailId, string newLatestEmailId)
        {
            var latestId = scenarioContext[latestEmailId].ToString();
            var newLatestId = scenarioContext[newLatestEmailId].ToString();
            Assert.AreEqual(latestId, newLatestId, "There is a new email in mailbox");
        }

        [Then(@"I check if older email Id saved as '([^']*)' is different from newer Id saved as '([^']*)' and override older with newer")]
        public void ThenICheckIfOlderEmailIdSavedAsIsDifferentFromNewerIdSavedAsAndOverrideOlderWithNewer(string latestEmailId, string newLatestEmailId)
        {
            var latestId = scenarioContext[latestEmailId];
            var newLatestId = scenarioContext[newLatestEmailId];

            Assert.AreNotEqual(latestId, newLatestId, "Email ids are equal");

            scenarioContext[newLatestEmailId] = null;
            scenarioContext[latestEmailId] = newLatestId;
        }

    }
}