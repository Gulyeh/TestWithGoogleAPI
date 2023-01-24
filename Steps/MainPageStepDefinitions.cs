namespace Task4_0.Steps
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private readonly MainPage mainPage;

        public MainPageStepDefinitions()
        {
            mainPage = new MainPage();
        }

        [Then(@"Main page is opened")]
        public void ThenMainPageIsOpened()
        {
            Assert.IsTrue(mainPage.State.IsDisplayed, "Main Page is not opened");
        }

        [When(@"I click Newsletters button")]
        public void WhenIClickNewslettersButton()
        {
            mainPage.WaitAndClickNewsletterButton();
        }

        [When(@"I accept cookies")]
        public void WhenIAcceptCookies()
        {
            mainPage.WaitAndClickAcceptCookiesButton();
        }
    }
}