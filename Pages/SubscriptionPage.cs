namespace Task4_0.Pages
{
    public class SubscriptionPage : Form
    {
        public SubscriptionPage() : base(By.XPath("//div[contains(@class, 'enw-block-confirmation')]"), "Subscription")
        {

        }

        private IButton backToSiteButton = ElementFactory.Get<IButton>(By.XPath("//a[contains(@class, 'enw-btn__confirmation')]"), "Back to the site");

        public void WaitAndClickBackToTheSiteButton()
        {
            ConditionalWait.WaitFor(x => backToSiteButton.State.IsDisplayed);
            backToSiteButton.Click();
        }
    }
}