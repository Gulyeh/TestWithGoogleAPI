namespace Task4_0.Steps
{
    [Binding]
    public class UnsubscribePageStepDefinitions
    {
        private readonly UnsubscribePage unsubscribePage;

        public UnsubscribePageStepDefinitions()
        {
            unsubscribePage = new UnsubscribePage();
        }


        [Then(@"Unsubscribe page is opened")]
        public void ThenUnsubscribePageIsOpened()
        {
            Assert.IsTrue(unsubscribePage.State.IsDisplayed, "Unsubscribe page is not opened");
        }

        [When(@"I enter email address in unsubscribe text field")]
        public void WhenIEnterGoogleEmailAddressInUnsubscribeTextField()
        {
            var email = GoogleUtils.GetGoogleSettings().Email;
            unsubscribePage.WaitAndInputEmail(email);
        }

        [When(@"I click submit button on unsubscribe page")]
        public void WhenIClickSubmitButtonOnUnsubscribePage()
        {
            unsubscribePage.WaitAndClickSubmitButton();
        }

        [Then(@"A message that the subscription was canceled appears")]
        public void ThenAMessageThatTheSubscriptionWasCanceledAppears()
        {
            Assert.IsTrue(unsubscribePage.IsUnsubscribeTextDisplayed(), "Unsubscribe text is not displayed");
        }
    }
}