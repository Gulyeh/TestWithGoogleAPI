namespace Task4_0.Steps
{
    [Binding]
    public class NewsletterPageStepDefinitions
    {
        private readonly NewsletterPage newsletterPage;

        public NewsletterPageStepDefinitions()
        {
            newsletterPage = new NewsletterPage();
        }

        [Then(@"Newsletters page is opened")]
        public void ThenNewslettersPageIsOpened()
        {
            Assert.IsTrue(newsletterPage.State.IsDisplayed, "Newsletter page is not opened");
        }

        [When(@"I choose random newsletter")]
        public void WhenIChooseRandomNewsletter()
        {
            newsletterPage.ChooseRandomNewsletter();
        }

        [When(@"I click Select This Newsletter button")]
        public void WhenIClickSelectThisNewsletterButton()
        {
            newsletterPage.ClickSelectThisNewsletterButton();
        }

        [Then(@"An email form appeared at the bottom of the page")]
        public void ThenAnEmailFormAppearedAtTheBottomOfThePage()
        {
            Assert.IsTrue(newsletterPage.IsNewsletterFormDisplayed(), "Newsletter form is not displayed");
        }

        [When(@"I enter email to newsletter form")]
        public void WhenIEnterEmailToNewsletterForm()
        {
            var email = GoogleUtils.GetGoogleSettings().Email;
            newsletterPage.WaitAndInputEmailToNewsletterFormTextBox(email);
        }

        [When(@"I click Submit button at newsletter form")]
        public void WhenIClickSubmitButtonAtNewsletterForm()
        {
            newsletterPage.WaitAndClickSubmitNewsletterButton();
        }

        [When(@"I click See preview button on the same newsletter")]
        public void WhenIClickSeePreviewButtonOnTheSameNewsletter()
        {
            newsletterPage.ClickSeePreviewButtonOnNewsletter();
        }

        [When(@"I wait for subscription form to appear")]
        public void WhenIWaitForSubscriptionFormToAppear()
        {
            newsletterPage.WaitForSubscriptionForm();
        }

    }
}