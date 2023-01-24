namespace Task4_0.Steps
{
    [Binding]
    public class SubscriptionPageStepDefinitions
    {
        private readonly SubscriptionPage subscriptionPage;

        public SubscriptionPageStepDefinitions()
        {
            subscriptionPage = new SubscriptionPage();
        }

        [Then(@"A page with a message about successful subscription confirmation is opened")]
        public void ThenAPageWithAMessageAboutSuccessfulSubscriptionConfirmationIsOpened()
        {
            Assert.IsTrue(subscriptionPage.State.IsDisplayed, "Subscription page is not opened");
        }

        [When(@"I click Back to the site button")]
        public void WhenIClickBackToTheSiteButton()
        {
            subscriptionPage.WaitAndClickBackToTheSiteButton();
        }
    }
}